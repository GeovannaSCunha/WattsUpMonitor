// Autora: Geovanna Cunha
using System;
using System.Collections.Generic;
using System.Linq;

namespace WattsUpMonitor
{
    // Classe base: representa um Evento genérico (falhas ou alertas no hospital)
    class Evento
    {
        public DateTime Data { get; set; } // Data e hora do evento
        public string Descricao { get; set; } // Descrição do evento

        // Construtor: inicializa o evento com a data atual e a descrição
        public Evento(string descricao)
        {
            Data = DateTime.Now;
            Descricao = descricao;
        }

        // Método virtual: permite que classes derivadas sobrescrevam como exibir o evento
        public virtual void Exibir()
        {
            Console.WriteLine($"{Data} - {Descricao}");
        }
    }

    // Classe derivada: representa um Alerta, herda de Evento e adiciona um nível de criticidade
    class Alerta : Evento
    {
        public string Nivel { get; set; } // Nível de criticidade do alerta: Baixo, Médio ou Alto

        // Construtor: inicializa a descrição e o nível do alerta
        public Alerta(string descricao, string nivel) : base(descricao)
        {
            Nivel = nivel;
        }

        // Sobrescreve o método Exibir para mostrar o alerta com destaque e nível
        public override void Exibir()
        {
            Console.WriteLine($"{Data} - [ALERTA - {Nivel}] {Descricao}");
        }
    }

    // Classe responsável por gerenciar os eventos e gerar relatórios
    class SistemaMonitoramento
    {
        private List<Evento> eventos = new List<Evento>(); // Lista de eventos registrados

        // Método para registrar uma falha de energia hospitalar
        public void RegistrarFalha(string descricao)
        {
            eventos.Add(new Evento("[FALHA DE ENERGIA] " + descricao));
            Console.WriteLine("Falha de energia registrada com sucesso.");
        }

        // Método para gerar um alerta cibernético em caso de ameaça
        public void GerarAlerta(string descricao, string nivel)
        {
            eventos.Add(new Alerta("[ALERTA CIBERNÉTICO] " + descricao, nivel));
            Console.WriteLine("Alerta gerado com sucesso.");
        }

        // Exibe todos os logs de eventos registrados até o momento
        public void ExibirLogs()
        {
            Console.WriteLine("\n==== Logs de Eventos de Falhas e Alertas no Hospital ====");
            foreach (var e in eventos)
            {
                e.Exibir(); // Chama o método Exibir, que pode ser de Evento ou Alerta
            }
        }

        // Gera um relatório resumo do status atual do sistema
        public void RelatorioStatus()
        {
            int totalFalhas = eventos.Count(e => !(e is Alerta)); // Conta eventos que são falhas
            int totalAlertas = eventos.Count(e => e is Alerta);   // Conta eventos que são alertas

            Console.WriteLine("\n==== Relatório de Status ====");
            Console.WriteLine($"Total de falhas de energia registradas: {totalFalhas}");
            Console.WriteLine($"Total de alertas cibernéticos gerados: {totalAlertas}");
            Console.WriteLine($"Total geral de eventos: {eventos.Count}");
        }
    }

    // Classe principal do programa
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n==== Sistema de Monitoramento de Falhas de Energia Hospitalar ====\n");

            // Listas pré-definidas de setores e tipos escolha do usuário
            var setoresHospitalares = new List<string> { "UTI", "Centro Cirúrgico", "Emergência", "Enfermarias", "Laboratório", "Radiologia" };
            var tiposFalha = new List<string> { "Queda total de energia", "Queda parcial", "Flutuação de tensão", "Falha no gerador" };
            var tiposAmeaca = new List<string>
            {
                "Tentativa de acesso não autorizado",
                "Falha no sistema de backup",
                "Desativação de equipamentos críticos",
                "Alteração não autorizada em registros"
            };

            // Simples autenticação para segurança do sistema
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            // Verifica se o usuário e senha são válidos
            if (usuario != "admin" || senha != "123")
            {
                Console.WriteLine("Login inválido. Encerrando...");
                return; // Encerra o programa se o login falhar
            }

            // Instancia o sistema de monitoramento
            SistemaMonitoramento sistema = new SistemaMonitoramento();
            bool continuar = true; // Controle do loop principal

            // Loop principal do menu
            while (continuar)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1 - Registrar Falha de Energia");
                Console.WriteLine("2 - Gerar Alerta Cibernético");
                Console.WriteLine("3 - Exibir Logs de Eventos");
                Console.WriteLine("4 - Relatório de Status");
                Console.WriteLine("5 - Sair");
                Console.Write("\nDigite aqui: ");

                try
                {
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n=== Registrar Falha de Energia ===\n");

                            // Exibe lista de setores e permite seleção
                            Console.WriteLine("Setores disponíveis:");
                            for (int i = 0; i < setoresHospitalares.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {setoresHospitalares[i]}");
                            }
                            Console.Write("Selecione o setor afetado: ");
                            int setorIndex = int.Parse(Console.ReadLine()) - 1;
                            string setor = setoresHospitalares[setorIndex];

                            // Exibe tipos de falha e permite seleção
                            Console.WriteLine("\nTipos de falha:");
                            for (int i = 0; i < tiposFalha.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {tiposFalha[i]}");
                            }
                            Console.Write("Selecione o tipo de falha: ");
                            int falhaIndex = int.Parse(Console.ReadLine()) - 1;
                            string tipoFalha = tiposFalha[falhaIndex];

                            // Solicita detalhes adicionais da falha
                            Console.Write("\nInforme detalhes adicionais (opcional): ");
                            string detalhes = Console.ReadLine();

                            // Monta a descrição completa do evento
                            string descricao = $"Setor: {setor} | Tipo: {tipoFalha}";
                            if (!string.IsNullOrWhiteSpace(detalhes))
                            {
                                descricao += $" | Detalhes: {detalhes}";
                            }

                            sistema.RegistrarFalha(descricao);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\n=== Gerar Alerta Cibernético ===\n");

                            // Exibe tipos de ameaça e permite seleção
                            Console.WriteLine("Tipos de ameaça cibernética:");
                            for (int i = 0; i < tiposAmeaca.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {tiposAmeaca[i]}");
                            }
                            Console.Write("Selecione o tipo de ameaça: ");
                            int ameacaIndex = int.Parse(Console.ReadLine()) - 1;
                            string tipoAmeaca = tiposAmeaca[ameacaIndex];

                            // Solicita o nível de alerta
                            Console.Write("\nNível do alerta (1-Baixo, 2-Médio, 3-Alto): ");
                            string nivel = Console.ReadLine() switch
                            {
                                "1" => "Baixo",
                                "2" => "Médio",
                                "3" => "Alto",
                                _ => throw new ArgumentException("Opção inválida") // Lança erro se a opção for inválida
                            };

                            // Solicita detalhes adicionais do alerta
                            Console.Write("\nInforme detalhes adicionais (opcional): ");
                            string detalhesAmeaca = Console.ReadLine();

                            // Monta a descrição completa do alerta
                            string descricaoAmeaca = $"Ameaça: {tipoAmeaca}";
                            if (!string.IsNullOrWhiteSpace(detalhesAmeaca))
                            {
                                descricaoAmeaca += $" | Detalhes: {detalhesAmeaca}";
                            }

                            sistema.GerarAlerta(descricaoAmeaca, nivel);
                            break;

                        case 3:
                            Console.Clear();
                            sistema.ExibirLogs(); // Mostra todos os eventos registrados
                            break;

                        case 4:
                            Console.Clear();
                            sistema.RelatorioStatus(); // Exibe resumo de falhas e alertas
                            break;

                        case 5:
                            continuar = false; // Sai do loop e encerra o programa
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                // Tratamento de erros para entradas inválidas
                catch (FormatException)
                {
                    Console.WriteLine("Erro: entrada inválida. Por favor, digite um número.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Erro: opção selecionada não existe.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }

            Console.WriteLine("Sistema encerrado."); // Mensagem final de encerramento
        }
    }
}
