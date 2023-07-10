using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Model;
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
        /// <returns>返回集合<see cref="List{ItemVo}"/></returns>
        public List<ItemVo> getItems();
        /// <summary>
        /// 根据分类查找商品
        /// </summary>
        /// <param name="category">分类名</param>
        /// <returns></returns>
        public List<ItemVo> getItemByCategory(string category);
        /// <summary>
        /// 获取商品下评论列表
        /// </summary>
        /// <param name="item_id">商品id</param>
        /// <returns></returns>
        public List<Comment> getItemComments(Guid item_id);
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="comment">评论实体类</param>
        /// <returns></returns>
        public bool addComment(Comment comment);
    }
}
