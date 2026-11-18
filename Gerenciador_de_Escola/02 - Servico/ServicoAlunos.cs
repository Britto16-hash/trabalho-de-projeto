using Gerenciador_de_Escola._03___Repositorio;

namespace Gerenciador_de_Escola._02___Servico;

public class ServicoAlunos
{
    private readonly RepositorioAlunos repositorio = new();

    public string Adicionar(string nome, string email, string telefone, string cpf, string curso, int matricula)
    {
        repositorio.Adicionar(nome, email, telefone, cpf, curso, matricula);
        return $"Aluno '{nome.Trim()}' cadastrado com sucesso!";
    }

    public string Consultar(int matricula)
    {
        Aluno? aluno = repositorio.Consultar(matricula);

        if (aluno is null)
            throw new KeyNotFoundException($"Nenhum aluno encontrado com a matrícula {matricula}.");

        return $"Matrícula: {aluno.matricula} | Nome: {aluno.nome} | Curso: {aluno.curso}";
    }

    public string Deletar(int matricula)
    {
        if (!repositorio.Deletar(matricula))
            throw new KeyNotFoundException($"Nenhum aluno encontrado com a matrícula {matricula}.");

        return "Aluno deletado com sucesso!";
    }
}
