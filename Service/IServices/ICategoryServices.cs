using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ICategoryServices : IBaseServices<Category>, IScopedInterface
    {
        /// <summary>
        /// 查询所有分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories();
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="categoryId">分类id</param>
        /// <returns></returns>
        public bool RemoveCategory(Guid categoryId);
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="category">分类对象</param>
        /// <returns></returns>
        public bool AddCategory(Category category);
        /// <summary>
        /// 查询某个分类
        /// </summary>
        /// <param name="categoryId">分类id</param>
        /// <returns></returns>
        public Category GetCategory(Guid categoryId);
    }
}
