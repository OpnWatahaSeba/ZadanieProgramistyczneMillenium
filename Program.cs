using Microsoft.AspNetCore.HttpLogging;
using ZadanieProgramistyczneMillenium.Infrastructure;
using ZadanieProgramistyczneMillenium.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardAllowedActionService, CardAllowedActionService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestMethod
                          | HttpLoggingFields.RequestPath
                          | HttpLoggingFields.ResponseStatusCode;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
