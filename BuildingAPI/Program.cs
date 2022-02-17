using BuildingAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<BuildingsDatabaseSettings>(builder.Configuration.GetSection("BuildingsDatabaseSettings"));
builder.Services.AddSingleton<BuildingsService>();

var app = builder.Build();

app.MapGet("/", () => "Buildings API!");

app.MapGet("/api/buildings", async (BuildingsService buildingService) => await buildingService.Get());

app.MapGet("/api/buildings/{id}", async (BuildingsService buildingService, string id) => 
    {
        var building = await buildingService.Get(id);
        return building is null ? Results.NotFound() : Results.Ok(building);
    });

app.MapPost("/api/buildings", async (BuildingsService buildingService, Building building) =>
    {
        await buildingService.Create(building);
        return Results.Ok();
    });

app.MapPut("/api/buildings/{id}", async (BuildingsService buildingService, string id, Building updateBuilding) =>
    {
        var building = await buildingService.Get(id);
        if(building is null) return Results.NotFound();
        updateBuilding.Id = building.Id;

        await buildingService.Update(id, updateBuilding);

        return Results.NoContent();
    });

app.MapDelete("/api/buildings/{id}", async (BuildingsService buildingService, string id) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();

    await buildingService.Remove(building.Id);

    return Results.NoContent();
});
app.Run();
