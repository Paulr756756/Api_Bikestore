using API_PaulBikeStore.Utilities;

// Add services to the container.
// Configure Services of the Application
var builder = WebApplication.CreateBuilder(args);
builder.RegisterBusinessDependencies();
builder.RegisterAutoMapper();
builder.RegisterStandardDependencies();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseDefaultBuilderMethods();
app.Run();


