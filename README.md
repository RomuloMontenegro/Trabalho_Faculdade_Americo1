# EnterPsi - Sistema de Gestão Clínica

Aplicação de console desenvolvida em C# para otimizar e digitalizar o acompanhamento psicoterapêutico, centralizando dados de prontuários e registros de sessões clínicas. Trabalho prático desenvolvido para a disciplina de Projeto e Arquitetura de Sistemas.

## 👥 Equipe
* Rômulo Azevedo Montenegro Neto
* João Gabriel de Holanda Montenegro

## ⚙️ Funcionalidades (CRUD)
O sistema foca na gestão do ciclo de vida do atendimento clínico através de dois fluxos principais:

1. **Gestão de Pacientes (CRUD Completo)**
   * **Create:** Cadastro de novos pacientes com dados de identificação e demanda clínica.
   * **Read:** Listagem de todos os pacientes ativos no sistema.
   * **Update:** Atualização do status e das demandas clínicas ao longo do tratamento.
   * **Delete:** Arquivamento e exclusão de registros (alta ou interrupção do acompanhamento).

2. **Registro de Evolução / Sessões**
   * Criação e associação de sessões de atendimento aos respectivos pacientes, registrando a data e as anotações clínicas diárias.

## 🏛️ Arquitetura e Padrões de Projeto
Para garantir a organização, coesão e baixo acoplamento do código, foram aplicados os seguintes padrões orientados a objetos:

### Padrões GoF (Design Patterns)
* **Singleton:** Aplicado na classe `ConexaoBanco` para garantir que apenas uma instância do gerenciador de dados seja criada e acessada globalmente durante a execução do sistema.
* **Factory Method:** Utilizado na classe `PacienteFactory` para encapsular e centralizar a lógica de instanciação de novos pacientes.

### Padrões GRASP
* **Controller:** Implementado na classe `PacienteController`, que atua como intermediária entre a interface (menus de console) e a camada de dados, recebendo e coordenando as requisições.
* **Creator:** Aplicado na classe `Paciente`, que assume a responsabilidade de instanciar objetos do tipo `Sessao`. Como as sessões dependem e estão contidas no histórico de um paciente, a classe agregadora atua como a sua criadora.

## 🚀 Como Executar
1. Certifique-se de que possui o [.NET SDK](https://dotnet.microsoft.com/download) instalado no seu computador.
2. Clone este repositório ou faça o download dos arquivos.
3. Abra o terminal na pasta raiz do projeto.
4. Execute o comando:
   ```bash
   dotnet run
