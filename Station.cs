using System.Collections.Generic;

public class Station : ISubject
{
    private List<IObserver> _observers;
    private float _temperature;
    public string State { get; private set; }

    public Station(string state)
    {
        _observers = new List<IObserver>();
        State = state;
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(_temperature, State);
        }
    }

    public void SetTemperature(float temperature)
    {
        _temperature = temperature;
        NotifyObservers();
    }
}
