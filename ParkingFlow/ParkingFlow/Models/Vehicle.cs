namespace ParkingFlow.Models;

public abstract class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }
}