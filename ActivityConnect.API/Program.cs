using ActivityConnect.Business;
using ActivityConnect.Business.DependencyResolvers.Autofac;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Utilities.Security.Encryption;
using ActivityConnect.DataAccess;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyResolver();
//Autofac Dependency ve Aspect Çözümü
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbConnectionServices();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();
//jwt Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
            ValidAudience = builder.Configuration["TokenOptions:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(builder.Configuration["TokenOptions:SecurityKey"])
        };
    });

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("ActivityConnect", new OpenApiInfo
    {
        Version = "v1",
        Title = "ActivityConnect API",
        Description = "A simple example ASP.NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Emre Dindar",
            Email = "emredindr@gmail.com",
            Url = new Uri("https://emredindr.github.io"),
        },
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/ActivityConnect/swagger.json", "ActivityConnect API");
    });
}


app.UseApiResponseAndExceptionWrapper();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.Run();
