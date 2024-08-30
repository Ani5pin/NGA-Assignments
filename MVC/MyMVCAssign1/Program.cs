namespace MyMVCAssign1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/end"))
                {
                    await context.Response.WriteAsync("Terminating middleware pipeline.");
                    return;
                }
                await next();
            });

            // Middleware to display "hello1"
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello1 ");
                await next();
            });

            // Middleware to display "hello2"
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello2 ");
                await next();
            });

            // Middleware to display "hello" when URL contains "hello"
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("hello"))
                {
                    await context.Response.WriteAsync("hello ");
                }
                await next();
            });


           // app.UseHttpsRedirection();
          //  app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=First}/{action=Index1}/{id?}");
            });

            app.Run();
        }
    }
}
