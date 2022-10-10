using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using Simple.Common.Components.DataValidation;
using Simple.Common.Result;
using Simple.Common.Startup;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("�����С���");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.SimpleConfigure();

    // Add services to the container.

    builder.Services.AddControllers();


    var app = builder.Build();

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
