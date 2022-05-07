using Cards.Dal.Contracts;
using Cards.Dal.Ef.Implememtation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DAL Service
//builder.Services.AddScoped(typeof(ICardsDalService), typeof(CardsDalService));
//builder.Services.AddDbContext<Cards.WebApi.CardsDalService>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDbConnectionString")));
builder.Services.AddSingleton(
    typeof(ICardsDalService),
    new CardsDalService(builder.Configuration.GetConnectionString("CardsDbConnectionString"))
    );


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

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
