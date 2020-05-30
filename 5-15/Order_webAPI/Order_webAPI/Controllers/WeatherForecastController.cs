using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order_webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Order_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly OrderContext todoDb;

        //构造函数把OrderContext 作为参数，Asp.net core 框架可以自动注入OrderContext对象
        public TodoController(OrderContext context)
        {
            this.todoDb = context;
        }

        // GET: api/todo/{id}  id为路径参数
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(long id)
        {
            var Order = todoDb.Orders.FirstOrDefault(t => t.Id == id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }

        // GET: api/todo
        // GET: api/todo/pageQuery?name=课程&&isComplete=true
        [HttpGet]
        public ActionResult<List<Order>> GetOrders(string customerId, int? coffee_num, int? tea_num, int? milk_num)
        {
            var query = buildQuery(customerId, coffee_num, tea_num, milk_num);
            return query.ToList();
        }

        // GET: api/todo/pageQuery?skip=5&&take=10  
        // GET: api/todo/pageQuery?name=课程&&isComplete=true&&skip=5&&take=10
        [HttpGet("pageQuery")]
        public ActionResult<List<Order>> queryOrder(string customerId, int? coffee_num, int? tea_num, int? milk_num, int skip, int take)
        {
            var query = buildQuery(customerId, coffee_num, tea_num, milk_num).Skip(skip).Take(take);
            return query.ToList();
        }

        private IQueryable<Order> buildQuery(string customerId, int? coffee_num, int? tea_num, int? milk_num)
        {
            IQueryable<Order> query = todoDb.Orders;
            if (customerId != null)
            {
                query = query.Where(t => t.customerId.Contains(customerId));
            }
            if (coffee_num != null)
            {
                query = query.Where(t => t.coffee_num == coffee_num);
            }
            if (tea_num != null)
            {
                query = query.Where(t => t.tea_num == tea_num);
            }
            if (milk_num != null)
            {
                query = query.Where(t => t.milk_num == milk_num);
            }
            return query;
        }


        // POST: api/todo
        [HttpPost]
        public ActionResult<Order> PostOrder(Order todo)
        {
            try
            {
                todoDb.Orders.Add(todo);
                todoDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return todo;
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(long id, Order todo)
        {
            if (id != todo.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                todoDb.Entry(todo).State = EntityState.Modified;
                todoDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var todo = todoDb.Orders.FirstOrDefault(t => t.Id == id);
                if (todo != null)
                {
                    todoDb.Remove(todo);
                    todoDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}
