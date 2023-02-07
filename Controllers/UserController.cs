using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("auto/user")]
        public JsonResult GetUser()
        {
            var allUser = new AllUser()
            {
                Age = 18,
                ID = 1,
                Name = "张三"
            };

            var user = allUser.MapTo<User>();
            return new JsonResult(user);

        }
        [HttpGet("auto/alluser")]
        public JsonResult GetAllUser()
        {
            var user = new User()
            {
                ID = 1,
                Name = "张三"
            };
            var allUser = user.MapTo<AllUser>();

            return new JsonResult(allUser);

        }

        [HttpGet("manual/user")]
        public JsonResult GetUserByManual()
        {
            var allUser = new AllUser()
            {
                Age = 18,
                ID = 1,
                Name = "张三"
            };

            var user = _mapper.Map(allUser, new User());
            return new JsonResult(user);

        }
        [HttpGet("manual/alluser")]
        public JsonResult GetAllUserBymanual()
        {
            var user = new User()
            {
                ID = 1,
                Name = "张三"
            };
            var allUser = _mapper.Map(user, new AllUser());

            return new JsonResult(allUser);

        }

        class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        class AllUser
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class UserProfile : Profile
        {
            public UserProfile()
            {
                CreateMap<User, AllUser>().ReverseMap();

            }
        }
    }
}