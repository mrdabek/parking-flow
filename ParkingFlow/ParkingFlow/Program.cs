using ParkingFlow.Handlers;
using ParkingFlow.Models;
using ParkingFlow.UI;

namespace ParkingFlow;

class Program
{
    static void Main(string[] args)
    {
        var garage = new Garage<Vehicle>(10);
        var handler = new GarageHandler(garage);
        var ui = new ConsoleUI(handler);
        
        ui.ShowMainMenu();
    }
}