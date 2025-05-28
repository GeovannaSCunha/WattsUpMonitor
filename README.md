## Integrantes

- Geovanna Silva Cunha - rm97736
- Victor Camargo Maciel - rm98384

# ⚡WattsUpMonitor

Sistema de Monitoramento de Falhas de Energia Hospitalar e Alertas Cibernéticos.

## Finalidade

O **WattsUpMonitor** é uma aplicação desenvolvida em C# com o objetivo de registrar, monitorar e gerar relatórios sobre falhas de energia em ambientes hospitalares, bem como emitir alertas relacionados a ameaças cibernéticas.

A ferramenta possibilita:
- Registro detalhado de falhas elétricas, identificando setores afetados e tipos de falha.
- Geração de alertas cibernéticos com níveis de criticidade.
- Exibição de logs completos dos eventos registrados.
- Geração de relatórios sumarizados sobre o status geral do sistema.

Este sistema simula uma interface de linha de comando (CLI) para fins educacionais e de demonstração.

## Dependências

- .NET Core / .NET 6.0+: Framework necessário para compilar e executar a aplicação.
- Não são necessárias bibliotecas ou pacotes externos adicionais.

## Instruções de Execução
1. Pré-requisitos
- .NET SDK 6.0 ou superior instalado.
- Editor de código recomendado: Visual Studio 2022.

2. Passos para executar:
- Clone o repositório:
`https://github.com/GeovannaSCunha/WattsUpMonitor.git`

- Navegue até o diretório:
  `cd WattsUpMonitor`

- Compile o projeto:
`dotnet build`

- Execute a aplicação:
`dotnet run`

3. Login de acesso:
- **Usuário:** admin
- **Senha:** 123

Obs: Apenas com essas credenciais é possível acessar as funcionalidades do sistema.

4. Estrutura de Pastas
```
wattsupmonitor/
├── .gitattributes           # Configuração de atributos Git
├── .gitignore               # Arquivos e pastas ignorados pelo Git
├── Program.cs               # Código principal da aplicação
├── README.md                # Documentação do projeto
├── WattsUpMonitor.csproj    # Arquivo de configuração do projeto C#
└── WattsUpMonitor.sln       # Solução que agrupa o projeto
```

## Funcionalidades Principais

- Registrar Falhas de Energia: identifica setor e tipo de falha.
- Gerar Alertas Cibernéticos: define tipo de ameaça e nível de criticidade.
- Visualizar Logs: exibe todos os eventos registrados no sistema.
- Relatório de Status: resumo das falhas e alertas cadastrados.


