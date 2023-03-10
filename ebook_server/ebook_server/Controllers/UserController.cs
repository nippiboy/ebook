using ebook_server.DTOs;
using ebook_server.Entitys;
using ebook_server.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace ebook_server.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly UserConverter converter;
        readonly private ApplicationDbContext context;
        private readonly IStringLocalizer<UserController> localizer;

        public UserController(ApplicationDbContext context, IStringLocalizer<UserController> localizer)
        {
            this.context = context;
            this.converter = new UserConverter();
            this.localizer = localizer;
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            List<User> userList = new List<User>();
            try
            {
                userList = await context.Users.ToListAsync();
            }
            catch (SqlException ex) { return Problem("Database problem"); }

            List<UserDTO> userDTOs = new List<UserDTO>();
            userList.ForEach(user =>
            {
                userDTOs.Add(converter.ConvertUserToUserDTO(user));
            });

            return Ok(userDTOs);
        }


        [HttpGet("{userName}")]
        public async Task<ActionResult<UserDTO>> GetUser(string userName)
        {
            User user = new User();
            try
            {
                user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            }
            catch (SqlException ex) { return Problem("Database problem"); }

            if (user == null) return NotFound();

            return Ok(converter.ConvertUserToUserDTO(user));
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] UserCreationDTO userCreationDTO)
        {
            User user = converter.ConvertUserCreationDToTOUser(userCreationDTO);
            context.Users.Add(user);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (SqlException ex) { return Problem("Database problem"); }

            return NoContent();
        }

        [HttpDelete("delete/{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            bool exist = await context.Users.AnyAsync();

            if (!exist) return NotFound();

            context.Remove(new User() { UserName = userName });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
