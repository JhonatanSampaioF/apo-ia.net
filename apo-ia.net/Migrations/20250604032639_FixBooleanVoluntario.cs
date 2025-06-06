using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apo_ia.net.Migrations
{
    /// <inheritdoc />
    public partial class FixBooleanVoluntario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_doenca",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    gravidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_doenca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_grupo_habilidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grupo_habilidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_local",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    capacidade = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    qtdAbrigados = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_local", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_habilidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    prioridade = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    grupoHabilidadeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_habilidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_habilidade_tb_grupo_habilidade_grupoHabilidadeId",
                        column: x => x.grupoHabilidadeId,
                        principalTable: "tb_grupo_habilidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_abrigado",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    idade = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    altura = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    peso = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    voluntario = table.Column<bool>(type: "NUMBER(1)", nullable: true),
                    ferimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    localId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_abrigado", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_abrigado_tb_local_localId",
                        column: x => x.localId,
                        principalTable: "tb_local",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AbrigadoEntityDoencaEntity",
                columns: table => new
                {
                    abrigadosid = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    doencasid = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrigadoEntityDoencaEntity", x => new { x.abrigadosid, x.doencasid });
                    table.ForeignKey(
                        name: "FK_AbrigadoEntityDoencaEntity_tb_abrigado_abrigadosid",
                        column: x => x.abrigadosid,
                        principalTable: "tb_abrigado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbrigadoEntityDoencaEntity_tb_doenca_doencasid",
                        column: x => x.doencasid,
                        principalTable: "tb_doenca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_voluntario",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    alocacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    capacidadeMotora = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    abrigadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_voluntario", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_voluntario_tb_abrigado_abrigadoId",
                        column: x => x.abrigadoId,
                        principalTable: "tb_abrigado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadeEntityVoluntarioEntity",
                columns: table => new
                {
                    habilidadesid = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    voluntariosid = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadeEntityVoluntarioEntity", x => new { x.habilidadesid, x.voluntariosid });
                    table.ForeignKey(
                        name: "FK_HabilidadeEntityVoluntarioEntity_tb_habilidade_habilidadesid",
                        column: x => x.habilidadesid,
                        principalTable: "tb_habilidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadeEntityVoluntarioEntity_tb_voluntario_voluntariosid",
                        column: x => x.voluntariosid,
                        principalTable: "tb_voluntario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbrigadoEntityDoencaEntity_doencasid",
                table: "AbrigadoEntityDoencaEntity",
                column: "doencasid");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadeEntityVoluntarioEntity_voluntariosid",
                table: "HabilidadeEntityVoluntarioEntity",
                column: "voluntariosid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_abrigado_localId",
                table: "tb_abrigado",
                column: "localId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_habilidade_grupoHabilidadeId",
                table: "tb_habilidade",
                column: "grupoHabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_voluntario_abrigadoId",
                table: "tb_voluntario",
                column: "abrigadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbrigadoEntityDoencaEntity");

            migrationBuilder.DropTable(
                name: "HabilidadeEntityVoluntarioEntity");

            migrationBuilder.DropTable(
                name: "tb_doenca");

            migrationBuilder.DropTable(
                name: "tb_habilidade");

            migrationBuilder.DropTable(
                name: "tb_voluntario");

            migrationBuilder.DropTable(
                name: "tb_grupo_habilidade");

            migrationBuilder.DropTable(
                name: "tb_abrigado");

            migrationBuilder.DropTable(
                name: "tb_local");
        }
    }
}
