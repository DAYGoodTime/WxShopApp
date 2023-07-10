using Core.Base.Interface.Auto_registration;
using Core.Base.Interface;
using WxsAppShop.Entity.Model;
using Core.Base.Implementation;
using Entity.Schemas;
using Entity.Vo;
using Entity.Model;
using Entity.Base;

namespace Service.IServices
{
    public class OrderServices : BaseServices<Order>, IOrderServices
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<ItemSubOption> _optionRepository;
        public OrderServices(IBaseRepository<Order> baseRepository,
            IBaseRepository<ItemSubOption> itemSubOptionRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _optionRepository = itemSubOptionRepository;
        }

        public async Task<Bool> canCreateAsync(List<ItemSubOptionVo> processOrder)
        {
            return await Task.Run(async () =>
            {
                Bool success = new();
                List<ItemSubOption> updateList = new List<ItemSubOption>();
                foreach (ItemSubOptionVo item in processOrder)
                {
                    ItemSubOption option = await _optionRepository.FindAsync(o => o.option_id == item.option_id);
                    //计算库存是否足够
                    if (option.storage >= item.count)
                    {
                        option.storage = option.storage - item.count;
                        updateList.Add(option);
                    }
                    else
                    {
                        success.isSuccess = false;
                        success.reason = "库存不足";
                        break;
                    }
                }
                bool update = _optionRepository.Update(updateList);
                if (!update)
                {
                    //TODO using Logger later
                    Console.WriteLine("[Warn]:修改库存失败");
                    success.isSuccess = false;
                    success.reason = "修改库存失败";
                }
                return success;
            });
        }

        public bool createOrder(CreateOrder preOrder)
        {
            int count = preOrder.items.Count;
            List<Order> orders = new List<Order>(count);
            foreach (ItemSubOptionVo item in preOrder.items)
            {
                Order order = new Order()
                {
                    user_id = preOrder.user_id,
                    item_id = item.item_id,
                    total_price = item.option_price * item.count,
                    actual_price = item.option_price * item.count,
                    single_price = item.option_price,
                    option_id = item.option_id,
                    count = count
                };
                orders.Add(order);
            }
            return _orderRepository.Add(orders);
        }

        public List<Order> selectUserOrders(Guid userId)
        {
            return _orderRepository.Select(o => o.user_id == userId);
        }
    }
}