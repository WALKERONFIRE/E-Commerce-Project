using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_CommerceProject0.Controller
{
   
    [ApiController]
    [Route("User")]

    public class UserController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;

        public UserController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        [HttpGet("AllUsers")]
        public ActionResult GetUsers()
        {
            var lst = _context.Users.ToList();
            return Ok(lst);
        }
        [HttpPost("GetSpecificUser")]
        public ActionResult getbyid([FromForm] int id)
        {
            var res = _context.Users.Find(id);
            if (res == null)
            {
                return BadRequest("Not Found");
            }
            var res1 = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return Ok(res1);
        }

        [HttpPost("Register")]
        public ActionResult Add(UserRegister u)
        {
            User us = _mapper.Map<User>(u);
            _context.Add(us);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("Login")]
        public ActionResult userlogin(UserLogin ul)
        {
            var lg = _context.Users.Where(s => s.Email == ul.Email && s.Password == ul.Password).FirstOrDefault();
            if (lg == null)
            {
                return Unauthorized("Incorrect Email or Password");
            }
            return Ok(lg);
        }
        [HttpDelete("DeleteUser")]
        public ActionResult delete([FromForm] int id)
        {
            var res = _context.Users.Find(id);
            if (res == null)
            {
                return BadRequest("Not Found");
            }
            _context.Remove(res);
            _context.SaveChanges();
            return Ok("Done");
        }

        [HttpPut("EditProfile")]
        public ActionResult Updateprofile([FromQuery] int Id, [FromBody] UserRegister reg)
        {
            var rs = _context.Users.AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            if (rs == null)
            {
                return BadRequest("Not Found");
            }
            User s = new User()
            {
                Id = Id,
                Name = reg.Name ?? rs.Name,
                Email = reg.Email ?? rs.Email,
                PhoneNumber = reg.PhoneNumber ?? rs.PhoneNumber,


            };
            _context.Users.Update(s);
            _context.SaveChanges();
            return Ok("Done");
        }

    }
}