# EnterPsi - Sistema de Gestão Clínica

Aplicação de console desenvolvida em C# para otimizar e digitalizar o acompanhamento psicoterapêutico, centralizando dados de prontuários e registros de sessões clínicas. Trabalho prático desenvolvido para a disciplina de Projeto e Arquitetura de Sistemas.

## 👥 Equipe
* Rômulo Azevedo Montenegro Neto
* João Gabriel de Holanda Montenegro

## ⚙️ Funcionalidades (2 CRUDs Completos)
O sistema atende aos requisitos de avaliação da disciplina através de dois fluxos principais com todas as operações essenciais (Create, Read, Update, Delete):

1. **Gestão de Pacientes (CRUD 1)**
   * **Create:** Cadastro de novos pacientes com dados de identificação e demanda clínica.
   * **Read:** Listagem de todos os pacientes ativos no sistema.
   * **Update:** Atualização da demanda clínica ao longo do tratamento.
   * **Delete:** Exclusão de registros do sistema.

2. **Registro de Evolução / Sessões (CRUD 2)**
   * **Create:** Criação e associação de sessões de atendimento aos respectivos pacientes.
   * **Read:** Listagem do histórico de sessões de um paciente específico.
   * **Update:** Edição de anotações clínicas de sessões já realizadas.
   * **Delete:** Exclusão de sessões registradas indevidamente.

## 🏛️ Arquitetura e Padrões de Projeto
Para garantir a organização e o baixo acoplamento, cumprindo as exigências do projeto, aplicamos os seguintes padrões:

### Padrões GoF (Design Patterns)
* **Singleton:** Aplicado na classe `ConexaoBanco` para garantir uma instância única global de acesso aos dados em memória.
* **Factory Method:** Utilizado na classe `PacienteFactory` para centralizar a criação de instâncias de pacientes.

### Padrões GRASP
* **Controller:** Implementado nas classes `PacienteController` e `SessaoController`. Ambas atuam como intermediárias entre a interface (menus de console) e a camada de dados, separando as regras de negócio.
* **Creator:** Aplicado na classe `Paciente` para instanciar objetos `Sessao`, uma vez que a evolução clínica pertence fortemente ao escopo do histórico do paciente.

## 🚀 Como Executar
1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone este repositório ou baixe os arquivos ZIP.
3. Abra o terminal na pasta raiz do projeto.
4. Execute o comando:
   ```bash
   dotnet run
