using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Övning5;

internal class Manager
{
    private IUI ui;
    private IHandler handler;

    public Manager(IUI ui)
    {
        this.ui = ui;
    }

    public void Run()
    {
       // IUI ui = new UI();

        handler = StartManager();

        MainMenu(ui, handler);
    }

    public void MainMenu(IUI ui, IHandler handler)
    {

        while (true)
        {
            ui.Output("Huvud Meny");
            ui.Output("Skriv ett nummer för att navigera genom menyn \n(1, 2, 3 ,4, 5, 6, 0) of your choice"
                + "\n1. Skriv ut allt i garaget"
                + "\n2. Sök efter ett registreringsnummer"
                + "\n3. Lägg till ett fordon till garaget"
                + "\n4. Ta bort ett fordon från garaget"
                + "\n5. Skriv ut hur många fordon av varje typ som finns i garaget"
                + "\n6. Lista fordon efter attribut"
                + "\n7. Starta ett nytt garage"
                + "\n0. Exit the application");
            ConsoleKey input = ui.GetKey();
            ui.Output("\n");
            switch (input)
            {
                case ConsoleKey.D1:
                    ui.Output("Fordon i garaget");
                    ui.PrintList(handler.GetGarage());
                    break;
                case ConsoleKey.D2:
                    ui.Output("Skriv in registreringsnummret du vill hitta.");
                    string regNr = ui.GetInput();
                    ui.PrintVehicle(handler.GetFromRegNr(regNr));
                    break;
                case ConsoleKey.D3:
                    AddVehicle(handler, ui);
                    break;
                case ConsoleKey.D4:
                    RemoveVehicle(handler, ui);
                    break;
                case ConsoleKey.D5:
                    PrintTypes(handler, ui);
                    break;
                case ConsoleKey.D6:
                    FilterVehicles(handler, ui);
                    break;
                case ConsoleKey.D7:
                    handler = StartManager();
                    break;
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                default:
                    ui.Output("Använd korrekt input (0, 1, 2, 3, 4, 5, 6, 7)");
                    break;
            }
            ui.Output("\n");
        }
    }

    private void RemoveVehicle(IHandler currGarage, IUI ui)
    {
        ui.Output("Skriv ut registrerings nummret för fordonet du vill ta bort.");
        string regNr = ui.GetInput();
        IVehicle? vehicle = currGarage.GetFromRegNr(regNr);
        if (vehicle != null)
        {
            currGarage.RemoveVehicle(regNr);
            ui.Output($"Tar bort fordonet:");
            ui.PrintVehicle(vehicle);
        }
        else
        {
            ui.Output($"Det finns inget fordon med registreringsnummret {regNr} i garaget.");
        }
    }

    private void FilterVehicles(IHandler currGarage, IUI ui)
    {
        currGarage.InitFilter();
        string options = "Fordon";

        ui.Output("Vill du välja en viss typ av fordon. (Y/N)");
        if(ui.GetKey() == ConsoleKey.Y)
        {
            string type = ui.GetVehicleType();
            currGarage.Filter("type", type, 0);
            options = options + " av typen " + type;
        }

        bool loop = true;
        while (loop)
        {
            ui.Output("Välj en egenskap att filtrera efter (1)Färg (2)Hjul Eller (0) för att avsluta");
            
            var input = ui.GetKey();

            switch (input)
            {
                case ConsoleKey.D0:
                    ui.Output(options+":");
                    ui.PrintList(currGarage.PrintFilter());
                    return;
                case ConsoleKey.D1:
                    ui.Output("Vilken färg?");
                    var typeS = ui.GetInput();
                    currGarage.Filter("color", typeS, 0);
                    options = options + " med färgen " + typeS;

                    break;
                case ConsoleKey.D2:
                    ui.Output("Antal Hjul:");
                    var typeI = ui.GetNumber();
                    currGarage.Filter("wheels", "", typeI);
                    options = options + " med " + typeI + "hjul";

                    break;
                default:
                    break;

            }
        }
    }

    private void PrintTypes(IHandler currGarage, IUI ui)
    {
        List<string> types = new List<string>{"Car", "Boat", "Bus", "Motorcycle", "Airplane"};

        foreach (var type in types)
        {
            List<IVehicle> lista = currGarage.NrOfType(type);
            ui.Output($"Det finns {lista.Count} fordon av typ {type}");
        }
    }

    private void AddVehicle(IHandler handler, IUI ui)
    {
        if (handler.IsFull())
        {
            ui.Output("Garaget är fullt, så kan inte lägga till fordon.");
            return;
        }

        var type = ui.GetVehicleType();

        string regNr = "";

        bool loop = true;
        while (loop)
        {
            ui.Output("Skriv in fordonets registreringsnummer");
            regNr = ui.GetInput();
            if (handler.GetFromRegNr(regNr) != null)
            {
                ui.Output($"Registrerings nummret {regNr} finns redan, välj ett annat!");
            }
            else
            {
                loop = false;
            }
        }

        string color;
        ui.Output("Skriv in fordonets färg");
        color = ui.GetInput();

        int wheels;
        ui.Output("Skriv in antalet hjul på fordonet");
        wheels = ui.GetNumber();

        if (type == "Car")
        {
            ui.Output("Välj cylinder storlek för bilen.");
            var cylinder = ui.GetNumber();
            handler.AddVehicle(new Car(regNr, color, wheels, cylinder));
        }
        else if (type == "Airplane")
        {
            ui.Output("Välj antalet motorer för planet.");
            var engines = ui.GetNumber();
            handler.AddVehicle(new Airplane(regNr, color, wheels, engines));
        }
        else if (type == "Motorcycle")
        {
            ui.Output("Välj bränsletyp för motorcykeln.");
            var fuel = ui.GetInput();
            handler.AddVehicle(new Motorcycle(regNr, color, wheels, fuel));
        }
        else if (type == "Bus")
        {
            ui.Output("Välj antalet platser på bussen.");
            var seats = ui.GetNumber();
            handler.AddVehicle(new Bus(regNr, color, wheels, seats));
        }
        else if (type == "Boat")
        {
            ui.Output("Välj längden på båten.");
            var length = ui.GetNumber();
            handler.AddVehicle(new Boat(regNr, color, wheels, length));
        }

        ui.Output("Lade till fordonet:");
        ui.PrintVehicle(handler.GetFromRegNr(regNr));

    }

    //Startmenyn, välj startgarage
    public IHandler StartManager()
    {
        IHandler handler; 

        ui.Output("Vill du:"
            + "\n1. Starta ett nytt garage"
            + "\n2. Starta med en förinitialisert garage (Kapacitet 10, 5 fordon redan i garaget)");

        while(true)
        {
            var keyPressed = ui.GetKey();
            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    return NewManager();
                case ConsoleKey.D2:
                    handler = new GarageHandler(10);
                    handler.InitGarage();
                    return handler;
                default:
                    Console.WriteLine("Skriv in en korrekt input (1, 2)");
                    break;
            }
        }

    }

    //Skapar ett nytt garage
    public IHandler NewManager()
    {
        ui.Output("Skriv in hur många fordon som ska få plats i garaget.");
        int capacity = ui.GetNumber();
        IHandler handler = new GarageHandler(capacity);
        return handler;
    }

}

