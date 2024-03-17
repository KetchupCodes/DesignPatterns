using System;
using System.Collections.Generic;

// Define the interface for the sorting strategy
public interface ISortStrategy<T> where T : IComparable<T>
{
    void Sort(List<T> items);
}

// Concrete strategy implementations
public class BubbleSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public void Sort(List<T> items)
    {
        for (int i = 0; i < items.Count - 1; i++)
        {
            for (int j = 0; j < items.Count - i - 1; j++)
            {
                if (items[j].CompareTo(items[j + 1]) > 0)
                {
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }
}

public class QuickSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public void Sort(List<T> items)
    {
        QuickSortRecursive(items, 0, items.Count - 1);
    }

    private void QuickSortRecursive(List<T> items, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(items, left, right);
            QuickSortRecursive(items, left, pivotIndex - 1);
            QuickSortRecursive(items, pivotIndex + 1, right);
        }
    }

    private int Partition(List<T> items, int left, int right)
    {
        T pivot = items[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (items[j].CompareTo(pivot) <= 0)
            {
                i++;
                // Swap items
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
        // Swap pivot with i+1
        T temp2 = items[i + 1];
        items[i + 1] = items[right];
        items[right] = temp2;
        return i + 1;
    }
}

// Context class that uses the strategy
public class Sorter<T> where T : IComparable<T>
{
    private ISortStrategy<T> _strategy;

    public Sorter(ISortStrategy<T> strategy)
    {
        _strategy = strategy;
    }

    public void Sort(List<T> items)
    {
        _strategy.Sort(items);
    }

    public void SetStrategy(ISortStrategy<T> strategy)
    {
        _strategy = strategy;
    }
}

class Strategy
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 5, 2, 7, 3, 9 };

        var sorter = new Sorter<int>(new BubbleSort<int>());
        sorter.Sort(numbers);
        Console.WriteLine("Sorted using Bubble Sort:");
        Console.WriteLine(string.Join(", ", numbers));

        // Create a sorter with quick sort strategy
        sorter.SetStrategy(new QuickSort<int>());
        // Sort using quick sort strategy
        sorter.Sort(numbers);
        Console.WriteLine("Sorted using Quick Sort:");
        Console.WriteLine(string.Join(", ", numbers));
    }
}
