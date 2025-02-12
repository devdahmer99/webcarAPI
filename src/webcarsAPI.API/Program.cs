using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using webcarsAPI.API.Filtros;
using webcarsAPI.Aplicacao;
using webcarsAPI.Infra;
using webcarsAPI.Infra.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfra(builder.Configuration);
builder.Services.AdicionaAplicacao();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddMediatR(typeof(Program).Assembly);

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
       
    });
}

app.UseCors(conexaoFront);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});
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
