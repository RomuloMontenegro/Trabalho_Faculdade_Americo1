using System;
using System.Collections.Generic;

namespace EnterPsi.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string DemandaClinica { get; set; }
        
        public List<Sessao> Sessoes { get; set; }

        public Paciente()
        {
            Sessoes = new List<Sessao>();
        }

        public void AdicionarSessao(DateTime data, string anotacoes)
        {
            Sessao novaSessao = new Sessao 
            { 
                Id = Sessoes.Count + 1, // Gera o ID da Sessão automaticamente
                PacienteId = this.Id, 
                Data = data, 
                AnotacoesClinicas = anotacoes 
            };
            Sessoes.Add(novaSessao);
        }
    }

    public class Sessao
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public string AnotacoesClinicas { get; set; }
    }
}