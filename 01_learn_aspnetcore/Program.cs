namespace URLShortener;

public class Program
{
    public static void Main(string[] args)
    {
        // This refers to an instance of "WebApplicationFactory" or "WebHostBuilder", which is used to
        // configure the ASP.NET Core application.
        var builder = WebApplication.CreateBuilder(args);

        // "Services" is a property of builder which provides access to the application's dependency
        // injection (DI) container, which is used to manage the application's services.
        //
        // This method is an extension method provided by ASP.NET Core that configures services for MVC,
        // including controllers and views. It registers services such as controller activation, view
        // components, and the Razor view engine.
        builder.Services.AddControllersWithViews();

        // This refers to the "IApplicationBuilder" instance, which is used to configure the ASP.NET
        // application's request pipeline.
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        // 
        // You can determine whether the application is running in the "development", "staging", or
        // "production" environments.
        //
        // By default, ASP.NET Core uses the "ASPNETCORE_ENVIRONMENT" environment variable.
        //
        // environment variable possible values:
        // "Development", "Staging", or "Production"
        //
        // IWebHostEnvironment interface in ASP.NET Core provides information about the web hosting
        // environment in which the application is running. This interface encapsulates information
        // such as the application's content root path, web root path, and the environment name.
        //
        if (!app.Environment.IsDevelopment())
        {
            // This refers to the "IApplicationBuilder" instance, which is used to configure the
            // ASP.NET Core application's request pipeline.
            //
            // "UseExceptionHandler()" is a method provided by the ASP.NET Core framework that
            // configures a middleware to handle exceptions globally. "/Home/Error" is the URL
            // path to which the application should redirect when an unhandled exception occurs.
            app.UseExceptionHandler("/Home/Error");
            
            
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            // Configures the HTTP Strict Transport Security (HSTS) middleware. HSTS is a security feature
            // that helps to protect websites against man-in-the-middle attacks such as protocol downgrade
            // attacks and cookie hijacking.
            //
            // When you call "app.UseHsts()", it adds the HSTS header to all HTTP responses. This header
            // informs the browser that the website should only be accessed over HTTPS (secure HTTP).
            // Once the browser receives this header, it will automatically redirect any HTTP requests
            // for the site to HTTPS, ensuring that all communication between the browser and the server
            // is encrypted.
            app.UseHsts();
        }

        // This is a method provided by the ASP.NET Core framework that configures middleware to redirect
        // HTTP requests to HTTPS.
        // 
        // The middleware intercepts HTTP requests and responds with an HTTP 302 status code (FOUND)
        // and a "Location" header containing the HTTPS URL corresponding to the original request.
        // This triggers the browser to automatically redirect to request to the HTTPS version of the URL.
        // This helps enforce secure communication between the client and the server by ensuring that
        // sensitive information is transmitted over a secure channel.
        app.UseHttpsRedirection();
        
        // This method is provided by the ASP.NET Core framework and configures middleware to serve static files
        // such as HTML, CSS, JavaScript, images, and other client-side assets directly to clients without any
        // processing by the server.
        //
        // The middleware is added to the request pipeline, allowing the ASP.NET Core application to serve static
        // files from the specified directory or directories. By default, it serves files from the "wwwroot"
        // directory in the application root, but you can configure it to serve files from other locations as well.
        //
        // This middleware is essential for web applications to serve static content efficiently and is commonly
        // used in ASP.NET Core projects to serve client-side assets required for rendering web pages.
        app.UseStaticFiles();

        // This method is provided by the ASP.NET Core framework and configures middleware to set up routing
        // for incoming requests.
        //
        // This middleware is added to the request pipeline, enabling the ASP.NET Core application to match
        // incoming HTTP requests to routes defined in the application. This middleware is a fundamental part
        // of ASP.NET Core's request processing pipeline and is responsible for determining which endpoint
        // (controller action) should handle each incoming request based on the URL path and other routing criteria.
        //
        // Use in conjunction with methods like "MapControllerRoute()" or "MapRazorPages()". These methods
        // define how incoming requests should be routed to controllers or Razor Pages within your application.
        app.UseRouting();

        // This method is provided by the ASP.NET Core framework and configures middleware to enable
        // authorization for incoming requests.
        //
        // This middleware is added to the request pipeline, enabling the ASP.NET Core application to enforce
        // authorization policies on incoming requests. Authorization determines whether a user is allowed to access
        // a particular resource or perform a specific action within the application.
        //
        // Authorization policies define the rules that specify who is allowed to access certain resources or
        // perform certain actions based on factors such as roles, claims, or other conditions (enforce
        // access control and security policies) to protect resources and ensure proper user authentication
        // and authorization.
        app.UseAuthorization();
        
        // This method is used to define a route for MVC controllers.
        //
        // This method sets up routing for MVC controllers within your application. It defines the URL
        // patterns that the application should recognize and the corresponding controllers and actions that
        // should handle incoming requests.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        // In ASP.NET Core, "app.Run()" is a terminal middleware that is used to handle the request
        // directly within the request pipeline. It is typically used as a last middleware in the pipeline
        // and is invoked when no other middleware before it can handle the request.
        //
        // This method can also be used to specify a delegate that will be invoked to handle the request.
        //
        // It is important to note that "Run()" method is terminal, meaning that it terminates the request
        // pipeline. As such, any middleware registered after "app.Run()" will not be invoked for the
        // current request.
        //
        // Typically, "app.Run()" is used for scenarios where you need to provide a fallback response
        // or handle requests that haven't been handled by earlier middleware in the pipeline. It's
        // commonly used for tasks like a 404 (Not Found) response or logging unhandled exceptions.
        app.Run();
    }
}