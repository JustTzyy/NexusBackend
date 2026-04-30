using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Rooms;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/room")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Get all active rooms with pagination and search
        /// </summary>
        [RequirePermission("ViewRooms")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<RoomListDto>>>> GetAllRooms([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _roomService.GetAllRoomsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<RoomListDto>>.SuccessResponse(result, "Rooms retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<RoomListDto>>.ErrorResponse("An error occurred while retrieving rooms"));
            }
        }

        /// <summary>
        /// Get archived (soft-deleted) rooms
        /// </summary>
        [RequirePermission("ArchiveRooms")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<RoomListDto>>>> GetArchivedRooms([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _roomService.GetArchivedRoomsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<RoomListDto>>.SuccessResponse(result, "Archived rooms retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<RoomListDto>>.ErrorResponse("An error occurred while retrieving archived rooms"));
            }
        }

        /// <summary>
        /// Get room by ID with building info
        /// </summary>
        [RequirePermission("ViewRooms")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> GetRoomById(int id)
        {
            try
            {
                var room = await _roomService.GetRoomByIdAsync(id);
                if (room == null)
                {
                    return NotFound(ApiResponse<RoomResponseDto>.ErrorResponse("Room not found"));
                }

                return Ok(ApiResponse<RoomResponseDto>.SuccessResponse(room, "Room retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoomResponseDto>.ErrorResponse("An error occurred while retrieving room"));
            }
        }

        /// <summary>
        /// Create a new room
        /// </summary>
        [RequirePermission("CreateRooms")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> CreateRoom([FromBody] CreateRoomDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var room = await _roomService.CreateRoomAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.Id },
                    ApiResponse<RoomResponseDto>.SuccessResponse(room, "Room created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<RoomResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoomResponseDto>.ErrorResponse("An error occurred while creating room"));
            }
        }

        /// <summary>
        /// Update an existing room
        /// </summary>
        [RequirePermission("UpdateRooms")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> UpdateRoom(int id, [FromBody] UpdateRoomDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var room = await _roomService.UpdateRoomAsync(id, dto, currentUserId);
                if (room == null)
                {
                    return NotFound(ApiResponse<RoomResponseDto>.ErrorResponse("Room not found"));
                }

                return Ok(ApiResponse<RoomResponseDto>.SuccessResponse(room, "Room updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<RoomResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoomResponseDto>.ErrorResponse("An error occurred while updating room"));
            }
        }

        /// <summary>
        /// Soft delete a room (moves to archive)
        /// </summary>
        [RequirePermission("DeleteRooms")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteRoom(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roomService.DeleteRoomAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Room not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Room deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting room"));
            }
        }

        /// <summary>
        /// Restore a soft-deleted room from archive
        /// </summary>
        [RequirePermission("RestoreRooms")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreRoom(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roomService.RestoreRoomAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Room not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Room restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring room"));
            }
        }

        /// <summary>
        /// Permanently delete a room (cannot be undone)
        /// </summary>
        [RequirePermission("PermanentDeleteRooms")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteRoom(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roomService.PermanentDeleteRoomAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Room not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Room permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting room"));
            }
        }
    }
}
