using Web.Api;

var builder = WebApplication.CreateBuilder(args);

// use controllers
builder.Services.AddControllers();
// Add Dependency Injections
builder.Services.AddWebApiDependencyInjection(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Server is listening...");
await app.InitializeMigration();
app.Run();
