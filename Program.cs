using portfolioAPI;
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
    Console.WriteLine(projects);
    return projects;
});
/* 
    error: The type 'Postgrest.Attributes.PrimaryKeyAttribute' is not a supported
    dictionary key using converter of type
    'System.Text.Json.Serialization.Converters.SmallObjectWithParameterizedConstructorConverter`
    5[Postgrest.Attributes.PrimaryKeyAttribute,System.String,System.Boolean,System.Object,System.Object]'.

    possible solution: nuget Newtonsoft package for its serialization 
 */

app.Run();
