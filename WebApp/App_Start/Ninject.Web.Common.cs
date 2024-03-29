[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace WebApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Repository.Abstract;
    using Repository.Concrete;

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

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                    new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
                kernel.Bind<ICartsRepository>().To<CartsRepository>();
                kernel.Bind<IProductRepository>().To<ProductRepository>();
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            #region AutoMapper
            var config = new AutoMapper.MapperConfiguration(x => { x.AddProfile<AutoMapperConfig>(); });
            config.AssertConfigurationIsValid();
            kernel.Bind<AutoMapper.MapperConfiguration>().ToConstant(config);
            kernel.Bind<AutoMapper.IMapper>().ToConstant
                (kernel.Get<AutoMapper.MapperConfiguration>().CreateMapper());
            #endregion
            #region Repositories

            kernel.Bind<IProductRepository>().To<ProductRepository>();

            #endregion
        }
    }
}