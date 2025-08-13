using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Hubs;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Repository;
using TournamentSystem.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITournamentRepository,TournamentRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayInTournamentRepository, PlayInTournamentRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();  
builder.Services.AddScoped<ISearchService,SearchService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<MatchHub>("/matchHub");

app.Run();
