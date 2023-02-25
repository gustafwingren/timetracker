using Hellang.Middleware.ProblemDetails;
using Timetracker.Application;
using Timetracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddProblemDetails(
    options =>
    {
        options.IncludeExceptionDetails = (_, _) => !builder.Environment.IsProduction();
    });
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();