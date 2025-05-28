using System;
using System.Collections.Generic;
using System.Linq;

namespace WattsUpMonitor
{
    // Classe base: Evento (falhas e alertas de energia no hospital)
    class Evento
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public Evento(string descricao)
        {
            Data = DateTime.Now;
            Descricao = descricao;
        }

        public virtual void Exibir()
        {
            Console.WriteLine($"{Data} - {Descricao}");
        }
    }

    // Classe derivada: Alerta (herança) com nível de criticidade
    class Alerta : Evento
    {
        public string Nivel { get; set; }

        public Alerta(string descricao, string nivel) : base(descricao)
        {
            Nivel = nivel;
        }

        public override void Exibir()
        {
            Console.WriteLine($"{Data} - [ALERTA - {Nivel}] {Descricao}");
        }
    }

    // Classe para registro e relatório
    class SistemaMonitoramento
    {
        private List<Evento> eventos = new List<Evento>();

        // Registrar falha de energia hospitalar 
        public void RegistrarFalha(string descricao)
        {
            eventos.Add(new Evento("[FALHA DE ENERGIA] " + descricao));
            Console.WriteLine("Falha de energia registrada com sucesso.");
        }

        // Gerar alerta cibernético para falhas críticas
        public void GerarAlerta(string descricao, string nivel)
        {
            eventos.Add(new Alerta("[ALERTA CIBERNÉTICO] " + descricao, nivel));
            Console.WriteLine("Alerta gerado com sucesso.");
        }

        // Exibir todos os logs de eventos registrados
        public void ExibirLogs()
        {
            Console.WriteLine("\n==== Logs de Eventos de Falhas e Alertas no Hospital ====");
            foreach (var e in eventos)
            {
                e.Exibir();
            }
        }

        // Relatório resumo do status do sistema
        public void RelatorioStatus()
        {
            int totalFalhas = eventos.Count(e => !(e is Alerta));
            int totalAlertas = eventos.Count(e => e is Alerta);

            Console.WriteLine("\n==== Relatório de Status ====");
            Console.WriteLine($"Total de falhas de energia registradas: {totalFalhas}");
            Console.WriteLine($"Total de alertas cibernéticos gerados: {totalAlertas}");
            Console.WriteLine($"Total geral de eventos: {eventos.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n==== Sistema de Monitoramento de Falhas de Energia Hospitalar ====\n");

            // Dados pré-definidos para seleção
            var setoresHospitalares = new List<string> { "UTI", "Centro Cirúrgico", "Emergência", "Enfermarias", "Laboratório", "Radiologia" };
            var tiposFalha = new List<string> { "Queda total de energia", "Queda parcial", "Flutuação de tensão", "Falha no gerador" };
            var tiposAmeaca = new List<string>
            {
                "Tentativa de acesso não autorizado",
                "Falha no sistema de backup",
                "Desativação de equipamentos críticos",
                "Alteração não autorizada em registros"
            };

            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (usuario != "admin" || senha != "123")
            {
                Console.WriteLine("Login inválido. Encerrando...");
                return;
            }

            SistemaMonitoramento sistema = new SistemaMonitoramento();
            bool continuar = true;

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

                            // Seleção de setor
                            Console.WriteLine("Setores disponíveis:");
                            for (int i = 0; i < setoresHospitalares.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {setoresHospitalares[i]}");
                            }
                            Console.Write("Selecione o setor afetado: ");
                            int setorIndex = int.Parse(Console.ReadLine()) - 1;
                            string setor = setoresHospitalares[setorIndex];

                            // Seleção de tipo de falha
                            Console.WriteLine("\nTipos de falha:");
                            for (int i = 0; i < tiposFalha.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {tiposFalha[i]}");
                            }
                            Console.Write("Selecione o tipo de falha: ");
                            int falhaIndex = int.Parse(Console.ReadLine()) - 1;
                            string tipoFalha = tiposFalha[falhaIndex];

                            // Detalhes adicionais
                            Console.Write("\nInforme detalhes adicionais (opcional): ");
                            string detalhes = Console.ReadLine();

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

                            // Seleção de ameaça
                            Console.WriteLine("Tipos de ameaça cibernética:");
                            for (int i = 0; i < tiposAmeaca.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} - {tiposAmeaca[i]}");
                            }
                            Console.Write("Selecione o tipo de ameaça: ");
                            int ameacaIndex = int.Parse(Console.ReadLine()) - 1;
                            string tipoAmeaca = tiposAmeaca[ameacaIndex];

                            // Nível de alerta
                            Console.Write("\nNível do alerta (1-Baixo, 2-Médio, 3-Alto): ");
                            string nivel = Console.ReadLine() switch
                            {
                                "1" => "Baixo",
                                "2" => "Médio",
                                "3" => "Alto",
                                _ => throw new ArgumentException("Opção inválida")
                            };

                            // Detalhes adicionais
                            Console.Write("\nInforme detalhes adicionais (opcional): ");
                            string detalhesAmeaca = Console.ReadLine();

                            string descricaoAmeaca = $"Ameaça: {tipoAmeaca}";
                            if (!string.IsNullOrWhiteSpace(detalhesAmeaca))
                            {
                                descricaoAmeaca += $" | Detalhes: {detalhesAmeaca}";
                            }

                            sistema.GerarAlerta(descricaoAmeaca, nivel);
                            break;

                        case 3:
                            Console.Clear();
                            sistema.ExibirLogs();
                            break;

                        case 4:
                            Console.Clear();
                            sistema.RelatorioStatus();
                            break;

                        case 5:
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
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

            Console.WriteLine("Sistema encerrado.");
        }
    }
}