using System;

public class Monitor : IObserver
{
    public void Update(float temperature, string state)
    {
        Console.WriteLine($"Temperatura atual da estação em {state}: {temperature}ºC");
    }
}
