using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ImobiAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCapitais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "municipios",
                columns: new[] { "Id", "atualizado_em", "nome", "populacao", "suportado", "uf", "codigo_ibge" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "São Paulo", 12325232, true, "SP", "3550308" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rio de Janeiro", 6748000, true, "RJ", "3304557" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Belo Horizonte", 2722000, true, "MG", "3106200" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Salvador", 2886698, true, "BA", "2927408" },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Brasília", 3094325, true, "DF", "5300108" },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Curitiba", 1948626, true, "PR", "4106902" },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Manaus", 2219580, true, "AM", "1302603" },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Recife", 1653461, true, "PE", "2611606" },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Porto Alegre", 1488252, true, "RS", "4314902" },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fortaleza", 2703391, true, "CE", "2304400" }
                });

            migrationBuilder.InsertData(
                table: "tabelas_emolumentos",
                columns: new[] { "Id", "ano_vigencia", "ativo", "fonte_tj", "tipo_ato", "uf" },
                values: new object[,]
                {
                    { 1, 2024, true, "TJ-SP", "Escritura", "SP" },
                    { 2, 2024, true, "TJ-SP", "Registro", "SP" },
                    { 3, 2024, true, "TJ-RJ", "Escritura", "RJ" },
                    { 4, 2024, true, "TJ-RJ", "Registro", "RJ" },
                    { 5, 2024, true, "TJ-MG", "Escritura", "MG" },
                    { 6, 2024, true, "TJ-MG", "Registro", "MG" },
                    { 7, 2024, true, "TJ-BA", "Escritura", "BA" },
                    { 8, 2024, true, "TJ-BA", "Registro", "BA" },
                    { 9, 2024, true, "TJ-DF", "Escritura", "DF" },
                    { 10, 2024, true, "TJ-DF", "Registro", "DF" },
                    { 11, 2024, true, "TJ-PR", "Escritura", "PR" },
                    { 12, 2024, true, "TJ-PR", "Registro", "PR" },
                    { 13, 2024, true, "TJ-AM", "Escritura", "AM" },
                    { 14, 2024, true, "TJ-AM", "Registro", "AM" },
                    { 15, 2024, true, "TJ-PE", "Escritura", "PE" },
                    { 16, 2024, true, "TJ-PE", "Registro", "PE" },
                    { 17, 2024, true, "TJ-RS", "Escritura", "RS" },
                    { 18, 2024, true, "TJ-RS", "Registro", "RS" },
                    { 19, 2024, true, "TJ-CE", "Escritura", "CE" },
                    { 20, 2024, true, "TJ-CE", "Registro", "CE" }
                });

            migrationBuilder.InsertData(
                table: "aliquotas_itbi",
                columns: new[] { "Id", "aliquota", "aliquota_financiado", "ano_vigencia", "ativo", "fonte_legal", "limite_isencao", "municipio_id" },
                values: new object[,]
                {
                    { 1, 3.0m, null, 2024, true, "Lei 11.154/1991", null, 1 },
                    { 2, 3.0m, null, 2024, true, "Lei 691/1984", null, 2 },
                    { 3, 3.0m, null, 2024, true, "Lei 5.839/1991", null, 3 },
                    { 4, 2.0m, null, 2024, true, "Lei 4.279/1990", null, 4 },
                    { 5, 3.0m, null, 2024, true, "Lei 3.830/2006", null, 5 },
                    { 6, 2.7m, null, 2024, true, "Lei 13.250/2009", null, 6 },
                    { 7, 2.0m, null, 2024, true, "Lei 1.815/2013", null, 7 },
                    { 8, 2.0m, null, 2024, true, "Lei 16.314/1997", null, 8 },
                    { 9, 3.0m, null, 2024, true, "Lei 7.531/1994", null, 9 },
                    { 10, 2.0m, null, 2024, true, "Lei 8.492/2000", null, 10 }
                });

            migrationBuilder.InsertData(
                table: "faixas_emolumentos",
                columns: new[] { "Id", "percentual_excedente", "tabela_id", "tipo_ato", "valor_fixo", "valor_maximo", "valor_minimo" },
                values: new object[,]
                {
                    { 1, null, 1, "Escritura", 1500m, 100000m, 0m },
                    { 2, null, 1, "Escritura", 3000m, 500000m, 100000.01m },
                    { 3, null, 1, "Escritura", 6000m, null, 500000.01m },
                    { 4, null, 2, "Registro", 1000m, 100000m, 0m },
                    { 5, null, 2, "Registro", 2000m, 500000m, 100000.01m },
                    { 6, null, 2, "Registro", 4000m, null, 500000.01m },
                    { 7, null, 5, "Escritura", 1200m, 100000m, 0m },
                    { 8, null, 5, "Escritura", 2500m, 500000m, 100000.01m },
                    { 9, null, 5, "Escritura", 5000m, null, 500000.01m },
                    { 10, null, 6, "Registro", 800m, 100000m, 0m },
                    { 11, null, 6, "Registro", 1800m, 500000m, 100000.01m },
                    { 12, null, 6, "Registro", 3500m, null, 500000.01m },
                    { 13, null, 3, "Escritura", 1400m, 100000m, 0m },
                    { 14, null, 3, "Escritura", 2800m, 500000m, 100000.01m },
                    { 15, null, 3, "Escritura", 5500m, null, 500000.01m },
                    { 16, null, 4, "Registro", 900m, 100000m, 0m },
                    { 17, null, 4, "Registro", 1900m, 500000m, 100000.01m },
                    { 18, null, 4, "Registro", 3800m, null, 500000.01m },
                    { 19, null, 7, "Escritura", 2000m, null, 0m },
                    { 20, null, 8, "Registro", 1500m, null, 0m },
                    { 21, null, 9, "Escritura", 2200m, null, 0m },
                    { 22, null, 10, "Registro", 1600m, null, 0m },
                    { 23, null, 11, "Escritura", 1900m, null, 0m },
                    { 24, null, 12, "Registro", 1400m, null, 0m },
                    { 25, null, 13, "Escritura", 1800m, null, 0m },
                    { 26, null, 14, "Registro", 1300m, null, 0m },
                    { 27, null, 15, "Escritura", 1700m, null, 0m },
                    { 28, null, 16, "Registro", 1200m, null, 0m },
                    { 29, null, 17, "Escritura", 2100m, null, 0m },
                    { 30, null, 18, "Registro", 1500m, null, 0m },
                    { 31, null, 19, "Escritura", 1600m, null, 0m },
                    { 32, null, 20, "Registro", 1100m, null, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "aliquotas_itbi",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "faixas_emolumentos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "municipios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tabelas_emolumentos",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
