using Gtk;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;

namespace TdP2019TPFinalRichieri
{
    using Util;
    using Services.Facade;
    using Mapper;

    public class Program
    {
        public static void Main(string[] args)
        {
            LogConfig.Init();
            // add the framework services
            var services = new ServiceCollection();
            services.AddSingleton<IMapperFactory, TriviaMapperFactory>();

            // add StructureMap
            var container = new StructureMap.Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });
                // Populate the container using the service collection
                config.Populate(services);
            });

            var serviceProvider = container.GetInstance<IServiceProvider>();

            Application.Init();

            var operativeServices = serviceProvider.GetService<IOperativeServices>();
            var backOfficeServices = serviceProvider.GetService<IBackOfficeServices>();

            TriviaApp triviaApp = new TriviaApp(operativeServices, backOfficeServices);
            LogInDialog logInDialog = new LogInDialog(triviaApp);
            logInDialog.Show();
            Application.Run();
        }
    }
}
