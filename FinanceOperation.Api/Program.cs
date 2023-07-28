using FinanceOperation.Api.Core;
using FinanceOperation.Api.Infrastructure;
using FinanceOperation.Api.Infrastructure.Databases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
bool authEnabled = configuration.GetValue<bool>("Auth:Enabled");

builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    if (authEnabled)
    {
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
        });
        x.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
            }});
    }
});

builder.Services.AddCore();
builder.Services.AddInfrastucture(configuration);
if (authEnabled)
{
    _ = builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
    _ = builder.Services.AddAuthorization(options =>
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
    });
}

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

if (authEnabled)
{
    _ = app.UseAuthentication();
    _ = app.UseAuthorization();
}

app.MapControllers();
app.Services.MigrateDatabase();

app.Run();
