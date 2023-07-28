using complete_applicaiton;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

//app.Use((context, next) =>
//{
//    context.Request.Scheme = "http";
//    return next(context);
//});

// Add this before any other middleware that might write cookies
app.UseCookiePolicy();

app.UseCookiePolicy(new CookiePolicyOptions
{
    Secure = CookieSecurePolicy.Always,
    //safari does not work if this is not set here and chrome works as well
    MinimumSameSitePolicy = SameSiteMode.Unspecified
});

startup.Configure(app, builder.Environment);
app.Run();