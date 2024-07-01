using Quartz;
using SchedulerApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddQuartz(options =>
{
    var key = JobKey.Create(nameof(PrintJob));
    options.AddJob(typeof(PrintJob), key).AddTrigger(x => x.ForJob(key).WithCronSchedule("*/5 * * * * ?").StartNow());
});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
    options.AwaitApplicationStarted = true;
});

var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
