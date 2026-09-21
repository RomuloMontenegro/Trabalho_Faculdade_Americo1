using System;
using System.Collections.Generic;

namespace EnterPsi.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; } // Para o portal de monitoramento
        public string DemandaClinica { get; set; }
        
        // Relacionamento: Um paciente tem várias sessões
        public List<Sessao> Sessoes { get; set; }

        public Paciente()
        {
            Sessoes = new List<Sessao>();
        }

        // Aplicação do Padrão GRASP: Creator (Criador)
        // Justificativa: A classe Paciente é a "Criadora" de Sessao porque ela agrega/contém as sessões.
        public void AdicionarSessao(DateTime data, string anotacoes)
        {
            Sessao novaSessao = new Sessao 
            { 
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