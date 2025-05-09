var builder = WebApplication.CreateBuilder(args); // tworzy builder aplikacji


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dodaje kontrolery do buildera
builder.Services.AddControllers();

var app = builder.Build(); // buduje aplikacje

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // przekierowuje HTTP na HTTPS (wylaczone)

// mapuje wszystkie koncowki z kontrolerow
app.MapControllers();

app.Run(); // uruchamia aplikacje