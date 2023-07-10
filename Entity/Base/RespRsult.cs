using Entity.Enum;

namespace WxsAppShop.Entity.Base
{
    public class RespRsult
    {
        public ResponseCode code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public RespRsult(ResponseCode code, string message, object data)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }

        public static RespRsult OK()
        {
            return new RespRsult(ResponseCode.OK, "操作成功", null);
        }
        public static RespRsult OK(object obj)
        {
            return new RespRsult(ResponseCode.OK, "操作成功", obj);
        }

        public static RespRsult Error(string message)
        {
            return new RespRsult(ResponseCode.ERROR, message, null);
        }
    }
}
