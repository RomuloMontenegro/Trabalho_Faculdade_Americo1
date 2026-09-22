namespace EnterPsi.Database
{
    public class ConexaoBanco
    {
        private static ConexaoBanco _instancia;
        
        
        public List<Models.Paciente> TabelaPacientes { get; set; }

        
        private ConexaoBanco()
        {
            TabelaPacientes = new List<Models.Paciente>();
            Console.WriteLine("Conexão com o banco estabelecida.");
        }

        // Padrão GoF: Singleton
        // Aqui aplicamos o Singleton para ter um ponto de acesso único aos dados em memória.
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