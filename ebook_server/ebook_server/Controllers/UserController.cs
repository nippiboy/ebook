using ebook_server.DTOs;
using ebook_server.Entitys;
using ebook_server.Helper;
using ebook_server.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ebook_server.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;
        private readonly UserConverter converter;
        private readonly ApplicationDbContext context;

        public UserController(IUserRepository userRepository, ApplicationDbContext context)
        {

            this.userRepository = userRepository;
            this.converter = new UserConverter();
            this.context = context;
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            List<User> userList = await context.Users.ToListAsync();
            //List<User> userList = userRepository.GetUsers().Result.ToList();

            List<UserDTO> userDTOs = new List<UserDTO>();
            userList.ForEach(user =>
            {
                userDTOs.Add(converter.ConvertUserToUserDTO(user));
            });

            return Ok(userDTOs);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers2()
        {
            //List<User> userList = await context.Users.ToListAsync();
            List<User> userList = userRepository.GetUsers().Result.ToList();

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
            //User user = userRepository.GetUser(userName).Result;
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if(user == null) return NotFound();

            return Ok(converter.ConvertUserToUserDTO(user));
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] UserCreationDTO userCreationDTO)
        {
            User user = converter.ConvertUserCreationDToTOUser(userCreationDTO);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
