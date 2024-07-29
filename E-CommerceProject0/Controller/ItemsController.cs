using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
namespace E_CommerceProject0.Controller
{
    [ApiController]
    [Route("OrderItems")]
    public class ItemsController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;
        public ItemsController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAllItems")]
        public ActionResult get()
        {
            var lst = _context.Items.ToList();
            return Ok(lst);
        }

    }
}
