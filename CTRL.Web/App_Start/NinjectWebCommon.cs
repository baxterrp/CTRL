[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CTRL.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CTRL.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CTRL.Web.App_Start
{
    using System;
    using System.Configuration;
    using System.Web;
    using CTRL.Core.Database;
    using CTRL.Core.Interfaces;
    using CTRL.Domain.Classes;
    using CTRL.Domain.Interfaces;
    using CTRL.Domain.Repositories;
    using CTRL.Login;
    using CTRL.Login.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CTRL"].ConnectionString;
            return connectionString;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var connectionString = GetConnectionString();
            kernel.Bind<IPasswordEncryption>().To<PasswordEncryption>().InSingletonScope();
            kernel.Bind<ILoginService>().To<LoginService>().InSingletonScope();
            kernel.Bind<IDatabaseConnection>().To<DatabaseConnection>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            kernel.Bind<ISetupsConfiguration>().To<SetupsConfiguration>().InSingletonScope();
            kernel.Bind<ISetupsRepository>().To<SetupsRepository>().InSingletonScope();
            kernel.Bind<ILoginRepository>().To<LoginRepository>().InSingletonScope();
            kernel.Bind<IAuthorizationRepository>().To<AuthorizationRepository>().InSingletonScope();
            kernel.Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            kernel.Bind<IRegistrationRepository>().To<RegistrationRepository>().InSingletonScope();
            kernel.Bind<IRegistrationService>().To<RegistrationService>().InSingletonScope();
        }        
    }
}
