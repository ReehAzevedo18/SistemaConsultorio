﻿// <auto-generated />
using System;
using ConsultorioDentario.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsultorioDentario.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("ConsultorioDentario.API.Models.Consulta", b =>
                {
                    b.Property<int>("id_consulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Dentistaid_dentista")
                        .HasColumnType("int");

                    b.Property<int?>("Pacienteid_paciente")
                        .HasColumnType("int");

                    b.Property<int?>("Procedimentoid_procedimento")
                        .HasColumnType("int");

                    b.Property<DateTime>("dt_consulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_consulta");

                    b.HasIndex("Dentistaid_dentista");

                    b.HasIndex("Pacienteid_paciente");

                    b.HasIndex("Procedimentoid_procedimento");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Dentista", b =>
                {
                    b.Property<int>("id_dentista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_endereco")
                        .HasColumnType("int");

                    b.Property<string>("matricula")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_dentista");

                    b.HasIndex("id_endereco")
                        .IsUnique();

                    b.ToTable("Dentista");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Endereco", b =>
                {
                    b.Property<int>("id_endereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("num")
                        .HasColumnType("int");

                    b.HasKey("id_endereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Paciente", b =>
                {
                    b.Property<int>("id_paciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dt_cadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_endereco")
                        .HasColumnType("int");

                    b.Property<string>("numCarteira")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_paciente");

                    b.HasIndex("id_endereco")
                        .IsUnique();

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Procedimento", b =>
                {
                    b.Property<int>("id_procedimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("duracao")
                        .HasColumnType("int");

                    b.Property<string>("valor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_procedimento");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Consulta", b =>
                {
                    b.HasOne("ConsultorioDentario.API.Models.Dentista", "Dentista")
                        .WithMany("Consulta")
                        .HasForeignKey("Dentistaid_dentista");

                    b.HasOne("ConsultorioDentario.API.Models.Paciente", "Paciente")
                        .WithMany("Consulta")
                        .HasForeignKey("Pacienteid_paciente");

                    b.HasOne("ConsultorioDentario.API.Models.Procedimento", "Procedimento")
                        .WithMany("Consulta")
                        .HasForeignKey("Procedimentoid_procedimento");
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Dentista", b =>
                {
                    b.HasOne("ConsultorioDentario.API.Models.Endereco", "Endereco")
                        .WithOne("Dentista")
                        .HasForeignKey("ConsultorioDentario.API.Models.Dentista", "id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultorioDentario.API.Models.Paciente", b =>
                {
                    b.HasOne("ConsultorioDentario.API.Models.Endereco", "Endereco")
                        .WithOne("Paciente")
                        .HasForeignKey("ConsultorioDentario.API.Models.Paciente", "id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
