#region builder

using ProjectControl.DAL.Registrars;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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
