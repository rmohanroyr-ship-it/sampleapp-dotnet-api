var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container
builder.Services.AddControllers();

// Swagger / OpenAPI (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configure the HTTP request pipeline

// Enable Swagger only in Development (best practice)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP → HTTPS
app.UseHttpsRedirection();

// Authorization middleware (optional for now)
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Optional: Default home endpoint (so "/" works)
app.MapGet("/", () => "SampleApp is running 🚀");

// Start application
app.Run();
