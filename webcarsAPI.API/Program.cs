
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
builder.Services.AddCors(options =>
      options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()));
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
