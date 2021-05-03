using System;
using Unity.WebApi;
using System.Web.Http;
using WebAPI.App_Start.DiContainer;
using System.Linq;
using System.Web.Http.Filters;
using Unity;
using Service;

namespace WebAPI.DiContainer
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            var registerService = DiRegisterServices.GetServiceList();
            foreach (var item in registerService)
            {
                container.RegisterType(item.GetInterface(), item.GetClass());
            }

        }
        public static void Register(HttpConfiguration config)
        {
            //Register unity
            var container = new UnityContainer();

            RegisterTypes(container);

            config.DependencyResolver = new UnityResolver(container);

            //Register the filter injector
            var providers = config.Services.GetFilterProviders().ToList();

            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);
            config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));

        }
    }
}
