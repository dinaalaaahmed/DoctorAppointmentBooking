using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using DoctorAppointmentBooking.AppointmentBooking.DataAccess;
using DoctorAppointmentBooking.AppointmentBooking.UseCases;
using DoctorAppointmentBooking.AppointmentConfirmation.Services;
using DoctorAppointmentBooking.DoctorAppointmentManagement.DataAccess;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Services;
using DoctorAppointmentBooking.DoctorAvailability.DataAccess;
using DoctorAppointmentBooking.DoctorAvailability.Services;
using DoctorDbContext = DoctorAppointmentBooking.DoctorAvailability.DataAccess.DoctorDbContext;

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

            //Doctor Availability Setup :  Case 1

            services.AddScoped<DoctorAvailabilityService>();
            services.AddScoped<DoctorAppointmentRepository>();
            services.AddDbContext<DoctorDbContext>();

            //Confirm Appointment Setup : Case 3
            services.AddScoped<ConfirmAppointmentService>();
            services.AddScoped<NotificationService>();

            //Doctor Appointment Management Setup : Case 4
            services.AddScoped<IDoctorAppointmentManagementRepository, DoctorAppointmentManagementRepository>();
            services.AddScoped<IDoctorAppointmentManagementService, DoctorAppointmentManagementService>();
            services.AddDbContext<DoctorAppointmentManagement.DataAccess.AppointmentDbContext>();
            services.AddDbContext<DoctorAppointmentManagement.DataAccess.DoctorDbContext>();

            //Appointment Booking Setup :  Case 2
            services.AddScoped<IAppointmentBookingRepository, AppointmentBookingRepository>();
            services.AddScoped<BookAppointmentUseCase>();
            services.AddScoped<ViewDoctorAvailableSlotsUseCase>();
            services.AddDbContext<AppointmentBooking.DataAccess.DoctorDbContext>();
            services.AddDbContext<AppointmentBooking.DataAccess.AppointmentDbContext>();
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
