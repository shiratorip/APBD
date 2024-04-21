using SampleAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var _animals = new List<Animal>()
{
    new Animal{id =1, name = "Pikachu", category = "Pokemon",weight = 100, furColor = "yellow"},
    new Animal{id =2, name = "Eve", category = "Pokemon",weight = 80, furColor = "brown"},
    new Animal{id =3, name = "ditto", category = "Pokemon",weight = 120, furColor = "None"}
};
var _visits= new List<Visit>()
{
    new Visit{id =1, animal = Animal.GetAnimal(1), date = new DateTime(2024,1,1),description = "meow1",price = 120},
    new Visit{id =2, animal = Animal.GetAnimal(2), date = new DateTime(2024,1,1),description = "meow2",price = 110},
    new Visit{id =3, animal = Animal.GetAnimal(3), date = new DateTime(2024,1,1),description = "meow3",price = 80},
}; 

app.MapGet("/api/animals", () => Results.Ok(_animals))
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapGet("/api/visits", () => Results.Ok(_animals))
    .WithName("GetVisits")
    .WithOpenApi();

app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = _animals.FirstOrDefault(a => a.id == id);
        return animal == null ? Results.NotFound($"Animals with id {id} was not found") : Results.Ok(animal);
    })
    .WithName("GetAnimals")
    .WithOpenApi();
app.MapGet("/api/visits/{id:int}", (int id) =>
    {
        var visit = _visits.FirstOrDefault(v => v.id == id);
        return visit == null ? Results.NotFound($"Visits with id {id} was not found") : Results.Ok(visit);
    })
    .WithName("GetVisits")
    .WithOpenApi();

app.MapPost("/api/animals", (Animal animal) =>
    {
        _animals.Add(animal);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("CreateAnimal")
    .WithOpenApi();

app.MapPost("/api/visits", (Visit visit) =>
    {
        _visits.Add(visit);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("CreateVisit")
    .WithOpenApi();

app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
    {
        var animalToEdit = _animals.FirstOrDefault(a=>a.id == id);
        if (animalToEdit == null)
        {
            return Results.NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return Results.NoContent();
    })
    .WithName("UpdateAnimal")
    .WithOpenApi();

app.MapPut("/api/visits/{id:int}", (int id, Visit visit) =>
    {
        var visitToEdit = _visits.FirstOrDefault(v=>v.id == id);
        if (visitToEdit == null)
        {
            return Results.NotFound($"Visits with id {id} was not found");
        }

        _visits.Remove(visitToEdit);
        _visits.Add(visit);
        return Results.NoContent();
    })
    .WithName("UpdateVisit")
    .WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        var animalToDelete = _animals.FirstOrDefault(a=>a.id == id);
        if (animalToDelete == null)
        {
            return Results.NoContent();
        }

        _animals.Remove(animalToDelete);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal")
    .WithOpenApi();

app.MapDelete("/api/visits/{id:int}", (int id) =>
    {
        var visitToDelete = _visits.FirstOrDefault(v=>v.id == id);
        if (visitToDelete == null)
        {
            return Results.NoContent();
        }

        _visits.Remove(visitToDelete);
        return Results.NoContent();
    })
    .WithName("DeleteVisit")
    .WithOpenApi();

app.Run();