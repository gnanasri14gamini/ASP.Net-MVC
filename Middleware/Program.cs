namespace Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<logginMiddleware>();

            var app = builder.Build();

            app.UseMiddleware<logginMiddleware>();

            app.Run();
        }
    }
}
