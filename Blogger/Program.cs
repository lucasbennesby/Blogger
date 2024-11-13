using Blogger.Contexto;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoBlogger>(options => 
    options.UseMySql(builder.Configuration.GetConnectionString("dbBlogger"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("dbBlogger"))));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Usuario Padrao", policy => policy.RequireRole("User"))
    .AddPolicy("Usuario Pro", policy => policy.RequireRole("UserPro"))
    ;

builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Publicacao}/{action=Index}/{id?}");

app.Run();
