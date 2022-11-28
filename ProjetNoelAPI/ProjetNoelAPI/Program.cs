#region Builder

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.DataAccess.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

#region Cors

builder.Services.AddCors();

#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ent�tes d'autorisation JWT \r\n\r\n Tapez 'Bearer' [espace] et votre token dans l'input qui suis.\r\n\r\nExemple: \"Bearer 1safsfsdfdfd\"",
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[] {}
        }
    });
});

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var conf = new ApiSettings();
builder.Configuration.GetSection(nameof(ApiSettings)).Bind(conf);

#endregion

#region Jwt

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = conf.JwtIssuer,
        ValidateAudience = true,
        ValidAudience = conf.JwtAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf.JwtSecret))
    };
})
.AddCookie();

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region IOC

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<ISquadService, SquadService>();
builder.Services.AddTransient<IListeService, ListeService>();
builder.Services.AddTransient<IIdeaService, IdeaService>();
builder.Services.AddTransient<IJwtService,JwtService>();


#endregion


#region Database / DbContext
string? connexion = "";

#if DEBUG

connexion = builder.Configuration.GetConnectionString("sqlAzure");
builder.Services.AddDbContext<NoelDbContext>(options => options.UseSqlServer(connexion));

#endif

if (connexion == "")
{
    connexion = builder.Configuration.GetConnectionString("sqlAzure");
    connexion = Environment.GetEnvironmentVariable("");
    builder.Services.AddDbContext<NoelDbContext>(options => options.UseSqlServer(connexion));
}

var context = builder.Services.BuildServiceProvider().GetRequiredService<NoelDbContext>();

#endregion
#endregion

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();

#endregion
