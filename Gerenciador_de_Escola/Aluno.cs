namespace Gerenciador_de_Escola;

public class Aluno : Pessoa
{
    public int matricula { get; set; }
    public string curso { get; set; }

    public Aluno(string nome, string email, string telefone, string cpf, string curso, int matricula)
        : base(nome, email, cpf, telefone)
    {
        if (string.IsNullOrWhiteSpace(curso))
            throw new ArgumentException("O campo 'curso' é obrigatório.", nameof(curso));

        if (matricula <= 0)
            throw new ArgumentOutOfRangeException(nameof(matricula), "A matrícula deve ser maior que zero.");

        this.curso = curso.Trim();
        this.matricula = matricula;
    }
}
