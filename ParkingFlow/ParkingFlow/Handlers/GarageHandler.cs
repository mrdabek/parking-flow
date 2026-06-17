using ParkingFlow.Models;
namespace ParkingFlow.Handlers;

public class GarageHandler
{
    private Garage<Vehicle> garage;

    public GarageHandler(Garage<Vehicle> garage)
    {
        this.garage = garage;
    }
    
    public bool ParkVehicle(Vehicle vehicle)
    {
        return garage.Park(vehicle);
    }
    
    public bool UnparkVehicle(string registrationNumber)
    {
        return garage.Unpark(registrationNumber);
    }
    
    public Vehicle? FindVehicle(string registrationNumber)
    {
        return garage.FindVehicle(registrationNumber);
    }
    
    public IEnumerable<Vehicle> GetAllVehicles()
    {
        return garage;
    }
    
    public int GetCapacity()
    {
        return garage.Capacity;
    }
    
    public int GetVehicleCount()
    {
        int count = 0;

        foreach (var vehicle in garage)
        {
            count++;
        }

        return count;
    }
    
    public Dictionary<string, int> GetVehicleTypeSummary()
    {
        Dictionary<string, int> summary = new();

        foreach (var vehicle in garage)
        {
            string type = vehicle.GetType().Name;

            if (summary.ContainsKey(type))
            {
                summary[type]++;
            }
            else
            {
                summary[type] = 1;
            }
        }

        return summary;
    }
    
    public IEnumerable<Vehicle> SearchByColor(string color)
    {
        foreach (var vehicle in garage)
        {
            if (vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            {
                yield return vehicle;
            }
        }
    }
    
}