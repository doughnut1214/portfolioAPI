using Newtonsoft.Json;
using portfolioAPI;
using static Postgrest.Constants;

var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["SupabaseKey"];
var url = builder.Configuration["SupabaseUrl"];

var app = builder.Build();



var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};

var supabase = new Supabase.Client(url, key, options);
await supabase.InitializeAsync();

app.MapGet("/", () => "test build");
app.MapGet("/projects", async () =>
{
    var result = await supabase.From<Projects>().Get();
    var projects = result.Models;
    if (!projects.Any()) return Results.NotFound();
    string json = JsonConvert.SerializeObject(projects);
    return Results.Ok(json);
});

app.MapGet("/projects/{id}", async (int id) =>
{
    var result = await supabase.From<Projects>()
    .Select("*")
    .Filter("id", Operator.Equals, id)
    .Single();
    var projects = result;
    if (projects == null) return Results.NotFound();
    string json = JsonConvert.SerializeObject(projects);
    
    return Results.Ok(json);
});



/* 
    new weirdness: API response looks weird in browser, but normal in console. Maybe issue with json plugin + serialization
    of newtonsoft? EDIT: Cors issue for testing 
 */

app.Run();
