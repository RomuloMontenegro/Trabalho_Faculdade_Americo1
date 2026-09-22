using System;
using System.Linq;
using EnterPsi.Models;
using EnterPsi.Database;
using EnterPsi.Factories;

namespace EnterPsi.Controllers
{

    // GRASP Controller
    // O GRASP Controller centraliza as regras de negócio aqui
public class PacienteController
{
    // GoF Singleton: Ponto de acesso global à instância única do banco em memória para evitar sobrescrita de dados.
    private ConexaoBanco _banco = ConexaoBanco.GetInstancia();

        // CREATE
        public void CadastrarPaciente(string nome, string responsavel, string demanda)
        {
            Paciente novoPaciente = PacienteFactory.CriarPaciente(nome, responsavel, demanda);
            _banco.TabelaPacientes.Add(novoPaciente);
            Console.WriteLine($"Paciente {nome} cadastrado com sucesso!");
        }

        // READ
        public void ListarPacientes()
        {
            foreach (var p in _banco.TabelaPacientes)
            {
                Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Caso: {p.DemandaClinica}");
            }
        }

        // UPDATE
        public void AtualizarDemanda(int id, string novaDemanda)
        {
            var paciente = _banco.TabelaPacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                paciente.DemandaClinica = novaDemanda;
                Console.WriteLine("Dados clínicos atualizados.");
            }
        }

        // DELETE
        public void ExcluirPaciente(int id)
        {
            var paciente = _banco.TabelaPacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                _banco.TabelaPacientes.Remove(paciente);
                Console.WriteLine("Paciente arquivado/excluído.");
            }
        }
    }
}