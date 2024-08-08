using Microsoft.Extensions.Options;
using ProductsSearch.Api;
using ProductsSearch.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductsCollectionConfig>(builder.Configuration.GetRequiredSection("ProductsCollectionConfig"));
builder.Services.AddSingleton<IValidateOptions<ProductsCollectionConfig>, ProductsCollectionConfigValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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