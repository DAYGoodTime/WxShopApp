using Api.Interceptor;
using Core.Base.DBContext;
using Core.Base.Implementation;
using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ComplexMethodInterceptor>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "微信小程序商店",
                    Version = "0.1b",
                    Description = "Power by ASP .Net 6.0"
                });
                var file = Path.Combine(AppContext.BaseDirectory, "Api.xml");  // xml文档绝对路径
                var path = Path.Combine(AppContext.BaseDirectory, file); // xml文档绝对路径
                c.IncludeXmlComments(path, true); // true : 显示控制器层注释
                c.OrderActionsBy(o => o.RelativePath); // 对action的名称进行排序，如果有多个，就可以看见效果了。
            });

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                string connStr = builder.Configuration.GetConnectionString("MySQLConnection");
                var ver = ServerVersion.AutoDetect(connStr);
                option.UseMySql(connStr, ver);
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {

                var allTypes = Assembly.Load(assemblyName).GetTypes();
                foreach (var type in allTypes)
                {
                    if (typeof(IScopedInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("IScopedInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddScoped(interfaceType, type);
                        }
                    }
                    else if (typeof(ISingletonInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ISingletonInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddSingleton(interfaceType, type);
                        }
                    }
                    else if (typeof(ITransientInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ITransientInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddTransient(interfaceType, type);
                        }
                    }
                }
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }
            app.UseSwagger();
            app.UseSwaggerUI();
            //启动Https路由转换
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}