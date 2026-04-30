using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NexUs.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using NexUs.Services;
using NexUs.Services.Interfaces;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IRecaptchaService, RecaptchaService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IOperationLogService, OperationLogService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IAvailableDayService, AvailableDayService>();
builder.Services.AddScoped<IAvailableTimeSlotService, AvailableTimeSlotService>();
builder.Services.AddScoped<ITeacherAssignmentService, TeacherAssignmentService>();
builder.Services.AddScoped<IStudentAssignmentService, StudentAssignmentService>();
builder.Services.AddScoped<ITutoringRequestService, TutoringRequestService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISessionLogService, SessionLogService>();
builder.Services.AddSingleton<ILocationService, LocationService>();
builder.Services.AddHostedService<SessionReminderBackgroundService>();

// Marketing Automation Services
builder.Services.AddScoped<ISuppressionService, SuppressionService>();
builder.Services.AddScoped<IEmailTemplateService, EmailTemplateService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISegmentService, SegmentService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IAutomationService, AutomationService>();
builder.Services.AddScoped<IEmailMessageService, EmailMessageService>();
builder.Services.AddScoped<IMarketingEmailService, MarketingEmailService>();
builder.Services.AddScoped<IMarketingAnalyticsService, MarketingAnalyticsService>();

// Notification Service
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddHostedService<CampaignSenderBackgroundService>();
builder.Services.AddHostedService<SessionAutoAbsentBackgroundService>();

builder.Services.AddMemoryCache();

builder.Services.AddRateLimiter(options =>
{
    // 20 attempts per 5 minutes per IP for auth endpoints
    options.AddFixedWindowLimiter("auth", o =>
    {
        o.PermitLimit = 20;
        o.Window = TimeSpan.FromMinutes(5);
        o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        o.QueueLimit = 0;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ClockSkew = TimeSpan.Zero
    };
});

// CORS: only allow the frontend URL for the current environment (local ↔ local, cloud ↔ cloud)
var frontendUrl = builder.Configuration["ApplicationSettings:FrontendUrl"]!;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins(frontendUrl)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Optional root endpoint
app.MapGet("/", () => "NexUs API is running ✅");

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    if (!app.Environment.IsDevelopment())
        context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";
    await next();
});
app.UseCors("AllowReactApp");
app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// One-time startup: seed EmailTemplate.Body from HTML files for any template not yet in DB
using (var seedScope = app.Services.CreateScope())
{
    var db  = seedScope.ServiceProvider.GetRequiredService<NexUs.Data.ApplicationDbContext>();
    var env = seedScope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    var templatesDir = Path.Combine(env.ContentRootPath, "Templates", "Email");
    var pending = db.EmailTemplates.Where(t => t.Body == null && t.FileName != null).ToList();
    foreach (var tmpl in pending)
    {
        var filePath = Path.Combine(templatesDir, tmpl.FileName);
        if (File.Exists(filePath))
        {
            tmpl.Body = File.ReadAllText(filePath);
            tmpl.UpdatedAt = DateTime.UtcNow;
        }
    }
    if (pending.Any(t => t.Body != null)) db.SaveChanges();
}

app.Run();
