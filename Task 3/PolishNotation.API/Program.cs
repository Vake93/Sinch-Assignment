using Microsoft.OpenApi.Models;
using PolishNotation.API;
using PolishNotation.API.Extensions;

const string CorsPolicy = nameof(CorsPolicy);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: CorsPolicy,
        builder => builder.AllowAnyOrigin());
});

builder.Services.AddExpressionCache();

builder.Services.AddEndpointsApiExplorer();

var openapiInfo = builder.Configuration.GetSection("OpenApiInfo").Get<OpenApiInfo>();

builder.Services.AddSwaggerGen(options => options.SwaggerDoc("API", openapiInfo));

var app = builder.Build();

app.UseCors(CorsPolicy);

app.MapEndpoints();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/API/swagger.json", "Polish Notation API V1");
});

app.Execute();