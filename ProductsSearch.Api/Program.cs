using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductsSearch.Api;
using ProductsSearch.Core;
using ProductsSearch.Repository;
using ProductsSearch.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductsCollectionConfig>(builder.Configuration.GetRequiredSection("ProductsCollectionConfig"));
builder.Services.AddSingleton<IValidateOptions<ProductsCollectionConfig>, ProductsCollectionConfigValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new RepositoryModule());
        builder.RegisterModule(new ServicesModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddProductEndpoints();
app.Run();