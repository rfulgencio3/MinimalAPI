using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Config>(new Config("configutarion"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/teams", ([FromServices] Config config) =>
{
    var teams = new List<Team>
    {
        new Team("Cruzeiro Esporte Clube", "Belo Horizonte", "Brazil"),
        new Team("São Paulo Futebol Clube", "São Paulo", "Brazil"),
        new Team("Club Atletico Peñarol", "Montevideo", "Uruguay"),
        new Team("Real Madrid CF", "Madrid", "Spain"),
        new Team("Galatasaray Spor Kulübü", "Istanbul", "Turkey")
    };

    return Results.Ok(teams);
})
.WithName("GetTeams");

app.Run();

internal record Team(string name, string city, string country)
{ }

internal record Config(string Url)
{ }