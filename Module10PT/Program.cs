using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseConstruction
{
    // Интерфейсы
    public interface IPart
    {
        bool IsBuilt { get; }
        void Build();
    }

    public interface IWorker
    {
        void Work(House house);
    }

    // Классы для частей дома
    public class House
    {

        public Basement Basement { get; set; }
        public List<Wall> Walls { get; private set; }
        public List<Window> Windows { get; private set; }
        public Door Door { get; set; }
        public Roof Roof { get; set; }


        public House()
        {
            Walls = new List<Wall>();
            Windows = new List<Window>();
        }

        public void ShowHouse()
        {
            Console.WriteLine("    ______ ");
            Console.WriteLine("   /      \\ ");
            Console.WriteLine("  /________\\ ");
            Console.WriteLine("  |   __   | ");
            Console.WriteLine("  |  |  |  | ");
            Console.WriteLine("  |  |__|  | ");
            Console.WriteLine("  |________| ");
        }
    }

    public class Basement : IPart
    {
        public bool IsBuilt { get; private set; }
        public void Build() => IsBuilt = true;
    }

    public class Wall : IPart
    {
        public bool IsBuilt { get; private set; }
        public void Build() => IsBuilt = true;
    }

    public class Window : IPart
    {
        public bool IsBuilt { get; private set; }
        public void Build() => IsBuilt = true;
    }

    public class Door : IPart
    {
        public bool IsBuilt { get; private set; }
        public void Build() => IsBuilt = true;
    }

    public class Roof : IPart
    {
        public bool IsBuilt { get; private set; }
        public void Build() => IsBuilt = true;
    }

    // Классы для работников
    public class Worker : IWorker
    {
        public void Work(House house)
        {
            if (house.Basement == null)
            {
                house.Basement = new Basement();
                house.Basement.Build();
            }
            else if (house.Walls.Count < 4)
            {
                var wall = new Wall();
                wall.Build();
                house.Walls.Add(wall);
            }
            else if (house.Windows.Count < 4)
            {
                var window = new Window();
                window.Build();
                house.Windows.Add(window);
            }
            else if (house.Door == null)
            {
                house.Door = new Door();
                house.Door.Build();
            }
            else if (house.Roof == null)
            {
                house.Roof = new Roof();
                house.Roof.Build();
            }
        }
    }

    public class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            Console.WriteLine("Отчет бригадира:");
            Console.WriteLine($"Фундамент - {(house.Basement?.IsBuilt == true ? "построен" : "не построен")}");
            Console.WriteLine($"Стены - {house.Walls.Count(w => w.IsBuilt)}/4 построены");
            Console.WriteLine($"Окна - {house.Windows.Count(w => w.IsBuilt)}/4 установлены");
            Console.WriteLine($"Дверь - {(house.Door?.IsBuilt == true ? "установлена" : "не установлена")}");
            Console.WriteLine($"Крыша - {(house.Roof?.IsBuilt == true ? "установлена" : "не установлена")}");
        }
    }

    public class Team
    {
        private List<IWorker> workers;
        private TeamLeader leader;

        public Team(TeamLeader teamLeader)
        {
            workers = new List<IWorker>();
            leader = teamLeader;
        }

        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }

        public void BuildHouse(House house)
        {
            while (house.Walls.Count < 4 || house.Windows.Count < 4 || house.Door == null || house.Roof == null)
            {
                foreach (var worker in workers)
                {
                    worker.Work(house);
                }
                leader.Work(house);
            }

            Console.WriteLine("Строительство дома завершено!");
            house.ShowHouse();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team(new TeamLeader());

            for (int i = 0; i < 4; i++)
            {
                team.AddWorker(new Worker());
            }

            team.BuildHouse(house);

            Console.ReadKey();
        }
    }
}