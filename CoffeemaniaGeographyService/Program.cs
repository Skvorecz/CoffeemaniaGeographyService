using System.Reflection;
using CoffeemaniaGeographyService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

AddServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Distance API"); });

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddSingleton<IDistanceService, DistanceService>();
}