using HRLeaveManagement.WebApp;
using HRLeaveManagement.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// HRLeaveManagement.WebApp/Program.cs
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<IleaveRequestService, leaveRequestService>();



builder.Services.AddScoped(sp =>
    new HttpClient
    {
        //https://localhost:7163 
       //BaseAddress = new Uri("https://localhost:5001/api/") // Your API base URL
        BaseAddress = new Uri("https://localhost:7163/api/") // Your API base URL
         //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

    });



await builder.Build().RunAsync();
