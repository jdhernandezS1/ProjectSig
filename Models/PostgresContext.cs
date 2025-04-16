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

    public virtual DbSet<Chiave> Chiaves { get; set; }

    public virtual DbSet<Dipartimento> Dipartimentos { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Mobilio> Mobilios { get; set; }

    public virtual DbSet<Movimento> Movimentos { get; set; }

    public virtual DbSet<Noleggio> Noleggios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Statomobilio> Statomobilios { get; set; }

    public virtual DbSet<Tipomobilio> Tipomobilios { get; set; }

    public virtual DbSet<Tipopagamento> Tipopagamentos { get; set; }

    public virtual DbSet<Tipopersona> Tipopersonas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chiave>(entity =>
        {
            entity.HasKey(e => e.Numerochiave).HasName("chiave_pkey");

            entity.ToTable("chiave");

            entity.Property(e => e.Numerochiave)
                .ValueGeneratedNever()
                .HasColumnName("numerochiave");
        });

        modelBuilder.Entity<Dipartimento>(entity =>
        {
            entity.HasKey(e => e.Nomedipartimento).HasName("dipartimento_pkey");

            entity.ToTable("dipartimento");

            entity.Property(e => e.Nomedipartimento)
                .HasMaxLength(50)
                .HasColumnName("nomedipartimento");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Idlocation).HasName("location_pkey");

            entity.ToTable("location");

            entity.HasIndex(e => new { e.Stabile, e.Piano }, "location_stabile_piano_key").IsUnique();

            entity.Property(e => e.Idlocation).HasColumnName("idlocation");
            entity.Property(e => e.Piano)
                .HasMaxLength(50)
                .HasColumnName("piano");
            entity.Property(e => e.Stabile)
                .HasMaxLength(50)
                .HasColumnName("stabile");
        });

        modelBuilder.Entity<Mobilio>(entity =>
        {
            entity.HasKey(e => e.Idmobilio).HasName("mobilio_pkey");

            entity.ToTable("mobilio");

            entity.HasIndex(e => new { e.Idlocation, e.Numero }, "mobilio_idlocation_numero_key").IsUnique();

            entity.Property(e => e.Idmobilio).HasColumnName("idmobilio");
            entity.Property(e => e.Idlocation).HasColumnName("idlocation");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Numerochiave).HasColumnName("numerochiave");
            entity.Property(e => e.Statomobilio)
                .HasMaxLength(50)
                .HasColumnName("statomobilio");
            entity.Property(e => e.Tipomobilio)
                .HasMaxLength(50)
                .HasColumnName("tipomobilio");

            entity.HasOne(d => d.IdlocationNavigation).WithMany(p => p.Mobilios)
                .HasForeignKey(d => d.Idlocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobilio_idlocation_fkey");

            entity.HasOne(d => d.NumerochiaveNavigation).WithMany(p => p.Mobilios)
                .HasForeignKey(d => d.Numerochiave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobilio_numerochiave_fkey");

            entity.HasOne(d => d.StatomobilioNavigation).WithMany(p => p.Mobilios)
                .HasForeignKey(d => d.Statomobilio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobilio_statomobilio_fkey");

            entity.HasOne(d => d.TipomobilioNavigation).WithMany(p => p.Mobilios)
                .HasForeignKey(d => d.Tipomobilio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobilio_tipomobilio_fkey");
        });

        modelBuilder.Entity<Movimento>(entity =>
        {
            entity.HasKey(e => e.Idmovimento).HasName("movimento_pkey");

            entity.ToTable("movimento");

            entity.Property(e => e.Idmovimento).HasColumnName("idmovimento");
            entity.Property(e => e.Cauzione)
                .HasPrecision(10, 2)
                .HasColumnName("cauzione");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Idnoleggio).HasColumnName("idnoleggio");
            entity.Property(e => e.Pagamento)
                .HasMaxLength(30)
                .HasColumnName("pagamento");

            entity.HasOne(d => d.IdnoleggioNavigation).WithMany(p => p.Movimentos)
                .HasForeignKey(d => d.Idnoleggio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimento_idnoleggio_fkey");

            entity.HasOne(d => d.PagamentoNavigation).WithMany(p => p.Movimentos)
                .HasForeignKey(d => d.Pagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimento_pagamento_fkey");
        });

        modelBuilder.Entity<Noleggio>(entity =>
        {
            entity.HasKey(e => e.Idnoleggio).HasName("noleggio_pkey");

            entity.ToTable("noleggio");

            entity.HasIndex(e => new { e.Idmobilio, e.Datainizio, e.Datafine }, "noleggio_idmobilio_datainizio_datafine_key").IsUnique();

            entity.Property(e => e.Idnoleggio).HasColumnName("idnoleggio");
            entity.Property(e => e.Attivo)
                .HasDefaultValue(true)
                .HasColumnName("attivo");
            entity.Property(e => e.Datafine).HasColumnName("datafine");
            entity.Property(e => e.Datainizio).HasColumnName("datainizio");
            entity.Property(e => e.Idmobilio).HasColumnName("idmobilio");
            entity.Property(e => e.Idpersona).HasColumnName("idpersona");

            entity.HasOne(d => d.IdmobilioNavigation).WithMany(p => p.Noleggios)
                .HasForeignKey(d => d.Idmobilio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("noleggio_idmobilio_fkey");

            entity.HasOne(d => d.IdpersonaNavigation).WithMany(p => p.Noleggios)
                .HasForeignKey(d => d.Idpersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("noleggio_idpersona_fkey");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Idpersona).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.HasIndex(e => e.Email, "persona_email_key").IsUnique();

            entity.HasIndex(e => e.Idmonitor, "persona_idmonitor_key").IsUnique();

            entity.Property(e => e.Idpersona).HasColumnName("idpersona");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Idmonitor)
                .HasMaxLength(50)
                .HasColumnName("idmonitor");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Nomedipartimento)
                .HasMaxLength(50)
                .HasColumnName("nomedipartimento");
            entity.Property(e => e.Tipopersona)
                .HasMaxLength(50)
                .HasColumnName("tipopersona");

            entity.HasOne(d => d.NomedipartimentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Nomedipartimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_nomedipartimento_fkey");

            entity.HasOne(d => d.TipopersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Tipopersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_tipopersona_fkey");
        });

        modelBuilder.Entity<Statomobilio>(entity =>
        {
            entity.HasKey(e => e.Statomobilio1).HasName("statomobilio_pkey");

            entity.ToTable("statomobilio");

            entity.Property(e => e.Statomobilio1)
                .HasMaxLength(50)
                .HasColumnName("statomobilio");
        });

        modelBuilder.Entity<Tipomobilio>(entity =>
        {
            entity.HasKey(e => e.Tipomobilio1).HasName("tipomobilio_pkey");

            entity.ToTable("tipomobilio");

            entity.Property(e => e.Tipomobilio1)
                .HasMaxLength(50)
                .HasColumnName("tipomobilio");
        });

        modelBuilder.Entity<Tipopagamento>(entity =>
        {
            entity.HasKey(e => e.Pagamento).HasName("tipopagamento_pkey");

            entity.ToTable("tipopagamento");

            entity.Property(e => e.Pagamento)
                .HasMaxLength(30)
                .HasColumnName("pagamento");
        });

        modelBuilder.Entity<Tipopersona>(entity =>
        {
            entity.HasKey(e => e.Tipopersona1).HasName("tipopersona_pkey");

            entity.ToTable("tipopersona");

            entity.Property(e => e.Tipopersona1)
                .HasMaxLength(50)
                .HasColumnName("tipopersona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
