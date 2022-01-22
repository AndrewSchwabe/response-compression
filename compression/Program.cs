var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the required compression components in the DI container
builder.Services.AddResponseCompression();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure API to use the compression middleware
app.UseResponseCompression();

app.MapGet("/content", () =>
{
    return System.IO.File.ReadAllText("content.txt", System.Text.Encoding.UTF8);
})
.WithName("getContent");

app.Run();
