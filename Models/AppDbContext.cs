using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using armadieti2.Models;


namespace armadieti2.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
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

        //ARMADI MODELS
        public DbSet<CategoriaArmadioModel> CategoriaArmadioModel { get; set; } = default!;
        public DbSet<ArmadioModel> ArmadioModel { get; set; } = default!;
        public DbSet<StatoChiaveModel> StatoChiaveModel { get; set; } = default!;
        public DbSet<ChiaveModel> ChiaveModel { get; set; } = default!;
        //NOLEGGI MODELS
        public DbSet<TipoPagamentoModel> TipoPagamentoModel { get; set; } = default!;
        public DbSet<NoleggioModel> NoleggioModel { get; set; } = default!;
        //Utenti models
        public DbSet<DipartimentoModel> DipartimentoModel { get; set; } = default!;
        public DbSet<TipoUtenteModel> TipoUtenteModel { get; set; } = default!;
        public DbSet<TipoUtenteModel> UtenteModel { get; set; } = default!;
        public DbSet<StatoArmadioModel> StatoArmadioModel { get; set; } = default!;
        public DbSet<UtenteModel> UtenteModel_1 { get; set; } = default!;
        public DbSet<armadieti2.Models.LocationModel> LocationModel { get; set; } = default!;

    }
}
