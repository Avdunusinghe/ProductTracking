using Autofac;
using ProductTracking.Business;

namespace ProductTracking.Api.Infrastructure
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .InstancePerLifetimeScope();
        }
    }
}
