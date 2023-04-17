global using BioTranan.Client.Services.MovieService;
global using BioTranan.Shared;
global using System.Net.Http.Json;
using BioTranan.Client;
using BioTranan.Client.Services.BookingService;
using BioTranan.Client.Services.ShowService;
using BioTranan.Client.Services.TheaterService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ITheaterService, TheaterService>();
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IBookingService, BookingService>();

await builder.Build().RunAsync();
