using MiddlewareLearning;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
// All aplications made starting as a console app


// MapGet is a method that used to map a request to a specific path
// app.MapGet("/", () => "Hello World!");


app.Use(async (context, next) =>
{
    // when we call next, we are calling the next middleware, so line 24 was jumped, and we go strit to line 31
    await next();
    // the line below only happen on the way out
    await context.Response.WriteAsync($"\n Status Code:{context.Response.StatusCode}");
});

            
app.Use(async (context, next) =>
{

    // some error occurs in this if statement
    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom parameter target middleware \n");
    }
    // else
    // {
    //     await context.Response.WriteAsync("If statement wrong \n");
    // }

    await next();

    await context.Response.WriteAsync("On my way out \n");
});


// // use QueryStringMiddleware
app.UseMiddleware<QueryStringMiddleware>();



app.Run(async context =>
{
    // context is the request and response
    await context.Response.WriteAsync("Terminal Middleware \n");
});


// app. Run is the last middleware that will be executed
app.Run();

