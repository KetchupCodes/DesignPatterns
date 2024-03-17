using System;

public sealed class DatabaseConnection
{
    private static DatabaseConnection instance;
    private readonly string connectionString;

    // Private constructor to prevent instantiation from outside
    private DatabaseConnection()
    {
        // For demo purposes, let's assume a default connection string
        connectionString = "YourDatabaseConnectionString";
    }

    // Public static method to get the instance
    public static DatabaseConnection GetInstance()
    {
        // Double-check locking for thread safety
        if (instance == null)
        {
            lock (typeof(DatabaseConnection))
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
            }
        }
        return instance;
    }

    // Sample method to execute a query
    public void ExecuteQuery(string query)
    {
        // In a real-world scenario, this method would establish a connection to the database
        // and execute the query using the provided connection string
        Console.WriteLine($"Executing query: {query} with connection string: {connectionString}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Get the singleton instance of DatabaseConnection
        DatabaseConnection dbConnection1 = DatabaseConnection.GetInstance();
        DatabaseConnection dbConnection2 = DatabaseConnection.GetInstance();

        // Both instances should be the same
        Console.WriteLine(dbConnection1 == dbConnection2);  // Output: True

        // Execute a sample query
        dbConnection1.ExecuteQuery("SELECT * FROM table_name");
    }
}