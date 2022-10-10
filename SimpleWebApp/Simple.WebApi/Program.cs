using NLog;
using NLog.Web;
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
