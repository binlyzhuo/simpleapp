using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Simple.Common.Components.DataValidation;
using Simple.Common.Components.DependencyInjection;
using Simple.Common.Result;
using Simple.Common.Services;
using Simple.Common.Startup;
using Simple.Common.Swagger;
using Simple.Repository.Extensions;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("启动中……");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    builder.SimpleConfigure();

    // Add services to the container.
    builder.Services.AddControllers();


    // Configure the HTTP request pipeline.
    builder.Services.AddControllers()
        .AddDataValidation()
        .AddAppResult(options =>
        {
            options.ResultFactory = resultException =>
            {
                // AppResultException 都返回 200 状态码
                var objectResult = new ObjectResult(resultException.AppResult);
                objectResult.StatusCode = StatusCodes.Status200OK;
                return objectResult;
            };
        });

    //builder.Services.AddEndpointsApiExplorer();

    // Swagger
    builder.Services.AddSimpleSwagger(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "简单三层接口文档v1", Version = "v1" });
    });

    // 仓储层
    builder.Services.AddRepository(configuration["ConnectionStrings:SqlServer"]);

    // 服务层：添加基础服务
    builder.Services.AddSimpleBaseServices();

    // 服务层：自动添加 Service 层以 Service 结尾的服务
    builder.Services.AddAutoServices("Simple.Services");

    var app = builder.Build();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "由于发生异常，导致程序中止！");
    throw;
}
finally
{
    logger.Debug("关闭中……");
    LogManager.Shutdown();
}
