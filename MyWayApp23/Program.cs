using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using MyWayApp23.Areas.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeAreaFolder("Identity", "/Admin", "adminsOnly");
    options.Conventions.AllowAnonymousToPage("/Identity/Account/Login");
});

builder.Services.AddServerSideBlazor();

// Add Identity services, order is important, factory first!
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
if (cs != null)
{
    builder.Services.AddDbContextFactory<DataContext>(options => options.UseSqlServer(cs));
    builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
}

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 4;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("uhs", policy => policy.RequireClaim("uh", "LIS"));
    options.AddPolicy("adminsOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("lisOnly", policy => policy.RequireRole("Lis"));
    options.AddPolicy("opoOnly", policy => policy.RequireRole("Opo"));
    options.AddPolicy("faoOnly", policy => policy.RequireRole("Fao"));
    options.AddPolicy("fncOnly", policy => policy.RequireRole("Fnc"));
});

builder.Services.AddScoped<AuthenticationStateProvider,
    IdentityValidationProvider<IdentityUser>>();

builder.Services.AddMudServices();

builder.Services.AddScoped<IReadExcelService, ReadExcelService>();
builder.Services.AddScoped<IDataTableConverter, DataTableConverter>();
builder.Services.AddScoped<IAssistenciaService, AssistenciaService>();
builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IHistoricoDetalheService, HistoricoDetalheService>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
