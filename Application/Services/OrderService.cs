using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.IServices;
using Domain.IRepositories;
using Microsoft.VisualBasic;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository order;
        public OrderService(IOrderRepository mydbcontext)
        {
            order = mydbcontext;
        }
        public async Task AddOrder(int userid)
        {
            await order.AddOrder(userid);   
        }

        public async Task AddOrderItem(int Carid, int orderid)
        {
            await order.AddOrderItem(Carid, orderid);
        }

        public async Task ConvertOrderToClose(int userid, int orderid)
        {
            await order.ConvertOrderToClose(userid, orderid);
        }

        public async Task<bool> IsAnyOrder(int userid)
        {
          return await order.IsAnyOrder(userid);
        }
    }
}
