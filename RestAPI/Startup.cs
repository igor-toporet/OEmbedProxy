using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;

namespace OEmbedProxy.RestAPI
{
    // Note: By default all requests go through this OWIN pipeline. Alternatively you can turn this off by adding an appSetting owin:AutomaticAppStartup with value “false”. 
    // With this turned off you can still have OWIN apps listening on specific routes by adding routes in global.asax file using MapOwinPath or MapOwinRoute extensions on RouteTable.Routes
    public class Startup
    {
        // Invoked once at startup to configure your application.
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();

            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance using the RegisterWebApiRequest
            // extension from the integration package:
            container.RegisterWebApiRequest<IUserRepository, SqlUserRepository>();

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);

            container.Verify();

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);


            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute("Default", "", new { controller = "OEmbed" });

            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            ////config.Formatters.Remove(config.Formatters.XmlFormatter);
            // config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            builder.UseWebApi(config);


            //builder.Use(async (context, next) => {
            //    using (container.BeginExecutionContextScope())
            //    {
            //        await next();
            //    }
            //});
        }
    }

    public class SqlUserRepository:IUserRepository
    {
    }

    public interface IUserRepository
    {
    }
}