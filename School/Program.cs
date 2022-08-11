using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.BL;
using School.BL.Interface;
using School.BL.Mapper;
using School.BL.Repo;
using School.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Connection String
string connString = builder.Configuration.GetConnectionString("MooConnection");

//sql server
builder.Services.AddDbContextPool<SchoolContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("MooConnection"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
);
//AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

//scoped Instance
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITeacherClassRepo,TeacherClassRepo>();
builder.Services.AddScoped<IClass, ClassRepo>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
              CookieAuthenticationDefaults.AuthenticationScheme, option =>
              {
                  option.LoginPath = new PathString("/Account/login");
                  option.AccessDeniedPath = new PathString("/Account/login");
              }
              );

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Default Password settings.
    //options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<SchoolContext>()
       .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=account}/{action=login}/{id?}");

app.Run();
