using Gerenciador_de_Escola._02___Servico;

namespace Gerenciador_de_Escola;

internal class Program
{
    private static readonly ServicoAlunos servicoAlunos = new();

    private static void Main()
    {
        string? opcao;

        do
        {
            Console.WriteLine("=== GERENCIADOR ESCOLAR ===");
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine("2 - Consultar aluno");
            Console.WriteLine("3 - Deletar aluno");
            Console.WriteLine("4 - Sair");
            Console.Write("\nEscolha uma opção: ");
            opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        AdicionarAluno();
                        break;
                    case "2":
                        ConsultarAluno();
                        break;
                    case "3":
                        DeletarAluno();
                        break;
                    case "4":
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Selecione de 1 a 4.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formato: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                // Inclui ArgumentOutOfRangeException (matrícula não positiva).
                Console.WriteLine($"Dados inválidos: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Não foi possível cadastrar: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Consulta/exclusão: {ex.Message}");
            }

            Console.WriteLine();
        } while (opcao is not "4" and not null);
    }

    private static void AdicionarAluno()
    {
        string nome = LerTexto("o nome do aluno");
        string email = LerTexto("o e-mail do aluno");
        string telefone = LerTexto("o telefone do aluno");
        string cpf = LerTexto("o CPF do aluno");
        string curso = LerTexto("o curso");
        int matricula = LerMatricula();

        Console.WriteLine(servicoAlunos.Adicionar(nome, email, telefone, cpf, curso, matricula));
    }

    private static void ConsultarAluno()
    {
        int matricula = LerMatricula();
        Console.WriteLine(servicoAlunos.Consultar(matricula));
    }

    private static void DeletarAluno()
    {
        int matricula = LerMatricula();
        Console.WriteLine(servicoAlunos.Deletar(matricula));
    }

    private static string LerTexto(string descricao)
    {
        Console.Write($"Digite {descricao}: ");
        string? entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
            throw new ArgumentException("O campo não pode ficar vazio.");

        return entrada.Trim();
    }

    private static int LerMatricula()
    {
        Console.Write("Digite a matrícula do aluno: ");
        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int matricula))
            throw new FormatException("A matrícula deve conter apenas um número inteiro válido.");

        if (matricula <= 0)
            throw new ArgumentOutOfRangeException(nameof(matricula), "A matrícula deve ser maior que zero.");

        return matricula;
    }
}
