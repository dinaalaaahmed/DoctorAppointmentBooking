using System.Diagnostics.CodeAnalysis;

namespace DoctorAppointmentBooking
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Build exited with error message: {ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseStartup<Startup>());
    }
}
