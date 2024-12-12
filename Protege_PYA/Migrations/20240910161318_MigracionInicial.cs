using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Protege_PYA.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activida__3214EC07CE441386", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__3214EC07FD3A452D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Extension = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Archivos__3214EC077068905A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charlas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: true),
                    LinkMeet = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Asistir = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Charlas__3214EC077CE169D1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasCuentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Autor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FormatoImagen = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__3214EC07CF81D817", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Especialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Informacion = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImagenMimeType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profesio__3214EC075CE17482", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC071A639E9F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FechaSubida = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Videos__3214EC07192FFC9E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_id = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Documento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Usuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Pass = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Intentos = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3214EC07C182AB71", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol",
                        column: x => x.Rol_id,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conversaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario1id = table.Column<int>(type: "int", nullable: true),
                    Usuario2id = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conversa__3214EC07E023CB58", x => x.Id);
                    table.ForeignKey(
                        name: "Usuarios_1_F",
                        column: x => x.Usuario1id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Usuarios_2_F",
                        column: x => x.Usuario2id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Usuario_id = table.Column<int>(type: "int", nullable: true),
                    Profesional_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evento__3214EC0723B98C43", x => x.Id);
                    table.ForeignKey(
                        name: "Profesional_FK",
                        column: x => x.Profesional_id,
                        principalTable: "Profesionales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Usuario_FK",
                        column: x => x.Usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_id = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_ultima_actividad = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sesiones__3214EC07544396BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario",
                        column: x => x.Usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conversacion_id = table.Column<int>(type: "int", nullable: true),
                    Remitente_id = table.Column<int>(type: "int", nullable: true),
                    Mensaje = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaEnvio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Leido = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mensajes__3214EC0764525347", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversacion",
                        column: x => x.Conversacion_id,
                        principalTable: "Conversaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Remitente",
                        column: x => x.Remitente_id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversaciones_Usuario1id",
                table: "Conversaciones",
                column: "Usuario1id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversaciones_Usuario2id",
                table: "Conversaciones",
                column: "Usuario2id");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Profesional_id",
                table: "Evento",
                column: "Profesional_id");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Usuario_id",
                table: "Evento",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_Conversacion_id",
                table: "Mensajes",
                column: "Conversacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_Remitente_id",
                table: "Mensajes",
                column: "Remitente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_Usuario_id",
                table: "Sesiones",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Rol_id",
                table: "Usuario",
                column: "Rol_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "Charlas");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "HistoriasCuentos");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Profesionales");

            migrationBuilder.DropTable(
                name: "Conversaciones");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
