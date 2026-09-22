using EnterPsi.Models;

namespace EnterPsi.Factories
{

    public class PacienteFactory
    {
        private static int _contadorId = 1;
         
     // GoF Factory Method
     // Usamos o Factory Method para delegar a criação do paciente fora da interface.
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