namespace EnterPsi.Database
{
    public class ConexaoBanco
    {
        private static ConexaoBanco _instancia;
        
        // Simulação de um banco de dados em memória para facilitar o trabalho
        public List<Models.Paciente> TabelaPacientes { get; set; }

        // Construtor privado impede que outras classes usem "new ConexaoBanco()"
        private ConexaoBanco()
        {
            TabelaPacientes = new List<Models.Paciente>();
            Console.WriteLine("Conexão com o banco estabelecida.");
        }

        // Aplicação do Padrão GoF: Singleton
        // Justificativa: Fornece um ponto único de acesso global aos dados.
        public static ConexaoBanco GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new ConexaoBanco();
            }
            return _instancia;
        }
    }
}