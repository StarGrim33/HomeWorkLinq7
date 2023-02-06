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
            var unitedCollection = _firstSquad.Where(soldier => soldier.Name.StartsWith("Б")).Union(_secondSquad).OrderBy(soldier => soldier.Name).ToList();
            ShowCollection(unitedCollection);
        }

        private void ShowCollection(List<Soldier> soldiers)
        {
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