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
    public interface IAddressService : IBaseServices<Address> , IScopedInterface
    {
        /// <summary>
        /// 查询该用户下所有地址类
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns>地址类集合</returns>
        public List<Address> SelectAllAddress(Guid user_id);
        /// <summary>
        /// 通过id查找地址
        /// </summary>
        /// <param name="address_id">地址id</param>
        /// <returns></returns>
        public Address SelectAddress(Guid address_id);

        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="address">地址类</param>
        /// <returns>是否添加成功</returns>
        public bool AddAddress(Address address);
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="address_id">地址</param>
        /// <returns></returns>
        public bool RemoveAddress(Guid address_id);
    }
}
