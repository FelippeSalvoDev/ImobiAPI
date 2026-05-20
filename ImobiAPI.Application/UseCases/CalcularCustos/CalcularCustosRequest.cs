namespace ImobiAPI.Application.UseCases.CalcularCustos;

public record CalcularCustosRequest(
	string CodigoIBGE,
	decimal ValorImovel,
	bool Financiado
);