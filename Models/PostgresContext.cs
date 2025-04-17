using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace armadieti2.Models;

public partial class PostgresContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public PostgresContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        DotNetEnv.Env.Load();
        var DataBaseVar = Environment.GetEnvironmentVariable("DATABASE");
        options.UseNpgsql(DataBaseVar);
    }
    public DbSet<Chiave> Chiaves { get; set; } = default!;

    public DbSet<Dipartimento> Dipartimentos { get; set; } = default!;
    public DbSet<Location> Locations { get; set; } = default!;
    public DbSet<Mobilio> Mobilios { get; set; } = default!;
    public DbSet<Movimento> Movimentos { get; set; } = default!;
    public DbSet<Noleggio> Noleggios { get; set; } = default!;
    public DbSet<Persona> Personas { get; set; } = default!;
    public DbSet<Statomobilio> Statomobilios { get; set; } = default!;
    public DbSet<Tipomobilio> Tipomobilios { get; set; } = default!;
    public DbSet<Tipopagamento> Tipopagamentos { get; set; } = default!;
    public DbSet<Tipopersona> Tipopersonas { get; set; } = default!;

}
