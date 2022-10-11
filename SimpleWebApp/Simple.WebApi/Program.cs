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
logger.Debug("�����С���");

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
                // AppResultException ������ 200 ״̬��
                var objectResult = new ObjectResult(resultException.AppResult);
                objectResult.StatusCode = StatusCodes.Status200OK;
                return objectResult;
            };
        });

    //builder.Services.AddEndpointsApiExplorer();

    // Swagger
    builder.Services.AddSimpleSwagger(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "������ӿ��ĵ�v1", Version = "v1" });
    });

    // �ִ���
    builder.Services.AddRepository(configuration["ConnectionStrings:SqlServer"]);

    // ����㣺��ӻ�������
    builder.Services.AddSimpleBaseServices();

    // ����㣺�Զ���� Service ���� Service ��β�ķ���
    builder.Services.AddAutoServices("Simple.Services");

    var app = builder.Build();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "���ڷ����쳣�����³�����ֹ��");
    throw;
}
finally
{
    logger.Debug("�ر��С���");
    LogManager.Shutdown();
}
