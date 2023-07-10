using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.Model;
using Entity.Vo;
using Omu.ValueInjecter;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class ItemServices : BaseServices<Item>, IItemServices
    {
        private readonly IBaseRepository<Item> itemrepository;
        private readonly IBaseRepository<ItemTagOptions> tagrepository;
        private readonly IBaseRepository<ItemSubOption> optionrepository;
        public ItemServices(
            IBaseRepository<Item> _itemrepository,
            IBaseRepository<ItemTagOptions> _itemtagrepository,
            IBaseRepository<ItemSubOption> _itemoptionrepository
            ) : base(_itemrepository)
        {
            this.itemrepository = _itemrepository;
            tagrepository = _itemtagrepository;
            optionrepository = _itemoptionrepository;
        }

        public List<ItemVo> getItems()
        {
            List<Item> items = itemrepository.SelectAll();
            List<ItemVo> res = new List<ItemVo>(items.Count);
            foreach (Item item in items)
            {
                ItemVo vo = new ItemVo().InjectFrom(item) as ItemVo;
                List<ItemTagOptions> tags = tagrepository.Select(t => t.item_id == item.item_id);
                foreach (ItemTagOptions tag in tags)
                {
                    tag.subOptions = optionrepository.Select(o => o.Tag_id == tag.option_tag_id);
                }
                vo.options = tags;
                res.Add(vo);
            }
            return res;
        }
    }
}
