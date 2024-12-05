using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Data;
using testframeworj7.Models;
using System.Diagnostics;
using static testframeworj7.Models.TarifsContext;

namespace testframeworj7.Models;



public class Etablissement
{

    [Key]
    public int etId { get; set; }
    public string? Nom { get; set; }
}

public class EtablissementContext : DbContext
{
    public DbSet<Etablissement> etablissement { get; set; }
    public EtablissementContext(DbContextOptions<EtablissementContext> options)
    : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}

public class Chambres
{
    [Key]
    public int chambreID { get; set; }
    public string? Nom { get; set; }
    public int typeID { get; set; }
    public TypesdeChambres? typedechambres { get; set; }
}

public class ChambresContext : DbContext
{
    public DbSet<Chambres> chambres { get; set; }
    public ChambresContext(DbContextOptions<ChambresContext> options)
    : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
    public class IntWrapper
    {
        public int Value { get; set; }
        public IntWrapper(int value) { Value = value; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chambres>()
            .HasOne<TypesdeChambres>(ta => ta.typedechambres)
            .WithMany(ty => ty.chambres)
            .HasForeignKey(ta => ta.typeID);
    }


   

    public DbSet<TypesdeChambres> typedechambres { get; set; }
}

public class TypesdeChambres
{
    [Key]
    public int typeID { get; set; }
    public string? Nom { get; set; }
    public int etabID { get; set; }
    public ICollection<Tarifs>? tarifs { get; set; }
    public ICollection<Chambres>? chambres { get; set; }
}

public class TypesdeChambresContext : DbContext
{
    public DbSet<TypesdeChambres> typedechambres { get; set; }
    public TypesdeChambresContext(DbContextOptions<TypesdeChambresContext> options)
    : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }

    

}


public class Tarifs
{
    [Key]
    public int tarID { get; set; }
    public System.DateTime datet { get; set; }
    public float prix { get; set;}
    public int typeID { get; set; }
   
    public TypesdeChambres? typedechambres { get; set; }
}

public class TarifsContext : DbContext
{
    public DbSet<Tarifs> tarifs { get; set; }
    public TarifsContext(DbContextOptions<TarifsContext> options)
    : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }


    public class IntWrapper
    {
        public int Value { get; set; }
        

        public IntWrapper(int value) { Value = value; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarifs>()
            .HasOne<TypesdeChambres>(ta => ta.typedechambres)
            .WithMany(ty => ty.tarifs)
            .HasForeignKey(ta => ta.typeID);
    }

 
    public DbSet<TypesdeChambres> typedechambres { get; set; }
   
}


public class Reservations
{
    [Key]
    public int resID { get; set; }
    public int clientID { get; set; }
    public int OTAID { get; set; }
    public TypesdeChambres _type { get; set; }
    public System.DateTime dateDebut { get; set; }
    public System.DateTime dateFin { get; set; }
    public Clients _client;
}

public class ReservationsContext : DbContext
{
    public DbSet<Reservations> reservations { get; set; }
    public DbSet<TypesdeChambres> typedechambre { get; set; }
    public DbSet<Clients> client { get; set; }
    public ReservationsContext(DbContextOptions<ReservationsContext> options)
    : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservations>()
        .HasOne<Clients>(r => r._client)
        .WithMany(c => c.Reservations)
        .HasForeignKey(r => r.clientID);
    }
}

public class Clients
{
    [Key]
    public int clID { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? mail { get; set; }
    public string? tel { get; set; }
    public ICollection<Reservations> Reservations { get; set; }
  
             
}

public class ClientsContext : DbContext
{
    public DbSet<Clients> clients{ get; set; }
    public ClientsContext(DbContextOptions<ClientsContext> options)
    : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string _connectionString = @"server=localhost;port=3306;uid=root;pwd=Saratata1910$$;database=logidian;persistsecurityinfo=true;convertzerodatetime=true";
        optionsBuilder.UseMySql(
            _connectionString, ServerVersion.AutoDetect(_connectionString));
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}

