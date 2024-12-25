
using System.Text.Json;

public class logginMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        if (context.Request.Method.Equals("GET"))
        {
            context.Response.StatusCode = 200;
            return context.Response.WriteAsync("No response");
        }
        else
        {
            using (var reader = new StreamReader(context.Request.Body))
            {
                var data = reader.ReadToEndAsync().Result;
                context.Response.StatusCode = 400;
                if (data == "")
                {
                    return context.Response.WriteAsync("Invalid input for 'email'\r\nInvalid input for 'password'");
                }
                else
                {
                    if (data.Contains("email") && data.Contains("password"))
                    {
                        if (data.Equals("email=admin@example.com&password=admin1234"))
                        {
                            context.Response.StatusCode = 200;
                            return context.Response.WriteAsync("Successful login");
                        }
                        return context.Response.WriteAsync("Invalid login");
                    }
                    else if (data.Contains("email") && !data.Contains("password"))
                    {
                        return context.Response.WriteAsync("Invalid input for 'password'");
                    }
                    else if (!data.Contains("email") && data.Contains("password"))
                    {
                        return context.Response.WriteAsync("Invalid input for 'email'");
                    }

                    return context.Response.WriteAsync("Invalid");

                }

            }
        }
       

    }
   
}