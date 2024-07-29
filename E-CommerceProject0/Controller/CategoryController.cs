using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_CommerceProject0.Controller
{
    public class CategoryController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;

        public CategoryController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        [HttpGet("AllCategories")]
        public ActionResult getall()
        {
            var lst = _context.Categories.ToList();
            return Ok(lst);
        }
        [HttpPost("CertainCategory")]
        public ActionResult getbyid([FromForm] int id)
        {
            var res = _context.Categories.Find(id);
            if (res == null)
            {
                return BadRequest("Not Found");
            }
           var res1 =  _context.Products.Where(x=>x.CategoryId==id).FirstOrDefault();
            return Ok(res1);
        }
    }
}
