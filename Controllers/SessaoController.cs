using System;
using System.Linq;
using EnterPsi.Database;

namespace EnterPsi.Controllers
{
    public class SessaoController
    {
        private ConexaoBanco _banco = ConexaoBanco.GetInstancia();

        public void ListarSessoes(int pacienteId)
        {
            var paciente = _banco.TabelaPacientes.FirstOrDefault(p => p.Id == pacienteId);
            if (paciente != null && paciente.Sessoes.Count > 0)
            {
                Console.WriteLine($"--- SESSÕES DE {paciente.Nome.ToUpper()} ---");
                foreach (var s in paciente.Sessoes)
                {
                    Console.WriteLine($"ID Sessão: {s.Id} | Data: {s.Data.ToShortDateString()} | Anotação: {s.AnotacoesClinicas}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma sessão encontrada para este paciente.");
            }
        }

        public void AtualizarAnotacao(int pacienteId, int sessaoId, string novaAnotacao)
        {
            var paciente = _banco.TabelaPacientes.FirstOrDefault(p => p.Id == pacienteId);
            var sessao = paciente?.Sessoes.FirstOrDefault(s => s.Id == sessaoId);
            
            if (sessao != null)
            {
                sessao.AnotacoesClinicas = novaAnotacao;
                Console.WriteLine("Anotação da sessão atualizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Sessão não encontrada.");
            }
        }

        public void ExcluirSessao(int pacienteId, int sessaoId)
        {
            var paciente = _banco.TabelaPacientes.FirstOrDefault(p => p.Id == pacienteId);
            var sessao = paciente?.Sessoes.FirstOrDefault(s => s.Id == sessaoId);
            
            if (sessao != null)
            {
                paciente.Sessoes.Remove(sessao);
                Console.WriteLine("Sessão excluída do prontuário com sucesso.");
            }
        }
    }
}