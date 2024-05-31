using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;
using Gym.Uninove.Data.Repository;
using Gym.Uninove.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddControllersWithViews().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});

// Autenticação JWT
var key = Encoding.ASCII.GetBytes(SettingsToken.Secret);
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        x.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwt"];
                return Task.CompletedTask;
            }
        };

    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy => policy.RequireRole("1")); // Role de Default
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("2")); // Role de Admin
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddScoped<GymContext, GymContext>();
builder.Services.AddScoped<ImageUploadService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IGymBranchRepository, GymBranchRepository>();
builder.Services.AddScoped<IGroupClassRepository, GroupClassRepository>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<GymContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultDatabase"),
    MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultDatabase"))));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var gymContext = services.GetRequiredService<GymContext>();

    // Aplicar migrações pendentes
    gymContext.Database.Migrate();

    // Instanciar e executar DataSeedService
    var dataSeedService = new DataSeedService(gymContext);
    dataSeedService.Seeding();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePages(context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == StatusCodes.Status403Forbidden || response.StatusCode == StatusCodes.Status401Unauthorized || response.StatusCode == StatusCodes.Status404NotFound)
    {
        response.Redirect("/User/AccessDenied");
    }

    return Task.CompletedTask;
});

app.UseStaticFiles();

app.UseRouting();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
