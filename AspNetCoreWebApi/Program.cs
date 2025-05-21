using MovieWebApi; // Assuming Startup is in this namespace or ensure using directive is present for Startup
using Microsoft.AspNetCore.Builder; // Required for WebApplication
using Microsoft.AspNetCore.Hosting; // Required for UseStartup

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel and IIS integration (though defaults are often sufficient with WebApplication.CreateBuilder)
// builder.WebHost.UseKestrel(); // Already configured by default
// builder.WebHost.UseIISIntegration(); // Already configured by default, but can be explicit

// Use Startup.cs for service configuration and request pipeline
builder.WebHost.UseStartup<Startup>();

var app = builder.Build();

app.Run();
