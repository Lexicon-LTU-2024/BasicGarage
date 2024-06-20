using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    internal class UI: IUI
    {

        public string GetInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("Skriv input");
            }
        }

        public int GetNumber()
        {
            do
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int answer))
                {
                    if(answer < 0)
                    {
                        Console.WriteLine("Skriv ett positivt nummer");
                    }
                    else
                    {
                        return answer;
                    }
                }
                else
                {
                    Console.WriteLine("Skriv ett positivt nummer");
                }
            } while (true);
        }

        public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

        public void Output(string input)
        {
            Console.WriteLine(input);
       }

        public void PrintList(List<IVehicle> list)
        {
            foreach (var vehicle in list)
            {
                PrintVehicle(vehicle);
            }
        }

        public void PrintVehicle(IVehicle? vehicle)
        {
            if (vehicle == null)
            {
                Console.WriteLine("Kan inte hitta fordonet.");
            }
            else {
                Console.WriteLine(vehicle.Stats());
            }
        }

        public String GetVehicleType()
        {
            Console.WriteLine("Välj vilken typ av fordon: " +
                "(1: Car, 2: Airplane, 3: Motorcycle, 4: Bus, 5: Boat)");
            while (true)
            {
                //string input = GetInput();
                ConsoleKey input = GetKey();
                switch (input)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Fordons typ: Car");
                        return "Car";
                    case ConsoleKey.D2:
                        Console.WriteLine("Fordons typ: Airplane");
                        return "Airplane";
                    case ConsoleKey.D3:
                        Console.WriteLine("Fordons typ: Motorcycle");
                        return "Motorcycle";
                    case ConsoleKey.D4:
                        Console.WriteLine("Fordons typ: Bus");
                        return "Bus";
                    case ConsoleKey.D5:
                        Console.WriteLine("Fordons typ: Boat");
                        return "Boat";
                    default:
                        Console.WriteLine("Inte en korrekt input");
                        break;
                }

            }
        }
    }
}
