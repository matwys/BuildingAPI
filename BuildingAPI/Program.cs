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


app.MapGet("/api/buildings/{id}/height", async (BuildingsService buildingService, string id) =>
{
    var building = await buildingService.Get(id);
    return building is null ? Results.NotFound() : Results.Ok(building.calculateHeight());
});

app.MapGet("/api/buildings/{id}/floor/{number}/height", async (BuildingsService buildingService, string id, int number) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();
    foreach (var floor in building.Floors)
    {
        if (floor.Number == number) return Results.Ok(floor.calculateHeight());
    }
    return Results.NotFound();
});

app.MapGet("/api/buildings/{id}/floor/{number}/room/{roomNumber}/height", async (BuildingsService buildingService, string id, int number, int roomNumber) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();
    foreach (var floor in building.Floors)
    {
        if (floor.Number == number)
        {
            foreach (var room in floor.Rooms)
            {
                if (room.Number == roomNumber) return Results.Ok(room.calculateHeight());
            }
            return Results.NotFound();
        }
    }
    return Results.NotFound();
});

app.MapGet("/api/buildings/{id}/surface", async (BuildingsService buildingService, string id) =>
{
    var building = await buildingService.Get(id);
    return building is null ? Results.NotFound() : Results.Ok(building.calculateSurface());
});

app.MapGet("/api/buildings/{id}/floor/{number}/surface", async (BuildingsService buildingService, string id, int number) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();
    foreach (var floor in building.Floors)
    {
        if (floor.Number == number) return Results.Ok(floor.calculateSurface());
    }
    return Results.NotFound();
});

app.MapGet("/api/buildings/{id}/floor/{number}/room/{roomNumber}/surface", async (BuildingsService buildingService, string id, int number, int roomNumber) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();
    foreach (var floor in building.Floors)
    {
        if (floor.Number == number)
        {
            foreach (var room in floor.Rooms)
            {
                if (room.Number == roomNumber) return Results.Ok(room.calculateSurface());
            }
            return Results.NotFound();
        }
    }
    return Results.NotFound();
});

app.MapGet("/api/buildings/{id}/floor/{number}", async (BuildingsService buildingService, string id, int number) =>
{
    var building = await buildingService.Get(id);
    if(building is null) return Results.NotFound();
    foreach(var floor in building.Floors)
    {
        if (floor.Number == number) return Results.Ok(floor);
    }
    return Results.NotFound();
});

app.MapGet("/api/buildings/{id}/floor/{number}/room/{roomNumber}", async (BuildingsService buildingService, string id, int number, int roomNumber) =>
{
    var building = await buildingService.Get(id);
    if (building is null) return Results.NotFound();
    foreach (var floor in building.Floors)
    {
        if (floor.Number == number)
        {
            foreach (var room in floor.Rooms)
            {
                if (room.Number == roomNumber) return Results.Ok(room);
            }
            return Results.NotFound();
        }
    }
    return Results.NotFound();
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
