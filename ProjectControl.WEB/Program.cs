#region builder

using ProjectControl.DAL.Registrars;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(); //TODO: crutch
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();


#endregion

#region app

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
       .UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();

#endregion
