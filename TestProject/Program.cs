var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") =="Development")
{
    Console.WriteLine("yssss3");
    DotNetEnv.Env.Load("MY.env");
DotNetEnv.Env.Load("MY2.env");
Console.WriteLine("TEST IS_ " + Environment.GetEnvironmentVariable("TEST"));
Console.WriteLine("TEST2 IS_ " + Environment.GetEnvironmentVariable("TEST2"));
Console.WriteLine("TEST3 IS_ " + Environment.GetEnvironmentVariable("TEST3"));
Console.WriteLine("TEST4 IS_ " + Environment.GetEnvironmentVariable("TEST4"));
}
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
