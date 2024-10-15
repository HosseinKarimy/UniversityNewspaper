using API;
using Application;
using Carter;
using Infrastructure;
using Helper;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Services.AddApiLayerServices();
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices();
builder.Services.AddHelperServices();


var app = builder.Build();

//http pipeline
app.MapCarter();


app.Run();
