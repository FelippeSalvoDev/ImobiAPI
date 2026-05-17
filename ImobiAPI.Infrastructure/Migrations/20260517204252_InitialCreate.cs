using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ImobiAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_ibge = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    populacao = table.Column<int>(type: "integer", nullable: true),
                    suportado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabelas_emolumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ano_vigencia = table.Column<int>(type: "integer", nullable: false),
                    tipo_ato = table.Column<string>(type: "text", nullable: false),
                    fonte_tj = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabelas_emolumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aliquotas_itbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    municipio_id = table.Column<int>(type: "integer", nullable: false),
                    aliquota = table.Column<decimal>(type: "numeric(5,4)", precision: 5, scale: 4, nullable: false),
                    aliquota_financiado = table.Column<decimal>(type: "numeric(5,4)", precision: 5, scale: 4, nullable: true),
                    limite_isencao = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: true),
                    fonte_legal = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ano_vigencia = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aliquotas_itbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aliquotas_itbi_municipios_municipio_id",
                        column: x => x.municipio_id,
                        principalTable: "municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "faixas_emolumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tabela_id = table.Column<int>(type: "integer", nullable: false),
                    valor_minimo = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    valor_maximo = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: true),
                    valor_fixo = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    percentual_excedente = table.Column<decimal>(type: "numeric(6,4)", precision: 6, scale: 4, nullable: true),
                    tipo_ato = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faixas_emolumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_faixas_emolumentos_tabelas_emolumentos_tabela_id",
                        column: x => x.tabela_id,
                        principalTable: "tabelas_emolumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aliquotas_itbi_municipio_id",
                table: "aliquotas_itbi",
                column: "municipio_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_faixas_emolumentos_tabela_id",
                table: "faixas_emolumentos",
                column: "tabela_id");

            migrationBuilder.CreateIndex(
                name: "IX_municipios_codigo_ibge",
                table: "municipios",
                column: "codigo_ibge",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tabelas_emolumentos_uf_ano_vigencia_tipo_ato",
                table: "tabelas_emolumentos",
                columns: new[] { "uf", "ano_vigencia", "tipo_ato" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aliquotas_itbi");

            migrationBuilder.DropTable(
                name: "faixas_emolumentos");

            migrationBuilder.DropTable(
                name: "municipios");

            migrationBuilder.DropTable(
                name: "tabelas_emolumentos");
        }
    }
}
