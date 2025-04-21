using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;
        public OrderRepository(MyDbContext myDbContext)
        {
               _context = myDbContext;
        }
        public async Task AddOrder(int userid)
        {
            var ORDER = new Order();
            ORDER.UserId = userid;
            await _context.AddAsync(ORDER);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderItem(int Carid, int orderid)
        {
            OrderItem item = new OrderItem();
            item.OrderId = orderid;
            item.CarId = Carid;
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task ConvertOrderToClose(int userid, int orderid)
        {
            var order=await _context.Orders.Where(a=>a.UserId==userid&& a.Id==orderid).FirstOrDefaultAsync();
            order.State = BasketState.Close;
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsAnyOrder(int userid)
        {
            var order=await _context.Orders.AnyAsync(a=>a.UserId==userid);
            return order;
        }
    }
}
