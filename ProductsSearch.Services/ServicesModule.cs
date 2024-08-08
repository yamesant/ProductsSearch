using Autofac;

namespace ProductsSearch.Services;

public sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductService>().As<IProductService>();
    }
}