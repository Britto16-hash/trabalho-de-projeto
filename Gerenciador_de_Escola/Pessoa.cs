namespace Gerenciador_de_Escola;

public class Pessoa
{
    public string nome { get; set; }
    public string email { get; set; }
    public string cpf { get; set; }
    public string telefone { get; set; }

    public Pessoa(string nome, string email, string cpf, string telefone)
    {
        this.nome = ValidarCampo(nome, nameof(nome));
        this.email = ValidarCampo(email, nameof(email));
        this.cpf = ValidarCampo(cpf, nameof(cpf));
        this.telefone = ValidarCampo(telefone, nameof(telefone));
    }

    private static string ValidarCampo(string? valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"O campo '{campo}' é obrigatório.", campo);

        return valor.Trim();
    }
}
