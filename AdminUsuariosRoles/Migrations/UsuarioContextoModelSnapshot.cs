﻿// <auto-generated />
using AdminUsuariosRoles.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminUsuariosRoles.Migrations
{
    [DbContext(typeof(UsuarioContexto))]
    partial class UsuarioContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdminUsuariosRoles.Modelo.ModRolesUsuarios", b =>
                {
                    b.Property<int>("ModRolesUsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ModRolId")
                        .HasColumnType("int");

                    b.Property<int>("ModUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ModRolesUsuariosId");

                    b.HasIndex("ModUsuarioId");

                    b.ToTable("RolesUsuarios");
                });

            modelBuilder.Entity("AdminUsuariosRoles.Modelo.ModUsuario", b =>
                {
                    b.Property<int>("ModUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .HasColumnType("text");

                    b.HasKey("ModUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AdminUsuariosRoles.Modelo.ModRolesUsuarios", b =>
                {
                    b.HasOne("AdminUsuariosRoles.Modelo.ModUsuario", "ModUsuario")
                        .WithMany("ListaRolesUsuarios")
                        .HasForeignKey("ModUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}