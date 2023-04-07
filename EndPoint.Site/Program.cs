using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebStoreCore.Application.Interfaces.Contexts;
using WebStoreCore.Application.Interfaces.FacadPatterns;
using WebStoreCore.Application.Services.Carts;
using WebStoreCore.Application.Services.Common.Queries.GetCategory;
using WebStoreCore.Application.Services.Common.Queries.GetHomePageImages;
using WebStoreCore.Application.Services.Common.Queries.GetMenuItem;
using WebStoreCore.Application.Services.Common.Queries.GetSlider;
using WebStoreCore.Application.Services.Fainances.Commands.AddRequestPay;
using WebStoreCore.Application.Services.Fainances.Queries.GetRequestPayService;
using WebStoreCore.Application.Services.HomePages.AddHomePageImages;
using WebStoreCore.Application.Services.HomePages.AddNewSlider;
using WebStoreCore.Application.Services.Orders.Commands.AddNewOrder;
using WebStoreCore.Application.Services.Orders.Queries.GetOrdersForAdmin;
using WebStoreCore.Application.Services.Orders.Queries.GetUserOrders;
using WebStoreCore.Application.Services.Products.FacadPattern;
using WebStoreCore.Application.Services.Users.Commands.EditUser;
using WebStoreCore.Application.Services.Users.Commands.RegisterUser;
using WebStoreCore.Application.Services.Users.Commands.RemoveUser;
using WebStoreCore.Application.Services.Users.Commands.UserLogin;
using WebStoreCore.Application.Services.Users.Commands.UserSatusChange;
using WebStoreCore.Application.Services.Users.Queries.GetRoles;
using WebStoreCore.Application.Services.Users.Queries.GetUsers;
using WebStoreCore.Comon.Roles;
using WebStoreCore.Perstistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
//IRegisterUserService

builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();


string ConnectionString = @"Data Source=DESKTOP-IQ90JPA; Initial Catalog=WebStoreCoreDB; Integrated Security=True; TrustServerCertificate=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(ConnectionString));
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();


