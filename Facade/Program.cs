using System;
//  It defines a higher-level interface that makes the subsystem easier to use. 

// Subsystem 1
public class CPU
{
    public void Start()
    {
        Console.WriteLine("CPU is starting...");
    }

    public void Shutdown()
    {
        Console.WriteLine("CPU is shutting down...");
    }
}

// Subsystem 2
public class Memory
{
    public void Load()
    {
        Console.WriteLine("Memory is loading...");
    }

    public void Unload()
    {
        Console.WriteLine("Memory is unloading...");
    }
}

// Subsystem 3
public class HardDrive
{
    public void Read()
    {
        Console.WriteLine("Hard Drive is reading...");
    }

    public void Write()
    {
        Console.WriteLine("Hard Drive is writing...");
    }
}

// Facade
public class ComputerFacade
{
    private CPU cpu;
    private Memory memory;
    private HardDrive hardDrive;

    public ComputerFacade()
    {
        cpu = new CPU();
        memory = new Memory();
        hardDrive = new HardDrive();
    }

    // Method to start the computer
    public void StartComputer()
    {
        cpu.Start();
        memory.Load();
        hardDrive.Read();
        Console.WriteLine("Computer started successfully.");
    }

    // Method to shut down the computer
    public void ShutdownComputer()
    {
        cpu.Shutdown();
        memory.Unload();
        hardDrive.Write();
        Console.WriteLine("Computer shut down successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a facade for the computer subsystem
        ComputerFacade computerFacade = new ComputerFacade();

        // Start the computer using the facade
        computerFacade.StartComputer();

        // Shut down the computer using the facade
        computerFacade.ShutdownComputer();
    }
}