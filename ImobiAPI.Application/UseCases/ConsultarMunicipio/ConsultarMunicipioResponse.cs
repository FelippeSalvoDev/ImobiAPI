namespace ImobiAPI.Application.UseCases.ConsultarMunicipio;

public record ConsultarMunicipioResponse(
    string CodigoIBGE,
    string Nome,
    string UF,
    decimal? AliquotaITBI,
    bool Suportado
);