using ImobiAPI.Domain.Entities;
using ImobiAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ImobiAPI.Infrastructure.Persistence.Seeds;

public static class CapitaisSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var municipios = new List<object>
        {
           new { Id = 1, Nome = "São Paulo", UF = "SP", Populacao = 12325232, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 2, Nome = "Rio de Janeiro", UF = "RJ", Populacao = 6748000, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 3, Nome = "Belo Horizonte", UF = "MG", Populacao = 2722000, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 4, Nome = "Salvador", UF = "BA", Populacao = 2886698, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 5, Nome = "Brasília", UF = "DF", Populacao = 3094325, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 6, Nome = "Curitiba", UF = "PR", Populacao = 1948626, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 7, Nome = "Manaus", UF = "AM", Populacao = 2219580, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 8, Nome = "Recife", UF = "PE", Populacao = 1653461, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 9, Nome = "Porto Alegre", UF = "RS", Populacao = 1488252, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
           new { Id = 10, Nome = "Fortaleza", UF = "CE", Populacao = 2703391, Suportado = true, AtualizadoEm = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        };

        var codigosIBGE = new List<object>
        {
            new { MunicipioId = 1, Valor = "3550308" },
            new { MunicipioId = 2, Valor = "3304557" },
            new { MunicipioId = 3, Valor = "3106200" },
            new { MunicipioId = 4, Valor = "2927408" },
            new { MunicipioId = 5, Valor = "5300108" },
            new { MunicipioId = 6, Valor = "4106902" },
            new { MunicipioId = 7, Valor = "1302603" },
            new { MunicipioId = 8, Valor = "2611606" },
            new { MunicipioId = 9, Valor = "4314902" },
            new { MunicipioId = 10, Valor = "2304400" }
        };

        var aliquotas = new List<object>
        {
            new { Id = 1, MunicipioId = 1, Aliquota = 3.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 11.154/1991", AnoVigencia = 2024, Ativo = true },
            new { Id = 2, MunicipioId = 2, Aliquota = 3.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 691/1984", AnoVigencia = 2024, Ativo = true },
            new { Id = 3, MunicipioId = 3, Aliquota = 3.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 5.839/1991", AnoVigencia = 2024, Ativo = true },
            new { Id = 4, MunicipioId = 4, Aliquota = 2.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 4.279/1990", AnoVigencia = 2024, Ativo = true },
            new { Id = 5, MunicipioId = 5, Aliquota = 3.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 3.830/2006", AnoVigencia = 2024, Ativo = true },
            new { Id = 6, MunicipioId = 6, Aliquota = 2.7m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 13.250/2009", AnoVigencia = 2024, Ativo = true },
            new { Id = 7, MunicipioId = 7, Aliquota = 2.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 1.815/2013", AnoVigencia = 2024, Ativo = true },
            new { Id = 8, MunicipioId = 8, Aliquota = 2.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 16.314/1997", AnoVigencia = 2024, Ativo = true },
            new { Id = 9, MunicipioId = 9, Aliquota = 3.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 7.531/1994", AnoVigencia = 2024, Ativo = true },
            new { Id = 10, MunicipioId = 10, Aliquota = 2.0m, AliquotaFinanciado = (decimal?)null, LimiteIsencao = (decimal?)null, FonteLegal = "Lei 8.492/2000", AnoVigencia = 2024, Ativo = true }
        };

        var tabelasEmolumentos = new List<object>
        {
            new { Id = 1, UF = "SP", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-SP", Ativo = true },
            new { Id = 2, UF = "SP", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-SP", Ativo = true },
            new { Id = 3, UF = "RJ", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-RJ", Ativo = true },
            new { Id = 4, UF = "RJ", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-RJ", Ativo = true },
            new { Id = 5, UF = "MG", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-MG", Ativo = true },
            new { Id = 6, UF = "MG", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-MG", Ativo = true },
            new { Id = 7, UF = "BA", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-BA", Ativo = true },
            new { Id = 8, UF = "BA", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-BA", Ativo = true },
            new { Id = 9, UF = "DF", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-DF", Ativo = true },
            new { Id = 10, UF = "DF", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-DF", Ativo = true },
            new { Id = 11, UF = "PR", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-PR", Ativo = true },
            new { Id = 12, UF = "PR", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-PR", Ativo = true },
            new { Id = 13, UF = "AM", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-AM", Ativo = true },
            new { Id = 14, UF = "AM", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-AM", Ativo = true },
            new { Id = 15, UF = "PE", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-PE", Ativo = true },
            new { Id = 16, UF = "PE", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-PE", Ativo = true },
            new { Id = 17, UF = "RS", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-RS", Ativo = true },
            new { Id = 18, UF = "RS", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-RS", Ativo = true },
            new { Id = 19, UF = "CE", AnoVigencia = 2024, TipoAto = TipoAto.Escritura, FonteTJ = "TJ-CE", Ativo = true },
            new { Id = 20, UF = "CE", AnoVigencia = 2024, TipoAto = TipoAto.Registro, FonteTJ = "TJ-CE", Ativo = true }
        };

        var faixasEmolumentos = new List<object>
        {
            // SP - Escritura
            new { Id = 1, TabelaEmolumentosId = 1, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 1500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 2, TabelaEmolumentosId = 1, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 3000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 3, TabelaEmolumentosId = 1, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 6000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },

            // SP - Registro
            new { Id = 4, TabelaEmolumentosId = 2, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 1000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 5, TabelaEmolumentosId = 2, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 2000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 6, TabelaEmolumentosId = 2, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 4000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },

            // MG - Escritura
            new { Id = 7, TabelaEmolumentosId = 5, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 1200m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 8, TabelaEmolumentosId = 5, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 2500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 9, TabelaEmolumentosId = 5, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 5000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },

            // MG - Registro
            new { Id = 10, TabelaEmolumentosId = 6, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 800m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 11, TabelaEmolumentosId = 6, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 1800m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 12, TabelaEmolumentosId = 6, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 3500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },

            // RJ - Escritura
            new { Id = 13, TabelaEmolumentosId = 3, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 1400m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 14, TabelaEmolumentosId = 3, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 2800m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 15, TabelaEmolumentosId = 3, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 5500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },

            // RJ - Registro
            new { Id = 16, TabelaEmolumentosId = 4, ValorMinimo = 0m, ValorMaximo = (decimal?)100000m, ValorFixo = 900m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 17, TabelaEmolumentosId = 4, ValorMinimo = 100000.01m, ValorMaximo = (decimal?)500000m, ValorFixo = 1900m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 18, TabelaEmolumentosId = 4, ValorMinimo = 500000.01m, ValorMaximo = (decimal?)null, ValorFixo = 3800m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },

            // Demais estados - faixa única simplificada
            new { Id = 19, TabelaEmolumentosId = 7, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 2000m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 20, TabelaEmolumentosId = 8, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 21, TabelaEmolumentosId = 9, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 2200m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 22, TabelaEmolumentosId = 10, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1600m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 23, TabelaEmolumentosId = 11, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1900m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 24, TabelaEmolumentosId = 12, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1400m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 25, TabelaEmolumentosId = 13, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1800m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 26, TabelaEmolumentosId = 14, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1300m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 27, TabelaEmolumentosId = 15, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1700m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 28, TabelaEmolumentosId = 16, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1200m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 29, TabelaEmolumentosId = 17, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 2100m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 30, TabelaEmolumentosId = 18, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1500m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro },
            new { Id = 31, TabelaEmolumentosId = 19, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1600m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Escritura },
            new { Id = 32, TabelaEmolumentosId = 20, ValorMinimo = 0m, ValorMaximo = (decimal?)null, ValorFixo = 1100m, PercentualExcedente = (decimal?)null, TipoAto = TipoAto.Registro }
        };

        modelBuilder.Entity<TabelaEmolumentos>().HasData(tabelasEmolumentos);
        modelBuilder.Entity<FaixaEmolumento>().HasData(faixasEmolumentos);
        modelBuilder.Entity<Municipio>().OwnsOne(m => m.CodigoIBGE).HasData(codigosIBGE);
        modelBuilder.Entity<Municipio>().HasData(municipios);
        modelBuilder.Entity<AliquotaITBI>().HasData(aliquotas);
    }
}