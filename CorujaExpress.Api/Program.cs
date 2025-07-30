using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DOS SERVIÇOS ---

// **MUDANÇA AQUI**: Trocamos UseSqlServer por UseSqlite.
// O sistema agora usará um arquivo de banco de dados SQLite.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços para os controllers da API.
builder.Services.AddControllers();

// Adiciona a configuração de CORS (Cross-Origin Resource Sharing).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Adiciona serviços para documentação da API (Swagger), útil para testes.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Este comando agora funcionará.

var app = builder.Build();

// --- 2. CONFIGURAÇÃO DO PIPELINE HTTP ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Este comando agora funcionará.
    app.UseSwaggerUI(); // Este comando agora funcionará.
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

// **NOVO**: Garante que o banco de dados seja criado na inicialização.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();