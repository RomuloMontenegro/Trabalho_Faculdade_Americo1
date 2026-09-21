using EnterPsi.Models;

namespace EnterPsi.Factories
{
    // Aplicação do Padrão GoF: Factory Method
    // Justificativa: Centraliza e encapsula a lógica de instanciação de novos pacientes.
    public class PacienteFactory
    {
        private static int _contadorId = 1;

        public static Paciente CriarPaciente(string nome, string responsavel, string demanda)
        {
            return new Paciente
            {
                Id = _contadorId++, // Simula um Auto Increment do banco
                Nome = nome,
                NomeResponsavel = responsavel,
                DemandaClinica = demanda
            };
        }
    }
}