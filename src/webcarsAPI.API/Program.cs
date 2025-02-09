
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webcarsAPI.API.Filtros;
using webcarsAPI.Aplicacao;
using webcarsAPI.Infra;
using webcarsAPI.Infra.DataAccess;
using Scalar.AspNetCore;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Infra.Seguranca.JWT;
using webcarsAPI.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddOpenApi();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfra(builder.Configuration);
builder.Services.AdicionaAplicacao();
builder.Services.AddControllers();

var conexaoFront = "ConexaoFront";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: conexaoFront, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});


var signingKey = builder.Configuration.GetValue<string>("Settings:Jwt:SigningKey");
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
    };
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.Headers.Append("Access-Control-Allow-Origin", "http://localhost:5173");
        context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        context.Response.Headers.Append("Access-Control-Allow-Headers", "*");
        context.Response.Headers.Append("Access-Control-Allow-Credentials", "true");
        context.Response.StatusCode = 204;
        return;
    }
    await next();
});



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithHttpBearerAuthentication(options =>
        {
            var token = GetJwtTokenForUser();
            options.Token = token;
        });
    });
}
app.UseMiddleware<TokenBlackListMiddleware>();
app.UseCors(conexaoFront);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

ApplyMigrations(app);
app.Run();

void ApplyMigrations(IHost app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

string GetJwtTokenForUser()
{
    var usuario = new Usuario
    {
        Nome = "Eduardo",
        Identificador = Guid.NewGuid(),
        Permissao = "Admin"
    };
    var tokenGenerator = new JwtTokenGenerator(signingKey!, 1000);
    return tokenGenerator.Generate(usuario);
}
