using Core.Base.DBContext;
using Microsoft.AspNetCore.Mvc;
using WxsAppShop.Entity.Model;
using WxsAppShop.Entity.Base;
using EBike.Utils;
using Entity.Model;
using Omu.ValueInjecter;

namespace Api.Controllers
{
    [ApiController]
    [Route("mock/")]
    public class MockController : Controller
    {
        private readonly ApplicationDbContext appContext;
        public MockController(ApplicationDbContext _dbContext)
        {
            appContext = _dbContext;
        }
        private int mockingCount = 10;
        /// <summary>
        /// 模拟全部数据到数据库中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("mockAll")]
        public String mockingUser()
        {
            User lockUser = null;
            for (int i = 0; i < mockingCount; i++)
            {
                Random random = new Random();
                //mock user
                User user = new User
                {
                    user_name = i.ToString(),
                    user_password = HashUtils.HashStr(i.ToString() + "kel123")
                };

                //mock product 
                Item product = new Item
                {
                    item_display_price = (decimal)(random.NextDouble() * 1000),
                    item_name = i.ToString(),
                    item_description = "阿巴巴阿吧",
                    item_category = "正常分类",
                };
                //mock obj
                BaseObject obj = new BaseObject
                {
                    title = "一个标题",
                    description = "一些内容",
                    author_id = user.user_id
                };
                News news = (News)new News().InjectFrom(obj);
                Topic topic = (Topic)new Topic().InjectFrom(obj);
                Voice voice = (Voice)new Voice().InjectFrom(obj);
                Vote vote = (Vote)new Vote().InjectFrom(obj);
                news.news_id = Guid.NewGuid();
                topic.topic_id = Guid.NewGuid();
                voice.voice_id = Guid.NewGuid();
                voice.likes = random.Next(1000);
                vote.vote_id = Guid.NewGuid();
                vote.deadline_time = DateTime.Now;
                //mockOption
                //MainOption
                ItemTagOptions tag = new ItemTagOptions
                {
                    option_title = "选项" + i,
                    item_id = product.item_id
                };
                //subOption
                List<ItemSubOption> options = new(mockingCount);
                for (int j = 0; j < mockingCount; j++)
                {
                    ItemSubOption option = new ItemSubOption
                    {
                        option_name = "子选项" + i,
                        option_price = (decimal)(random.NextDouble() * 1000),
                        item_id = product.item_id,
                        storage = 100,
                    };
                    options.Add(option);
                }
                tag.subOptions = options;
                //mock Address
                if (lockUser == null)
                {
                    lockUser = user;
                }
                Address address = new Address
                {
                    user_id = lockUser.user_id,
                    address_title = "广东省东莞市某个镇",
                    address_context = "广东省东莞市某个镇某村某栋D316"
                };
                //mock Category
                Category category = new Category
                {
                    category_name = "分类" + i,
                    category_description = "一个一个分类"
                };
                //mock Order
                Order order = new Order
                {
                    user_id = lockUser.user_id,
                    total_price = (decimal)(random.NextDouble() * 1000),
                    actual_price = (decimal)(random.NextDouble() * 1000),
                    option_id = tag.subOptions[random.Next(0, tag.subOptions.Count)].option_id,
                    single_price = (decimal)(random.NextDouble() * 100)
                };
                //add to DB
                appContext.Add(user);
                appContext.Add(order);
                appContext.Add(address);
                appContext.Add(category);
                appContext.Add(product);
                appContext.Add(news);
                appContext.Add(voice);
                appContext.Add(vote);
                appContext.Add(topic);
                appContext.SaveChanges();
            }
            return "OK";
        }
    }
}
