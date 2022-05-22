﻿// <auto-generated />
using System;
using BackEndAprovacao.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndAprovacao.Migrations
{
    [DbContext(typeof(AprovacaoContext))]
    [Migration("20220112185419_Primeira Migration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("EscritorioId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCausa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EscritorioId");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reclamantes");
                });

            modelBuilder.Entity("BackEndAprovacao.Models.Processo", b =>
                {
                    b.HasOne("BackEndAprovacao.Models.Escritorio", "Escritorio")
                        .WithMany()
                        .HasForeignKey("EscritorioId");

                    b.Navigation("Escritorio");
                });
#pragma warning restore 612, 618
        }
    }
}