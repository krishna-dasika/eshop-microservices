using Carter;
using Marten;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")??"");
    config.AutoCreateSchemaObjects = AutoCreate.All;

}).UseLightweightSessions();
builder.Services.AddLogging();
var app = builder.Build();

app.MapCarter();
//app.MapGet("/", () => "Hello World!");

app.Run();
