using System;
using System.Collections.Generic;

public class Program
{
    private static List<Station> stations = new List<Station>();
    private static List<Monitor> monitors = new List<Monitor>();

    public static void Main(string[] args)
    {
        int option = -1;
        while (option != 0)
        {
            Console.WriteLine("Menu de Operações:");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Criar Nova Estação");
            Console.WriteLine("2 - Atualizar Estação");
            Console.WriteLine("3 - Remover Estação");
            Console.WriteLine("4 - Criar Monitor");
            Console.WriteLine("5 - Editar Monitor");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateStation();
                    break;
                case 2:
                    UpdateStation();
                    break;
                case 3:
                    RemoveStation();
                    break;
                case 4:
                    CreateMonitor();
                    break;
                case 5:
                    EditMonitor();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static void CreateStation()
    {
        Console.WriteLine("Digite a UF da nova estação:");
        string state = Console.ReadLine();
        Station station = new Station(state);
        stations.Add(station);
        Console.WriteLine("Nova estação criada.");
    }

    private static void UpdateStation()
    {
        if (stations.Count == 0)
        {
            Console.WriteLine("Nenhuma estação disponível.");
            return;
        }

        Console.WriteLine("Selecione a estação a ser atualizada:");
        for (int i = 0; i < stations.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Estação em {stations[i].State}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        Station station = stations[index];

        Console.WriteLine("Digite a nova temperatura:");
        float temp = float.Parse(Console.ReadLine());
        station.SetTemperature(temp);
    }

    private static void RemoveStation()
    {
        if (stations.Count == 0)
        {
            Console.WriteLine("Nenhuma estação disponível.");
            return;
        }

        Console.WriteLine("Selecione a estação a ser removida:");
        for (int i = 0; i < stations.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Estação em {stations[i].State}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        stations.RemoveAt(index);
        Console.WriteLine("Estação removida.");
    }

    private static void CreateMonitor()
    {
        Monitor monitor = new Monitor();
        monitors.Add(monitor);
        Console.WriteLine("Novo monitor criado.");
    }

    private static void EditMonitor()
    {
        if (monitors.Count == 0)
        {
            Console.WriteLine("Nenhum monitor disponível.");
            return;
        }

        Console.WriteLine("Selecione o monitor:");
        for (int i = 0; i < monitors.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Monitor {i + 1}");
        }
        int monitorIndex = int.Parse(Console.ReadLine()) - 1;
        Monitor monitor = monitors[monitorIndex];

        Console.WriteLine("Selecione a estação:");
        for (int i = 0; i < stations.Count; i++)
        {
            Console.WriteLine($"{i + 1} - Estação em {stations[i].State}");
        }
        int stationIndex = int.Parse(Console.ReadLine()) - 1;
        Station station = stations[stationIndex];

        Console.WriteLine("1 - Adicionar monitor à estação");
        Console.WriteLine("2 - Remover monitor da estação");
        int action = int.Parse(Console.ReadLine());

        if (action == 1)
        {
            station.AddObserver(monitor);
            Console.WriteLine("Monitor adicionado à estação.");
        }
        else if (action == 2)
        {
            station.RemoveObserver(monitor);
            Console.WriteLine("Monitor removido da estação.");
        }
        else
        {
            Console.WriteLine("Ação inválida!");
        }
    }
}
