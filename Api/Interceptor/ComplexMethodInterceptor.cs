using Entity.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Omu.ValueInjecter.Utils;
using System.Text;

namespace Api.Interceptor
{
    public class ComplexMethodInterceptor : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var specialMethod = context.ActionDescriptor.EndpointMetadata
            .FirstOrDefault(x => x.GetType() == typeof(ComplexArgumentProcessAttribute));
            if (specialMethod != null)
            {
                //获取需要转换的实体类。
                Type model = ((ComplexArgumentProcessAttribute)specialMethod).getMoel();

                string requestBody = await GetRequestBodyAsync(context);
                // 将请求体字符串转换为实体类
                var requestModel = JsonConvert.DeserializeObject(requestBody, model);

                // 将实体类注入到接口方法的参数对象中
                context.ActionArguments["requestModel"] = requestModel;
            }
            var resultContext = await next();
        }

        private async Task<string> GetRequestBodyAsync(ActionExecutingContext context)
        {
            using (var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }

}
