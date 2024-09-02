namespace TaskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //  builder.WebHost.UseUrls("http://localhost:5022");

            // Add services to the container.
            builder.Services.AddControllers();

            // Add database configuration.
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
