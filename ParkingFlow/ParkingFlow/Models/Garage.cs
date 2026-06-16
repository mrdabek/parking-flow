using System.ComponentModel.Design;
using System.Collections;


namespace ParkingFlow.Models;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T[] vehicles;

    public Garage(int capacity)
    {
        vehicles = new T[capacity];
    }

    public int Capacity
    {
        get { return vehicles.Length;  }
    }

    public bool Park(T vehicle)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return true;
            }
        }
        return false;
    }
    
    public bool Unpark(string registrationNumber)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] != null && vehicles[i].RegistrationNumber.Equals(registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                vehicles[i] = null;
                return true;
            }
        }

        return false;
    }    
    
    public T? FindVehicle(string registrationNumber)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] != null &&
                vehicles[i].RegistrationNumber.Equals(registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                return vehicles[i];
            }
        }
        return null;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}