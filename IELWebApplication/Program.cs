using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Repositories;
using IELCadastroEstudante.Core.Repositories.Interface;
using IELCadastroEstudante.Core.Services;
using IELCadastroEstudante.Core.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Home/Index/"); //401 - Unauthorized
        options.AccessDeniedPath = new PathString("/Home/Index/"); //403 - Forbidden
    });


//builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddTransient<IEstudanteService, EstudanteService>();

builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<IEstadoService, EstadoService>();

builder.Services.AddTransient<ICidadeRepository, CidadeRepository>();
builder.Services.AddTransient<ICidadeService, CidadeService>();

builder.Services.AddTransient<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepository>(); 
builder.Services.AddTransient<IInstituicaoEnsinoService, InstituicaoEnsinoService>();


IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("IelCadastro")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Estudante}/{action=Index}/{id?}");

app.Run();
