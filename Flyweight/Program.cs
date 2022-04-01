using System;
using System.Collections;

namespace Flyweight
{

    public abstract class House
    {
        protected int Levels;
        protected int Num;
        protected string Address;
        public abstract void Build(int num, string street);
    }

    public class BrickHouse : House
    {
        double EarthK;
        double Cost;
        public BrickHouse(int l)
        {
            Levels = l;
        }
        public override void Build(int num, string street)
        {
            Num = num;
            Address = street;
            if (Levels > 9) EarthK = 1.5;
            else EarthK = 1;
            Cost = Levels * 10000 * EarthK;
            Console.WriteLine("Build {0} levels brick house. Cost is {1} .This situated in {2} {3}", Levels, Cost, Num, Address);
        }
    }

    public class PanelHouse : House
    {
        double EarthK;
        double Cost;

        public PanelHouse(int l)
        {
            Levels = l;
        }

        public override void Build(int num, string street)
        {
            Num = num;
            Address = street;
            if (Levels > 9) EarthK = 1.2;
            else EarthK = 1;
            Cost = Levels * 7000 * EarthK;
            Console.WriteLine("Build {0} levels panel house. Cost is {1}. This situated in {2}, {3}", Levels, Cost, Num, Address);
        }
    }

    public class HouseFactory
    {
        public Hashtable houses;

        public HouseFactory()
        {
            houses = new Hashtable();
            houses.Add("1 Palermo st", new BrickHouse(5));
            houses.Add("2 Palermo st", new PanelHouse(15));
            houses.Add("2 King st", new BrickHouse(17));
        }

        public House GetHouse(string adress)
        {
            if (houses.ContainsKey(adress))
            {
                return houses[adress] as House;
            }
            else
            {
                int l = 3;
                Console.WriteLine("House not exist yet. Build? if yes, input Enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("How many levels do you want?");
                    l = int.Parse(Console.ReadLine());
                }
                else return null;

                houses.Add(adress, new BrickHouse(l));
                return houses[adress] as House;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string address = "King st";
            HouseFactory factory = new HouseFactory();
            House h;
            //we would like build 5 houses on King street. 2th house are exist before. We need return it without creating.
            for (int i = 1; i < 6; i++)  
            {
                h = factory.GetHouse(i + " " + address);
                if (h != null)
                    h.Build(i, address.Split(' ')[0] + " " + address.Split(' ')[1]);
            }
        }
    }
}
