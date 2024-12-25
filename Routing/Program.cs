namespace Routing
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseRouting();
            Dictionary<int, string> countries = new Dictionary<int, string>(100);
            countries.Add(1, "United States");
            countries.Add(2, "Canada");
            countries.Add(3, "United Kingdom");
            countries.Add(4, "India");
            countries.Add(5, "Japan");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/countries", async (context) =>
                {
                    context.Response.StatusCode = 200;
                    foreach (KeyValuePair<int, string> country in countries)
                    {
                        await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
                    }
                });
                endpoints.MapGet("/countries/{countryID:int}", async (context) =>
                {
                    int id = Convert.ToInt32(context.Request.RouteValues["countryID"]);
                    if (id >= 1 && id <= 5)
                    {
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(countries[id]);
                    }
                    else if (id >= 6 && id <= 100)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync("[No Country]");
                    }
                    else if (id > 100)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("The CountryID should be between 1 and 100");

                    }

                });

            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("No response");
            });

            app.Run();
        }
    }
}


