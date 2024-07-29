using AutoMapper;
using E_CommerceProject0.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace E_CommerceProject0.Controller
{
    [ApiController]
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        E_CommerceContext _context;
        IMapper _mapper;


        public OrderController(E_CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("GetAllOrders")]
        public ActionResult get()
        {
            var lst = _context.Orders.ToList();
            return Ok(lst);
        }


        [HttpPost("AddOrder")]
        public ActionResult add(OrderDTO o)
        {
            Order order = _mapper.Map<Order>(o);
            order.UserId = o.UserId;
            order.CreatedDate = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();



            foreach (var item in o.OrderData)
            {
                OrderItem u = new OrderItem()
                {
                    ProductId = item.ProductId,
                    qty = item.qty
                };
                u.OrderId = order.Id;
                _context.Items.Add(u);
                _context.SaveChanges();
                //order.Items.Add(u);

            }
          
            return Ok("Done");
        }

        //[HttpPost("AddOrder")]
        //public ActionResult add(OrderDTO o)
        //{


        //    Order order = _mapper.Map<Order>(o);

        //    order.UserId = o.UserId;
        //    order.CreatedDate = DateTime.Now;
        //    _context.Orders.Add(order);
        //    _context.SaveChanges();

        //    foreach (var item in o.OrderData)
        //    {
        //        OrderItem u = new OrderItem();
        //        u.ProductId = item.ProductId;
        //        u.qty = item.qty;
        //        u.OrderId = order.Id;
        //        _context.Items.Add(u);
        //        _context.SaveChanges();

        //    }

        //    _context.Orders.Add(order);
        //    _context.SaveChanges();
        //    return Ok("Done");

        //}
        //[HttpDelete("DeleteOrder")]
        //public ActionResult delete(int id1)
        //{
        //    var res = _context.Orders.Find(id1);
        //    var res1 = _context.Items.Find(res);
        //    if (res == null)
        //    {
        //        return BadRequest("Not Found");
        //    }



        //    _context.Remove(res1);
        //    _context.Remove(res);
        //    _context.SaveChanges();
        //    return Ok("Done");
        //}
        [HttpDelete("DeleteOrder")]
        public ActionResult delete(int orderId)
        {
            // Find the order to delete
            Order orderToDelete = _context.Orders
                .Include(o => o.Items)
                .SingleOrDefault(o => o.Id == orderId);

            if (orderToDelete == null)
            {
                return NotFound();
            }

            // Remove the order's items from the context
            _context.Items.RemoveRange(orderToDelete.Items);

            // Remove the order from the context
            _context.Orders.Remove(orderToDelete);

            _context.SaveChanges();

            return Ok("Order deleted successfully.");
        }

    }
}
