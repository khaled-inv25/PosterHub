using Microsoft.AspNetCore.HttpOverrides;
using PosterHub.HttpApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.IISConfiguration();
builder.Services.ConfigurRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddControllers().AddApplicationPart(typeof(PosterHub.Presentation.AssemblyReference).Assembly);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthorization();
<<<<<<< HEAD
=======

>>>>>>> d6c7b22 (9/24)
/*
app.Map("/admin", builder =>
{
    builder.Run(async context =>
    {
        context.Response.Redirect("/admin");
        await Task.CompletedTask;
    });
});
app.Map("/path", builder =>
{
    builder.Run(async context =>
    {
        await context.Response.WriteAsync(Directory.GetCurrentDirectory());
    });
});
*/
<<<<<<< HEAD
=======

>>>>>>> d6c7b22 (9/24)
app.MapControllers();

app.Run();
