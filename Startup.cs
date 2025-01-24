using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using DoctorAppointmentBooking.DataAccess;
using DoctorAppointmentBooking.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddHealthChecks();
            services.AddScoped<DoctorAvailabilityService>();
            services.AddScoped<DoctorAppointmentRepository>();
            services.AddScoped<IDoctorAppointmentManagementRepository, DoctorAppointmentManagementRepository>();
            services.AddScoped<IDoctorAppointmentManagementService, DoctorAppointmentManagementService>();
            services.AddDbContext<DoctorDbContext>();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
