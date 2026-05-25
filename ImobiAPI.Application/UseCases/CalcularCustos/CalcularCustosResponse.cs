namespace ImobiAPI.Application.UseCases.CalcularCustos;

public record CalcularCustosResponse(
    string Municipio,
    string UF,
    decimal ValorImovel,
    decimal ValorITBI,
    decimal AliquotaITBI,
    string FonteLegalITBI,
    int AnoVigenciaITBI,
    decimal ValorEscritura,
    decimal ValorRegistro,
    decimal TotalCustos,
    decimal PercentualSobreImovel,
    bool Isento,
    bool Financiado
);