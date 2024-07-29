using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_CommerceProject0.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;

        public VendorController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("AddVendor")]
        public ActionResult addvendor(VendorRegister vr)
        {
            Vendor v = _mapper.Map<Vendor>(vr);
            _context.Add(v);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpDelete("DeleteVendor")]
        public ActionResult delete([FromForm] int id)
        {
            var res = _context.Vendors.Find(id);
            if (res == null)
            {
                return BadRequest("Not Found");
            }
            _context.Remove(res);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPut("EditProfile")]
        public ActionResult Updateprofile([FromQuery] int Id, [FromBody] VendorRegister reg)
        {
            var rs = _context.Vendors.AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            if (rs == null)
            {
                return BadRequest("Not Found");
            }
            Vendor v = new Vendor()
            {
                Id = Id,
                Name = reg.Name ?? rs.Name,
                Email = reg.Email ?? rs.Email
            };
            _context.Vendors.Update(v);
            _context.SaveChanges();
            return Ok("Done");
        }

    }
}
