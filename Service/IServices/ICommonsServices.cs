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
    public interface ICommonsServices<TEntity> : IBaseServices<TEntity> , IScopedInterface
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll();
        /// <summary>
        /// 查询某个字段下的所有对象
        /// </summary>
        /// <param name="forging_key">字段id</param>
        /// <returns></returns>
        public List<TEntity> GetAll(Guid forging_key);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity_id">id</param>
        /// <returns></returns>
        public bool Remove(Guid entity_id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">对象</param>
        /// <returns></returns>
        public bool Add(TEntity entity);
        /// <summary>
        /// 查询某个对象
        /// </summary>
        /// <param name="entity_id">id</param>
        /// <returns></returns>
        public TEntity Get(Guid entity_id);
    }
}
