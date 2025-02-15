using API;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Services.AddApiLayerServices();
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices();


var app = builder.Build();

//http pipeline
app.UseApiServices();


app.Run();
