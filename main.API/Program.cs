using main.Repository;
using main.Service.Activities.Queries;
using main.Service.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

builder.Services.AddMediatR(options => {

    options.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>();

});

builder.Services.AddCors(options => {
    options.AddPolicy(
        "AzurePolicy",
        policy => 
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
var app = builder.Build();

app.UseCors("AzurePolicy");

app.UseHttpsRedirection();

app.MapControllers();

// implementing and using a service directly:
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    // will move existing migrations if there are any 
    // that haven't been applied yet
    await context.Database.MigrateAsync();
    // creating seed records
    await DbInitializer.SeedData(context);
}
catch (System.Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migrations");
}

app.Run();
