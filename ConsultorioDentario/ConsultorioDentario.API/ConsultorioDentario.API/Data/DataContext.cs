using ConsultorioDentario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDentario.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Paciente> Paciente {get; set;}
        public DbSet<Dentista> Dentista {get; set;}
        public DbSet<Endereco> Endereco {get; set;}
        public DbSet<Procedimento> Procedimento {get; set;}
        public DbSet<Consulta> Consulta {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Primary Key
            modelBuilder.Entity<Paciente>()
            .HasKey(x => x.id_paciente);

             modelBuilder.Entity<Dentista>()
            .HasKey(x => x.id_dentista);

             modelBuilder.Entity<Endereco>()
            .HasKey(x => x.id_endereco);

             modelBuilder.Entity<Procedimento>()
            .HasKey(x => x.id_procedimento);

            modelBuilder.Entity<Consulta>()
            .HasKey(c => c.id_consulta);
            #endregion


            #region  Relacionamentos
            //Relacionamento UM PRA UM 
            modelBuilder.Entity<Endereco>()
            .HasOne(a => a.Paciente)
            .WithOne(b => b.Endereco)
            .HasForeignKey<Paciente>(b => b.id_endereco);

             modelBuilder.Entity<Endereco>()
            .HasOne(a => a.Dentista)
            .WithOne(b => b.Endereco)
            .HasForeignKey<Dentista>(b => b.id_endereco);

            //Relacionamento UM PRA MUITOS
             modelBuilder.Entity<Paciente>()
            .HasMany(c => c.Consulta)
            .WithOne(e => e.Paciente); 

            modelBuilder.Entity<Dentista>()
            .HasMany(c => c.Consulta)
            .WithOne(e => e.Dentista); 

            // modelBuilder.Entity<Consulta>()
            // .HasMany(c => c.Procedimento)
            // .WithOne(e => e.Consulta);

            modelBuilder.Entity<Procedimento>()
            .HasMany(c => c.Consulta)
            .WithOne(e => e.Procedimento); 

            #endregion

          
        }

        
    }
}