using ParkingFlow.Handlers;
using ParkingFlow.Models;

namespace ParkingFlow.UI;

public class ConsoleUI
{
    private GarageHandler handler;

    public ConsoleUI(GarageHandler handler)
    {
        this.handler = handler;
    }
    
    public void ShowMainMenu()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== ParkingFlow ===");
            Console.WriteLine("1. List vehicles");
            Console.WriteLine("2. Park vehicle");
            Console.WriteLine("3. Unpark vehicle");
            Console.WriteLine("4. Find vehicle");
            Console.WriteLine("5. Vehicle type summary");
            Console.WriteLine("6. Populate garage");
            Console.WriteLine("0. Exit");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    running = false;
                    break;
                
                case "1":
                    ListVehicles();
                    break;
                
                case "2":
                    ParkVehicle();
                    break;
                
                case "3":
                    UnparkVehicle();
                    break;
                
                case "4":
                    FindVehicle();
                    break;
                
                case "5":
                    ShowVehicleTypeSummary();
                    break;
                
                case "6":
                    PopulateGarage();
                    break;
                
                
                
                

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void PopulateGarage()
    {
        handler.ParkVehicle(new Car
        {
            RegistrationNumber = "CAR123",
            Color = "Red",
            NumberOfWheels = 4,
            FuelType = "Gasoline"
        });

        handler.ParkVehicle(new Boat
        {
            RegistrationNumber = "BOAT1",
            Color = "Blue",
            NumberOfWheels = 0,
            Length = 10
        });

        handler.ParkVehicle(new Motorcycle
        {
            RegistrationNumber = "MC123",
            Color = "Black",
            NumberOfWheels = 2,
            CylinderVolume = 600
        });

        Console.WriteLine("Garage populated.");
        Console.ReadKey();
    }

    private void ShowVehicleTypeSummary()
    {
        var summary = handler.GetVehicleTypeSummary();

        if (summary.Count == 0)
        {
            Console.WriteLine("No vehicles parked.");
        }
        else
        {
            foreach (var item in summary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        Console.ReadKey();
    }

    private void FindVehicle()
    {
        Console.Write("Registration number: ");
        string registrationNumber = Console.ReadLine()!;

        var vehicle = handler.FindVehicle(registrationNumber);

        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not found.");
        }
        else
        {
            Console.WriteLine(
                $"{vehicle.RegistrationNumber} {vehicle.Color}");
        }

        Console.ReadKey();
    }

    private void UnparkVehicle()
    {
        Console.Write("Registration number: ");
        string registrationNumber = Console.ReadLine()!;

        bool success = handler.UnparkVehicle(registrationNumber);

        Console.WriteLine(success
            ? "Vehicle removed."
            : "Vehicle not found.");

        Console.ReadKey();
    }

    private void ParkVehicle()
    {
        Console.Write("Registration number: ");
        string registrationNumber = Console.ReadLine()!;

        Console.Write("Color: ");
        string color = Console.ReadLine()!;

        var car = new Car
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            NumberOfWheels = 4,
            FuelType = "Gasoline"
        };

        bool success = handler.ParkVehicle(car);

        Console.WriteLine(success ? "Vehicle parked." : "Garage is full.");
        Console.ReadKey();
    }

    private void ListVehicles()
    {
        Console.WriteLine("Parked vehicles:");

        bool anyVehicle = false;

        foreach (var vehicle in handler.GetAllVehicles())
        {
            Console.WriteLine($"{vehicle.RegistrationNumber} {vehicle.Color}");
            anyVehicle = true;
        }

        if (!anyVehicle)
        {
            Console.WriteLine("No vehicles parked.");
        }

        Console.ReadKey();
    }
    
    
}
