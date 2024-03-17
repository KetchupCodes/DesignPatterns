using System;
using System.Collections.Generic;

// Subject interface
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Observer interface
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Concrete subject
public class WeatherData : ISubject
{
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    // This method is called whenever weather measurements change
    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }
}

// Concrete observer
public class CurrentConditionsDisplay : IObserver
{
    private float temperature;
    private float humidity;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData();

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();

        weatherData.RegisterObserver(currentDisplay);

        weatherData.SetMeasurements(80, 65, 30.4f);
    }
}
