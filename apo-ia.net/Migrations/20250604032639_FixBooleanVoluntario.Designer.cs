﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using apo_ia.net.Infraestructure.Data.AppData;

#nullable disable

namespace apo_ia.net.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250604032639_FixBooleanVoluntario")]
    partial class FixBooleanVoluntario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbrigadoEntityDoencaEntity", b =>
                {
                    b.Property<int>("abrigadosid")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("doencasid")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("abrigadosid", "doencasid");

                    b.HasIndex("doencasid");

                    b.ToTable("AbrigadoEntityDoencaEntity");
                });

            modelBuilder.Entity("HabilidadeEntityVoluntarioEntity", b =>
                {
                    b.Property<int>("habilidadesid")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("voluntariosid")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("habilidadesid", "voluntariosid");

                    b.HasIndex("voluntariosid");

                    b.ToTable("HabilidadeEntityVoluntarioEntity");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.AbrigadoEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<double?>("altura")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("cpf")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ferimento")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("idade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("localId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double?>("peso")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<bool?>("voluntario")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("id");

                    b.HasIndex("localId");

                    b.ToTable("tb_abrigado");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.DoencaEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("gravidade")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.ToTable("tb_doenca");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.GrupoHabilidadeEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.ToTable("tb_grupo_habilidade");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.HabilidadeEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int>("grupoHabilidadeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("prioridade")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id");

                    b.HasIndex("grupoHabilidadeId");

                    b.ToTable("tb_habilidade");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.LocalEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int?>("capacidade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("endereco")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("qtdAbrigados")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id");

                    b.ToTable("tb_local");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.VoluntarioEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int?>("abrigadoId")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("alocacao")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("capacidadeMotora")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.HasIndex("abrigadoId");

                    b.ToTable("tb_voluntario");
                });

            modelBuilder.Entity("AbrigadoEntityDoencaEntity", b =>
                {
                    b.HasOne("apo_ia.net.Domain.Entities.AbrigadoEntity", null)
                        .WithMany()
                        .HasForeignKey("abrigadosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apo_ia.net.Domain.Entities.DoencaEntity", null)
                        .WithMany()
                        .HasForeignKey("doencasid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HabilidadeEntityVoluntarioEntity", b =>
                {
                    b.HasOne("apo_ia.net.Domain.Entities.HabilidadeEntity", null)
                        .WithMany()
                        .HasForeignKey("habilidadesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apo_ia.net.Domain.Entities.VoluntarioEntity", null)
                        .WithMany()
                        .HasForeignKey("voluntariosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.AbrigadoEntity", b =>
                {
                    b.HasOne("apo_ia.net.Domain.Entities.LocalEntity", "local")
                        .WithMany()
                        .HasForeignKey("localId");

                    b.Navigation("local");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.HabilidadeEntity", b =>
                {
                    b.HasOne("apo_ia.net.Domain.Entities.GrupoHabilidadeEntity", "GrupoHabilidade")
                        .WithMany()
                        .HasForeignKey("grupoHabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoHabilidade");
                });

            modelBuilder.Entity("apo_ia.net.Domain.Entities.VoluntarioEntity", b =>
                {
                    b.HasOne("apo_ia.net.Domain.Entities.AbrigadoEntity", "abrigado")
                        .WithMany()
                        .HasForeignKey("abrigadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("abrigado");
                });
#pragma warning restore 612, 618
        }
    }
}
