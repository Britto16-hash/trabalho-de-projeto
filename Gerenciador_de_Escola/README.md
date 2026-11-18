# Gerenciador escolar — tratamento de exceções

Aplicação de console em **C#/.NET 8**, baseada no projeto desenvolvido em aula. Mantém os fluxos de **cadastrar**, **consultar** e **deletar** alunos. Os registros são armazenados **somente em memória**: não persistem após encerrar o programa.

## Como executar

1. Instale o SDK do .NET 8 ou superior compatível com o projeto.
2. Abra um terminal na pasta `Gerenciador_de_Escola`.
3. Execute:

```bash
dotnet run
```

## Estrutura

- `Pessoa.cs`: campos comuns e validação de dados obrigatórios.
- `Aluno.cs`: herda de `Pessoa`; valida o curso e a matrícula.
- `03 - Repositorio/RepositorioAlunos.cs`: lista em memória e prevenção de matrícula duplicada.
- `02 - Servico/ServicoAlunos.cs`: regras de consulta e exclusão de aluno inexistente.
- `Program.cs`: menu, leitura segura e tratamento das exceções.

## Exceções previstas

| Situação | Exceção | Resultado para o usuário |
| --- | --- | --- |
| Matrícula digitada com letras, vazia ou fora do limite de `int` | `FormatException` | Pede número inteiro válido; programa continua aberto |
| Matrícula zero ou negativa | `ArgumentOutOfRangeException` | Informa que a matrícula deve ser maior que zero |
| Nome, e-mail, telefone, CPF ou curso vazio | `ArgumentException` | Informa campo obrigatório |
| Cadastrar matrícula já existente | `InvalidOperationException` | Informa que a matrícula já foi utilizada |
| Consultar ou excluir matrícula inexistente | `KeyNotFoundException` | Informa aluno não encontrado |
| Escolher opção diferente de 1, 2, 3 ou 4 | Tratamento simples no `switch` | Mostra mensagem e retorna ao menu |

As exceções são levantadas na camada adequada e capturadas no `Program`, evitando encerramento inesperado por erros de entrada previsíveis. Não há `catch (Exception)` genérico, para não mascarar erros de programação.

## Exemplos de teste manual

1. Cadastre `Ana`, curso `Medicina`, matrícula `101`: o sistema confirma.
2. Consulte `101`: o sistema exibe nome, curso e matrícula.
3. Tente cadastrar outro aluno com matrícula `101`: é exibido aviso de duplicidade.
4. Consulte `999`: é exibida mensagem de aluno não encontrado.
5. Delete `101` e tente deletar `101` novamente: na segunda tentativa, aluno não encontrado.
6. Digite `abc`, `0` ou `-2` como matrícula: erro apropriado sem interromper o menu.
7. Deixe um dos campos de cadastro vazio: a operação é rejeitada sem gravar o aluno.

> **Observação:** Não há validação algorítmica de CPF nem verificação de existência de e-mail; o objetivo desta atividade é o uso de exceções nos fluxos implementados em aula.
