using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.Base;
using Entity.Model;
using Entity.Vo;
using Omu.ValueInjecter;
using Service.IServices;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class ItemServices : BaseServices<Item>, IItemServices
    {
        private readonly IBaseRepository<Item> itemrepository;
        private readonly IBaseRepository<ItemTagOptions> tagrepository;
        private readonly IBaseRepository<ItemSubOption> optionrepository;
        private readonly IBaseRepository<Order> orderRepository;
        private readonly IBaseRepository<Category> categoryRepository;
        private readonly IBaseRepository<Comment> commentRepository;
        public ItemServices(
            IBaseRepository<Item> _itemrepository,
            IBaseRepository<ItemTagOptions> _itemtagrepository,
            IBaseRepository<ItemSubOption> _itemoptionrepository,
            IBaseRepository<Order> orderRep,
            IBaseRepository<Category> cateRep,
            IBaseRepository<Comment> commentRep
            ) : base(_itemrepository)
        {
            itemrepository = _itemrepository;
            tagrepository = _itemtagrepository;
            optionrepository = _itemoptionrepository;
            orderRepository = orderRep;
            categoryRepository = cateRep;
            commentRepository = commentRep;
        }

        public bool addComment(Comment comment)
        {
            return commentRepository.Add(comment);

        }

        public List<ItemVo> getItemByCategory(string category)
        {
            Category? categoryObj = categoryRepository.Find(c => c.category_name == category);
            if (categoryObj == null)
            {
                return new List<ItemVo>(0);
            }
            return ToVo(itemrepository.Select(i => i.item_category == categoryObj.category_name));
        }

        public List<Comment> getItemComments(Guid item_id)
        {
            return commentRepository.Select(c => c.item_id == item_id);
        }

        public List<ItemVo> getItems()
        {
            List<Item> items = itemrepository.SelectAll();
            return ToVo(items);
        }

        private ItemVo ToVo(Item item)
        {
            ItemVo vo = new ItemVo().InjectFrom(item) as ItemVo;
            List<ItemTagOptions> tags = tagrepository.Select(t => t.item_id == item.item_id);
            foreach (ItemTagOptions tag in tags)
            {
                tag.subOptions = optionrepository.Select(o => o.Tag_id == tag.option_tag_id);
            }
            vo.options = tags;
            //这里销量按有人下单就算+
            vo.Sales = orderRepository.Select(o => o.item_id == item.item_id).Count;
            return vo;
        }
        private List<ItemVo> ToVo(List<Item> items)
        {
            List<ItemVo> res = new List<ItemVo>(items.Count);
            foreach (Item item in items)
            {
                res.Add(ToVo(item));
            }
            return res;
        }
    }
}
