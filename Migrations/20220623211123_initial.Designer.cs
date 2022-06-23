﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3;

namespace TP3.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220623211123_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP3.Comentario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPost")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idPost");

                    b.HasIndex("idUser");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("TP3.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idUser");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("TP3.PostsTags", b =>
                {
                    b.Property<int>("idPost")
                        .HasColumnType("int");

                    b.Property<int>("idTag")
                        .HasColumnType("int");

                    b.HasKey("idPost", "idTag");

                    b.HasIndex("idTag");

                    b.ToTable("Posts_Tags");
                });

            modelBuilder.Entity("TP3.Reaccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idPost")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<string>("tipoReaccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idPost");

                    b.HasIndex("idUser");

                    b.ToTable("Reaccion");
                });

            modelBuilder.Entity("TP3.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("palabra")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TP3.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("intentosFallidos")
                        .HasColumnType("int");

                    b.Property<bool>("isAdm")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("password")
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TP3.UsuarioAmigo", b =>
                {
                    b.Property<int>("idAmigo")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idAmigo", "idUser");

                    b.HasIndex("idUser");

                    b.ToTable("Usuario_Amigo");
                });

            modelBuilder.Entity("TP3.Comentario", b =>
                {
                    b.HasOne("TP3.Post", "post")
                        .WithMany("comentarios")
                        .HasForeignKey("idPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3.Usuario", "usuario")
                        .WithMany("misComentarios")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("TP3.Post", b =>
                {
                    b.HasOne("TP3.Usuario", "user")
                        .WithMany("misPosts")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("TP3.PostsTags", b =>
                {
                    b.HasOne("TP3.Post", "Post")
                        .WithMany("PostsTags")
                        .HasForeignKey("idPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3.Tag", "Tag")
                        .WithMany("PostsTags")
                        .HasForeignKey("idTag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("TP3.Reaccion", b =>
                {
                    b.HasOne("TP3.Post", "post")
                        .WithMany("reacciones")
                        .HasForeignKey("idPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3.Usuario", "usuario")
                        .WithMany("misReacciones")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("TP3.UsuarioAmigo", b =>
                {
                    b.HasOne("TP3.Usuario", "user")
                        .WithMany("misAmigos")
                        .HasForeignKey("idAmigo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TP3.Usuario", "amigo")
                        .WithMany("amigosMios")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("amigo");

                    b.Navigation("user");
                });

            modelBuilder.Entity("TP3.Post", b =>
                {
                    b.Navigation("comentarios");

                    b.Navigation("PostsTags");

                    b.Navigation("reacciones");
                });

            modelBuilder.Entity("TP3.Tag", b =>
                {
                    b.Navigation("PostsTags");
                });

            modelBuilder.Entity("TP3.Usuario", b =>
                {
                    b.Navigation("amigosMios");

                    b.Navigation("misAmigos");

                    b.Navigation("misComentarios");

                    b.Navigation("misPosts");

                    b.Navigation("misReacciones");
                });
#pragma warning restore 612, 618
        }
    }
}