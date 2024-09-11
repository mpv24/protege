using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Protege_PYA.Models;

public partial class ProtegePyaContext : DbContext
{
    public ProtegePyaContext()
    {
    }

    public ProtegePyaContext(DbContextOptions<ProtegePyaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Charla> Charlas { get; set; }

    public virtual DbSet<Conversacione> Conversaciones { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<HistoriasCuento> HistoriasCuentos { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Profesionale> Profesionales { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sesione> Sesiones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activida__3214EC07CE441386");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC07FD3A452D");

            entity.ToTable("Administrador");

            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Archivos__3214EC077068905A");

            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Charla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Charlas__3214EC077CE169D1");

            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.LinkMeet)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Conversacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conversa__3214EC07E023CB58");

            entity.Property(e => e.Estado).HasDefaultValue(false);
            entity.Property(e => e.FechaInicio)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario1).WithMany(p => p.ConversacioneUsuario1s)
                .HasForeignKey(d => d.Usuario1id)
                .HasConstraintName("Usuarios_1_F");

            entity.HasOne(d => d.Usuario2).WithMany(p => p.ConversacioneUsuario2s)
                .HasForeignKey(d => d.Usuario2id)
                .HasConstraintName("Usuarios_2_F");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evento__3214EC0723B98C43");

            entity.ToTable("Evento");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.ProfesionalId).HasColumnName("Profesional_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Profesional).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ProfesionalId)
                .HasConstraintName("Profesional_FK");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("Usuario_FK");
        });

        modelBuilder.Entity<HistoriasCuento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07CF81D817");

            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FormatoImagen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mensajes__3214EC0764525347");

            entity.Property(e => e.ConversacionId).HasColumnName("Conversacion_id");
            entity.Property(e => e.FechaEnvio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mensaje1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Mensaje");
            entity.Property(e => e.RemitenteId).HasColumnName("Remitente_id");

            entity.HasOne(d => d.Conversacion).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.ConversacionId)
                .HasConstraintName("FK_Conversacion");

            entity.HasOne(d => d.Remitente).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.RemitenteId)
                .HasConstraintName("FK_Remitente");
        });

        modelBuilder.Entity<Profesionale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesio__3214EC075CE17482");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImagenMimeType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Informacion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC071A639E9F");

            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sesione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sesiones__3214EC07544396BA");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_inicio");
            entity.Property(e => e.FechaUltimaActividad)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_ultima_actividad");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Sesiones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07C182AB71");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.Intentos).HasDefaultValue(0);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("Rol_id");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Rol");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Videos__3214EC07192FFC9E");

            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
