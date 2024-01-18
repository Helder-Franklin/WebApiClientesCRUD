using WebApiClientes.Exceptions;
using WebApiClientes.Interfaces;
using WebApiClientes.Models;
using WebApiClientes.Repositories;
using WebApiClientes.Workers;

namespace WebApiClientes;

internal static class Program
{

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        #region workers/services
        services.AddSingleton<CustomerPfWorker>();
        services.AddSingleton<CustomerPjWorker>();
        services.AddSingleton(
            (s) =>
            {
                var dictionary = new Dictionary<CustomerType, ICustomerWorker>
                {
                { CustomerType.Pf, s.GetService<CustomerPfWorker>() ?? throw new CustomDependencyInjectionException($"Impossible to resolve type {nameof(CustomerPfWorker)}") },
                { CustomerType.Pj, s.GetService<CustomerPjWorker>() ?? throw new CustomDependencyInjectionException($"Impossible to resolve type {nameof(CustomerPjWorker)}")}
                };

                return dictionary;
            }
        );
        #endregion
        #region repositories
        services.AddSingleton<ICustomerPfRepository, CustomerPfRepository>();
        services.AddSingleton<ICustomerPjRepository, CustomerPjRepository>();
        #endregion
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        ConfigureServices(builder.Services);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.Run();
    }
}