using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    palabra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    apellido = table.Column<string>(type: "varchar(200)", nullable: true),
                    email = table.Column<string>(type: "varchar(200)", nullable: true),
                    password = table.Column<string>(type: "varchar(200)", nullable: true),
                    intentosFallidos = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    isAdm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_Usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Amigo",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idAmigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Amigo", x => new { x.idAmigo, x.idUser });
                    table.ForeignKey(
                        name: "FK_Usuario_Amigo_Usuarios_idAmigo",
                        column: x => x.idAmigo,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Amigo_Usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPost = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Post_idPost",
                        column: x => x.idPost,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts_Tags",
                columns: table => new
                {
                    idPost = table.Column<int>(type: "int", nullable: false),
                    idTag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts_Tags", x => new { x.idPost, x.idTag });
                    table.ForeignKey(
                        name: "FK_Posts_Tags_Post_idPost",
                        column: x => x.idPost,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Tags_Tag_idTag",
                        column: x => x.idTag,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoReaccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPost = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaccion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reaccion_Post_idPost",
                        column: x => x.idPost,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reaccion_Usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idPost",
                table: "Comentario",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_idUser",
                table: "Comentario",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Post_idUser",
                table: "Post",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Tags_idTag",
                table: "Posts_Tags",
                column: "idTag");

            migrationBuilder.CreateIndex(
                name: "IX_Reaccion_idPost",
                table: "Reaccion",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Reaccion_idUser",
                table: "Reaccion",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Amigo_idUser",
                table: "Usuario_Amigo",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Posts_Tags");

            migrationBuilder.DropTable(
                name: "Reaccion");

            migrationBuilder.DropTable(
                name: "Usuario_Amigo");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
