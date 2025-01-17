var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Teacher> teachers = [
new() {Name = "Skoogen"},
new() {Name = "Micke"},
new() {Name = "Alex"},
new() {Name = "Martin"},
];

// 10.151.168.93:5005

app.Urls.Add("http://localhost:5005/");
app.Urls.Add("http://*:5005/");

app.MapGet("/", GetHello);
app.MapGet("/teacher", GetTeachers);
app.MapGet("/teacher/ {n}", GetTeacher);

app.Run();


List<Teacher> GetTeachers()
{
    return teachers;
}

IResult GetTeacher(int n)
{
    if (n < 0 || n >= teachers.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(teachers[n]);
}

static string GetHello()
{
    return "Hello";
}