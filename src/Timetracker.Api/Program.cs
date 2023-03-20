using FastEndpoints;
using FastEndpoints.Swagger;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using NSwag;
using NSwag.AspNetCore;
using Timetracker.Application;
using Timetracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(
    s =>
    {
        s.AddAuth(
            "OAuth2",
            new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl =
                            $"https://login.microsoftonline.com/{config.GetSection("AzureAd").GetValue<string>("TenantId")}/oauth2/v2.0/authorize",
                        TokenUrl =
                            $"https://login.microsoftonline.com/{config.GetSection("AzureAd").GetValue<string>("TenantId")}/oauth2/v2.0/token",
                        Scopes = new Dictionary<string, string>
                        {
                            {
                                "api://a7c9672e-5357-494a-ba92-88f28cda925e/Customers.Read",
                                "Reads the customers"
                            },
                            {
                                "api://a7c9672e-5357-494a-ba92-88f28cda925e/Customers.ReadWrite",
                                "Reads and Write the customers"
                            },
                        },
                    },
                },
            });
    },
    addJWTBearerAuth: false);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(
        options =>
        {
            builder.Configuration.Bind("AzureAd", options);
            options.Events = new JwtBearerEvents();
        },
        options => { builder.Configuration.Bind("AzureAd", options); });

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(config);
builder.Services.AddProblemDetails(
    options =>
    {
        options.IncludeExceptionDetails = (_, _) => !builder.Environment.IsProduction();
    });

builder.Services.AddCors(
    o => o.AddPolicy(
        "default",
        policyBuilder =>
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
    ));

var app = builder.Build();

app.UseProblemDetails();
app.UseCors("default");
app.UseHttpsRedirection();

// app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(
    s =>
    {
        s.ConfigureDefaults();
        s.OAuth2Client = new OAuth2ClientSettings
        {
            AppName = "OAuth2",
            ClientId = config.GetSection("AzureAd").GetValue<string>("ClientId"),
            ClientSecret = config.GetSection("AzureAd").GetValue<string>("ClientSecret"),
        };
    });

app.Run();