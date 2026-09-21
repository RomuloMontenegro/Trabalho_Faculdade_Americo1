using System;
using EnterPsi.Controllers;
using EnterPsi.Database;

namespace EnterPsi
{
    class Program
    {
        static void Main(string[] args)
        {
            PacienteController controllerPaciente = new PacienteController();
            SessaoController controllerSessao = new SessaoController();
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("       SISTEMA ENTERPSI (CLÍNICA)       ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Cadastrar Paciente (CRUD Paciente: Create)");
                Console.WriteLine("2. Listar Pacientes (CRUD Paciente: Read)");
                Console.WriteLine("3. Atualizar Demanda Clínica (CRUD Paciente: Update)");
                Console.WriteLine("4. Excluir/Arquivar Paciente (CRUD Paciente: Delete)");
                Console.WriteLine("5. Registrar Nova Sessão (CRUD Sessão: Create / GRASP: Creator)");
                Console.WriteLine("6. Listar Sessões do Paciente (CRUD Sessão: Read)");
                Console.WriteLine("7. Atualizar Anotação (CRUD Sessão: Update)");
                Console.WriteLine("8. Excluir Sessão (CRUD Sessão: Delete)");
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
                        controllerPaciente.CadastrarPaciente(nome, responsavel, demanda);
                        break;

                    case "2":
                        Console.WriteLine("--- LISTA DE PACIENTES ATIVOS ---");
                        controllerPaciente.ListarPacientes();
                        break;

                    case "3":
                        Console.Write("Digite o ID do Paciente que deseja atualizar: ");
                        int idAtualizar = int.Parse(Console.ReadLine());
                        Console.Write("Qual a nova Demanda Clínica? ");
                        string novaDemanda = Console.ReadLine();
                        controllerPaciente.AtualizarDemanda(idAtualizar, novaDemanda);
                        break;

                    case "4":
                        Console.Write("Digite o ID do Paciente para excluir: ");
                        int idExcluir = int.Parse(Console.ReadLine());
                        controllerPaciente.ExcluirPaciente(idExcluir);
                        break;

                    case "5":
                        Console.Write("Digite o ID do Paciente atendido: ");
                        int idSessaoCreate = int.Parse(Console.ReadLine());
                        Console.Write("Anotações Clínicas da Sessão: ");
                        string anotacoes = Console.ReadLine();
                        
                        var banco = ConexaoBanco.GetInstancia();
                        var paciente = banco.TabelaPacientes.Find(p => p.Id == idSessaoCreate);
                        
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

                    case "6":
                        Console.Write("Digite o ID do Paciente para listar as sessões: ");
                        int idSessaoRead = int.Parse(Console.ReadLine());
                        controllerSessao.ListarSessoes(idSessaoRead);
                        break;

                    case "7":
                        Console.Write("Digite o ID do Paciente: ");
                        int idPacUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID da Sessão que deseja atualizar: ");
                        int idSessaoUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Nova anotação clínica: ");
                        string novaAnotacao = Console.ReadLine();
                        controllerSessao.AtualizarAnotacao(idPacUpdate, idSessaoUpdate, novaAnotacao);
                        break;

                    case "8":
                        Console.Write("Digite o ID do Paciente: ");
                        int idPacDelete = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID da Sessão para excluir: ");
                        int idSessaoDelete = int.Parse(Console.ReadLine());
                        controllerSessao.ExcluirSessao(idPacDelete, idSessaoDelete);
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