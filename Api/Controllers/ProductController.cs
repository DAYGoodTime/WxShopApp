using Entity.Vo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using WxsAppShop.Entity.Base;

namespace Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IItemServices _itemServices;

        public ProductController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        /// <summary>
        /// 返回所有商品
        /// </summary>
        /// <returns>商品集合<see cref="List{ItemVo}"/></returns>
        [Route("getProducts")]
        [HttpGet]
        public IActionResult getAllProducts()
        {
            return Json(RespRsult.OK(_itemServices.getItems()));
        }
    }
}
