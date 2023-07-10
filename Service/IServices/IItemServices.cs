using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Service.IServices
{
    public interface IItemServices : IBaseServices<Item>, IScopedInterface
    {
        /// <summary>
        /// 获取全部商品
        /// </summary>
        /// <returns>返回集合<see cref="Lazy{ItemVo}"/></returns>
        public List<ItemVo> getItems();
    }
}
