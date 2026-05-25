namespace ImobiAPI.Application.DTOs;

public record ApiResponse<T>
{
    public bool Sucesso { get; init; }
    public T? Dados { get; init; }
    public ApiErro? Erro { get; init; }

    public static ApiResponse<T> Ok(T dados) => new()
    {
        Sucesso = true,
        Dados = dados,
        Erro = null
    };

    public static ApiResponse<T> Falha(string codigo, string mensagem) => new()
    {
        Sucesso = false,
        Dados = default,
        Erro = new ApiErro(codigo, mensagem, DateTime.UtcNow)
    };
}

public record ApiErro(
    string Codigo,
    string Mensagem,
    DateTime Timestamp
);