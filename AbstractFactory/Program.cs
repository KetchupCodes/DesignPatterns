using System;

// Abstract product A
public interface IButton
{
    void Render();
}

// Concrete product A1 for light theme
public class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Button");
    }
}

// Concrete product A2 for dark theme
public class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Button");
    }
}

// Abstract product B
public interface ICheckbox
{
    void Render();
}

// Concrete product B1 for light theme
public class LightCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Checkbox");
    }
}

// Concrete product B2 for dark theme
public class DarkCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Checkbox");
    }
}

// Abstract factory
public interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete factory for light theme
public class LightGuiFactory : IGuiFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new LightCheckbox();
    }
}

// Concrete factory for dark theme
public class DarkGuiFactory : IGuiFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new DarkCheckbox();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Creating GUI components for light theme
        IGuiFactory lightFactory = new LightGuiFactory();
        IButton lightButton = lightFactory.CreateButton();
        ICheckbox lightCheckbox = lightFactory.CreateCheckbox();

        // Rendering GUI components for light theme
        lightButton.Render();
        lightCheckbox.Render();

        // Creating GUI components for dark theme
        IGuiFactory darkFactory = new DarkGuiFactory();
        IButton darkButton = darkFactory.CreateButton();
        ICheckbox darkCheckbox = darkFactory.CreateCheckbox();

        // Rendering GUI components for dark theme
        darkButton.Render();
        darkCheckbox.Render();
    }
}
