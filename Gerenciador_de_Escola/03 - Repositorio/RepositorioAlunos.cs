using Gerenciador_de_Escola;

namespace Gerenciador_de_Escola._03___Repositorio;

// Armazena os alunos em memória durante a execução do programa.
public class RepositorioAlunos
{
    private readonly List<Aluno> listaAlunos = new();

    public void Adicionar(string nome, string email, string telefone, string cpf, string curso, int matricula)
    {
        if (listaAlunos.Exists(aluno => aluno.matricula == matricula))
            throw new InvalidOperationException($"Já existe um aluno com a matrícula {matricula}.");

        var aluno = new Aluno(nome, email, telefone, cpf, curso, matricula);
        listaAlunos.Add(aluno);
    }

    public Aluno? Consultar(int matricula)
    {
        if (matricula <= 0)
            throw new ArgumentOutOfRangeException(nameof(matricula), "A matrícula deve ser maior que zero.");

        return listaAlunos.Find(aluno => aluno.matricula == matricula);
    }

    public bool Deletar(int matricula)
    {
        Aluno? aluno = Consultar(matricula);
        return aluno is not null && listaAlunos.Remove(aluno);
    }
}
