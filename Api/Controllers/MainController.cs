using Core.Base.DBContext;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using WxsAppShop.Entity.Base;
using WxsAppShop.Entity.Model;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api")]
    public class MainController : Controller
    {
        private readonly ApplicationDbContext context;

        public MainController(ApplicationDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// 测试接口，获取全部用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            List<User> users = context._user.ToList();
            return Json(RespRsult.OK(users));
        }
    }
}
