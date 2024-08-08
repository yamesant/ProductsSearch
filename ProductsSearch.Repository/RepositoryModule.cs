using Autofac;

namespace ProductsSearch.Repository;

public sealed class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductsCollection>().As<IProductsCollection>().SingleInstance();
    }
}