﻿// <auto-generated />
using BackEndAprovacao.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndAprovacao.Migrations
{
    [DbContext(typeof(AprovacaoContext))]
    partial class AprovacaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndAprovacao.Models.Escritorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Escritorios");
                });

            modelBuilder.Entity("BackEndAprovacao.Models.Processo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("EscritorioId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDeProcesso")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ReclamanteId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCausa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EscritorioId");

                    b.HasIndex("ReclamanteId");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("BackEndAprovacao.Models.Reclamante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Reclamantes");
                });

            modelBuilder.Entity("BackEndAprovacao.Models.Processo", b =>
                {
                    b.HasOne("BackEndAprovacao.Models.Escritorio", "Escritorio")
                        .WithMany()
                        .HasForeignKey("EscritorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAprovacao.Models.Reclamante", "Reclamante")
                        .WithMany()
                        .HasForeignKey("ReclamanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escritorio");

                    b.Navigation("Reclamante");
                });
#pragma warning restore 612, 618
        }
    }
}
