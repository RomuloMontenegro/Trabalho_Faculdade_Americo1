using System;
using EnterPsi.Controllers;
using EnterPsi.Database;

namespace EnterPsi
{
    class Program
    {
        static void Main(string[] args)
        {
            PacienteController controller = new PacienteController();
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("       SISTEMA ENTERPSI (CLÍNICA)       ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Cadastrar Paciente (CRUD: Create)");
                Console.WriteLine("2. Listar Pacientes (CRUD: Read)");
                Console.WriteLine("3. Atualizar Demanda Clínica (CRUD: Update)");
                Console.WriteLine("4. Excluir/Arquivar Paciente (CRUD: Delete)");
                Console.WriteLine("5. Registrar Nova Sessão (GRASP: Creator)");
                Console.WriteLine("0. Sair");
                Console.WriteLine("----------------------------------------");
                Console.Write("Escolha uma opção: ");
                
                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do Paciente: ");
                        string nome = Console.ReadLine();
                        Console.Write("Nome do Responsável: ");
                        string responsavel = Console.ReadLine();
                        Console.Write("Demanda Clínica Inicial: ");
                        string demanda = Console.ReadLine();
                        
                        controller.CadastrarPaciente(nome, responsavel, demanda);
                        break;

                    case "2":
                        Console.WriteLine("--- LISTA DE PACIENTES ATIVOS ---");
                        controller.ListarPacientes();
                        break;

                    case "3":
                        Console.Write("Digite o ID do Paciente que deseja atualizar: ");
                        int idAtualizar = int.Parse(Console.ReadLine());
                        Console.Write("Qual a nova Demanda Clínica? ");
                        string novaDemanda = Console.ReadLine();
                        
                        controller.AtualizarDemanda(idAtualizar, novaDemanda);
                        break;

                    case "4":
                        Console.Write("Digite o ID do Paciente para excluir: ");
                        int idExcluir = int.Parse(Console.ReadLine());
                        
                        controller.ExcluirPaciente(idExcluir);
                        break;

                    case "5":
                        Console.Write("Digite o ID do Paciente atendido: ");
                        int idSessao = int.Parse(Console.ReadLine());
                        Console.Write("Anotações Clínicas da Sessão: ");
                        string anotacoes = Console.ReadLine();
                        
                        // Buscando o paciente no banco (Singleton)
                        var banco = ConexaoBanco.GetInstancia();
                        var paciente = banco.TabelaPacientes.Find(p => p.Id == idSessao);
                        
                        if(paciente != null) 
                        {
                            paciente.AdicionarSessao(DateTime.Now, anotacoes);
                            Console.WriteLine($"Sessão registrada com sucesso para {paciente.Nome}!");
                        } 
                        else 
                        {
                            Console.WriteLine("Erro: Paciente não encontrado.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o sistema...");
                        rodando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}