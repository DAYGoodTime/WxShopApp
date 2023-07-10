namespace WxsAppShop.Entity.Base
{
    public class BaseObject
    {
        public string title { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public Guid author_id { get; set; } = Guid.Empty;

        public string img_url { get; set; } = string.Empty;

        public DateTime create_time { get; set; } = DateTime.Now;

        public DateTime update_time { get; set;} = DateTime.Now;
    }
}
