using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace E_CommerceProject0.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;

        public ProductController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //[EnableCors("p1")]
        [HttpGet("AllProducts")]
        public ActionResult getall()
        {

            var lst = _context.Products.ToList();
            return Ok(lst);
        }

		[HttpPost("GetSpecificOrder")]
		public ActionResult getbyid([FromForm] int id)
		{
			var res = _context.Products.Find(id);
			if (res == null)
			{
				return BadRequest("Not Found");
			}
			var res1 = _context.Products.Where(x => x.Id == id).FirstOrDefault();
			return Ok(res1);
		}
		//[HttpPost("AddProduct")]
		//public ActionResult add(ProductAdder pa, IFormFile file)
		//{
		//    //using var dataStream = new MemoryStream();
		//    //pa.Image.CopyTo(dataStream);
		//    string fullPath = Directory.GetCurrentDirectory() + "/Images" + "/Products";


		//    string name = DateTime.Now.Ticks.ToString() + file.FileName;
		//    var stream = new FileStream(filePath, FileMode.Create);

		//    Product p = _mapper.Map<Product>(pa);
		//    //p.Image =dataStream.ToArray();
		//    _context.Products.Add(p);
		//    _context.SaveChanges();
		//    return Ok("Done");
		//}
		[HttpGet]
        [Route("api/images")]
        public IActionResult GetAllImages()
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images/Products";

            string[] files = Directory.GetFiles(fullPath);

            List<string> imageUrls = new List<string>();

            foreach (string file in files)
            {
                string imageUrl = Request.Scheme + "://" + Request.Host.Value + "/Images/Products/" + Path.GetFileName(file);
                imageUrls.Add(imageUrl);
            }

            return Ok(imageUrls);
        }

        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images" + "/Products";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filePath = fullPath + "/" + name;

            var stream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(stream);

            return Ok("Images/" + name);


        }
        //[HttpGet("getimage")]
        
        //public IActionResult GetImage()
        //{
        //    string fullPath = Directory.GetCurrentDirectory() + "/Images/Products/" ;

        //    if (!System.IO.File.Exists(fullPath))
        //    {
        //        return NotFound();
        //    }

        //    byte[] imageBytes = System.IO.File.ReadAllBytes(fullPath);

        //    return File(imageBytes, "image/jpeg");
        //}

        [HttpDelete("DeleteProduct")]
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

    }
}
