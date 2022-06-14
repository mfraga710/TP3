using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TP3
{
    class MyContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<Comentario> comentarios { get; set; }        
        public DbSet<Reaccion> reacciones { get; set; }
        public DbSet<Tag> tags { get; set; }

        public MyContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(u => u.id);
            modelBuilder.Entity<Post>().ToTable("Post").HasKey(p => p.id);
            modelBuilder.Entity<Comentario>().ToTable("Comentario").HasKey(c => c.id);
            modelBuilder.Entity<Reaccion>().ToTable("Reaccion").HasKey(r => r.id);

            //relaciones
            modelBuilder.Entity<Post>()
                .HasOne(P => P.user)
                .WithMany(U => U.misPosts)
                .HasForeignKey(P => P.idUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentario>()
                .HasOne(C => C.usuario)
                .WithMany(U => U.misComentarios)
                .HasForeignKey(C => C.idUser);

            modelBuilder.Entity<Comentario>()
                .HasOne(C => C.post)
                .WithMany(P => P.comentarios)
                .HasForeignKey(C => C.idPost);

            modelBuilder.Entity<Reaccion>()
                .HasOne(R => R.usuario)
                .WithMany(U => U.misReacciones)
                .HasForeignKey(R => R.idUser);

            modelBuilder.Entity<Reaccion>()
                .HasOne(R => R.post)
                .WithMany(P => P.reacciones)
                .HasForeignKey(R => R.idPost);

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(U => U.Amigo)
            //    .WithMany(P => P.User)
            //    .UsingEntity<AmigosRel>(
            //        ear => ear.HasOne(u => u.amigo).WithMany(a => a.AmigosRel).HasForeignKey(u => u.idAmigo),
            //        ear => ear.HasOne(up => up.usuario).WithMany(u => u.AmigosRel).HasForeignKey(u => u.idUser),
            //        ear => ear.HasKey(k => new { k.idAmigo, k.idUser })
            //    );

            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr => 
                {
                    usr.Property(u => u.dni).HasColumnType("int");
                    usr.Property(u => u.dni).IsRequired(true);
                    usr.Property(u => u.nombre).HasColumnType("varchar(200)");
                    usr.Property(u => u.apellido).HasColumnType("varchar(200)");
                    usr.Property(u => u.email).HasColumnType("varchar(200)");
                    usr.Property(u => u.password).HasColumnType("varchar(200)");
                    usr.Property(u => u.intentosFallidos).HasColumnType("int");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                    usr.Property(u => u.isAdm).HasColumnType("bit");
                });

            modelBuilder.Ignore<RedSocial>();
            modelBuilder.Ignore<DAL>();
        }
    }
}
