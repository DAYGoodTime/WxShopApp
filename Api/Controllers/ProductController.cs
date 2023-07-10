using Entity.Model;
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
        private readonly ICategoryServices _categoryServices;

        public ProductController(
            IItemServices itemServices
            , ICategoryServices categoryServices)
        {
            _itemServices = itemServices;
            _categoryServices = categoryServices;
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
        /// <summary>
        /// 获取该分类下的所有商品
        /// 如果没有则返回空列表
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("{category}")]
        [HttpGet]
        public IActionResult getProductByCategory(string category)
        {
            return Json(RespRsult.OK(_itemServices.getItemByCategory(category)));
        }
        /// <summary>
        /// 获取全部分类
        /// </summary>
        /// <returns>集合<see cref="List{Category}"/></returns>
        [Route("categories")]
        [HttpGet]
        public IActionResult getCategories()
        {
            return Json(RespRsult.OK(_categoryServices.GetAllCategories()));
        }
        /// <summary>
        /// 获取商品下的评论
        /// </summary>
        /// <param name="productId">商品id</param>
        /// <returns></returns>
        [Route("{productId:guid}/comments")]
        [HttpGet]
        public IActionResult getComments(Guid productId)
        {
            return Json(RespRsult.OK(_itemServices.getItemComments(productId)));
        }
        /// <summary>
        /// 添加评论（只能使用multipart/form-data传输)
        /// 现在还没有实现图片处理
        /// </summary>
        /// <param name="files">多个二进制文件</param>
        /// <param name="comment">comment对象</param>
        /// <returns></returns>
        [Route("addComment")]
        [HttpPost]
        public IActionResult addComment([FromForm] IList<IFormFile> files, [FromForm] Comment comment)
        {
            //TODO 处理文件
            bool success = _itemServices.addComment(comment);
            if (success)
            {
                return Json(RespRsult.OK(comment));
            }
            else
            {
                return Json(RespRsult.Error("系统出错"));
            }
        }
    }
}
