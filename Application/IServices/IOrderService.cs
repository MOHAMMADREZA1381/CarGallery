using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IOrderService
    {
        Task<bool> IsAnyOrder(int userid);
        Task AddOrder (int userid);
        Task AddOrderItem(int Carid, int orderid);
        Task ConvertOrderToClose(int userid, int orderid);
    }
}
