using LegislativeInfoSystem.Components;
using LegislativeInfoSystem.Database;
using LegislativeInfoSystem.Entities;
using LegislativeInfoSystem.ServiceInterfaces;
using LegislativeInfoSystem.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));


builder.Services.AddScoped<ILegislatorService, LegislatorService>();
builder.Services.AddScoped<ILegislationService, LegislationService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var context = db.CreateDbContext();
    context.Database.Migrate();

    if (!context.Legislators.Any())
    {
        var legislators = new List<Legislator>
        {
            new() { FirstName = "Henry", LastName = "Rollins", Hometown = "Columbus" },
            new() { FirstName = "Syd", LastName = "Barrett", Hometown = "Cleveland" },
            new() { FirstName = "Lou", LastName = "Reed", Hometown = "Cincinnati" },
            new() { FirstName = "John", LastName = "Dwyer", Hometown = "Toledo" }
        };

        context.Legislators.AddRange(legislators);
        context.SaveChanges();

        var legislation = new List<Legislation>
        {
            new()
            {
                Title = "House Bill 101 - Sonic Aggression and Public Decency Act",
                LegislationText = "This bill establishes minimum decibel thresholds for public performances and prohibits the use of spoken word segments exceeding four minutes in duration at state-funded venues. Sponsored in response to escalating complaints from constituents regarding aggressive vocal delivery and unsanctioned flag burnings at civic events.",
                Sponsors = [legislators[0], legislators[1]]
            },
            new()
            {
                Title = "Senate Bill 42 - Psychedelic Imagery in Public Spaces Reform",
                LegislationText = "This bill regulates the display of swirling, kaleidoscopic, or otherwise disorienting visual art in state-owned public spaces. Findings indicate a statistically significant increase in prolonged staring and general confusion among constituents exposed to such imagery, particularly in the vicinity of Cleveland.",
                Sponsors = [legislators[2], legislators[3]]
            },
            new()
            {
                Title = "House Bill 217 - Velvet Underground Infrastructure Modernization Act",
                LegislationText = "This bill allocates funding for the rehabilitation of underground transit corridors across Ohio, with special attention to facilities described by inspectors as 'waiting for the man.' Provisions include mood lighting upgrades and a prohibition on banana-related signage in state transit hubs.",
                Sponsors = [legislators[0], legislators[2], legislators[3]]
            }
        };

        context.Legislation.AddRange(legislation);
        context.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
