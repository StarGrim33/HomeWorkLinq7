using System.Collections.Generic;

namespace HomeWorkLinq7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Base basе = new();
            basе.JoinCollections();
        }
    }

    class Base
    {
        private List<Soldier> _firstSquad = new();
        private List<Soldier> _secondSquad = new();

        public Base()
        {
            _firstSquad = ComplicateFirstSquad();
            _secondSquad = ComplicateSecondSquad();
        }

        public void JoinCollections()
        {
            var soldiers = _firstSquad.Where(soldier => soldier.Name.StartsWith("Б"));
            _secondSquad = _secondSquad.Union(soldiers).OrderBy(soldier => soldier.Name).ToList();
            _firstSquad = _firstSquad.Except(soldiers).ToList();

            ShowCollection(_firstSquad);
            ShowCollection(_secondSquad);
        }

        private void ShowCollection(List<Soldier> soldiers)
        {
            Console.WriteLine($"{new string('*', 25)}");

            foreach(Soldier soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }

        private List<Soldier> ComplicateFirstSquad()
        {
            return new List<Soldier>
            {
                new Soldier("Ходков"),
                new Soldier("Бубликов"),
                new Soldier("Кузьмичев"),
                new Soldier("Баринов"),
                new Soldier("Петруш"),
                new Soldier("Борисов")
            };
        }

        private List<Soldier> ComplicateSecondSquad()
        {
            return new List<Soldier>
            {
                new Soldier("Ванин"),
                new Soldier("Цуканов"),
                new Soldier("Козлов"),
                new Soldier("Горячкин"),
                new Soldier("Соцков"),
                new Soldier("Стрельников")
            };
        }
    }

    class Soldier
    {
        public Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}