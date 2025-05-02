// See https://aka.ms/new-console-template for more information
/// <summary>
///  Top-level statements 
///  Код програми (оператори)  вищого рівня
/// </summary>
///
using System.Collections;

Console.WriteLine("Lab6 C# ");
AnyFunc();

/// <summary>
/// 
///  Top-level statements must precede namespace and type declarations.
/// At the top-level methods/functions can be defined and used
/// На верхньому рівні можна визначати та використовувати методи/функції
/// </summary>
void AnyFunc()
{
    Console.WriteLine(" Some function in top-level");
}
Console.WriteLine("Problems 1 ");
AnyFunc();
//  приклад класів


// task-1-start
Console.WriteLine("\nTask 1 - Transportation Hierarchy Implementation");

// Create vehicle instances
Vehicle vehicle = new Vehicle("Generic Vehicle", 120, 5);
Automobile automobile = new Automobile("Toyota Camry", 200, 5, "Sedan", "Toyota", 2023);
Train train = new Train("Express Train", 160, 500, 10, "Electric");
Express express = new Express("High-Speed Express", 300, 800, 15, "Electric", true, "Premium");

// Display vehicle information
Console.WriteLine("\nVehicle Information:");
vehicle.Show();

Console.WriteLine("\nAutomobile Information:");
automobile.Show();

Console.WriteLine("\nTrain Information:");
train.Show();

Console.WriteLine("\nExpress Information:");
express.Show();

// Create and demonstrate Vehicle Collection with foreach
Console.WriteLine("\nVehicle Collection Demonstration (with foreach):");
VehicleCollection vehicleCollection = new VehicleCollection();
vehicleCollection.Add(vehicle);
vehicleCollection.Add(automobile);
vehicleCollection.Add(train);
vehicleCollection.Add(express);

// Demonstrate unsorted collection
Console.WriteLine("\nUnsorted vehicles (using foreach):");
foreach (Vehicle v in vehicleCollection)
{
    Console.WriteLine($"{v.GetType().Name}: {v.GetName()} - Max Speed: {v.GetMaxSpeed()} km/h");
}

// Sort and demonstrate sorted collection
vehicleCollection.SortBySpeed();
Console.WriteLine("\nVehicles sorted by speed (using foreach):");
foreach (Vehicle v in vehicleCollection)
{
    Console.WriteLine($"{v.GetType().Name}: {v.GetName()} - Max Speed: {v.GetMaxSpeed()} km/h");
}

// Demonstrate the Vehicle's own IEnumerable implementation
Console.WriteLine("\nDemonstrating Vehicle's IEnumerable implementation:");
Console.WriteLine("Iterating over an individual Vehicle object:");
foreach (Vehicle v in express)
{
    Console.WriteLine($"Vehicle in enumeration: {v.GetName()} - Max Speed: {v.GetMaxSpeed()} km/h");
}
// task-1-end

// task-2-start
Console.WriteLine("\nTask 2 - Figure Hierarchy Implementation");

// Create shape instances
Rectangle rectangle = new Rectangle(5, 10);
Circle circle = new Circle(7);
Triangle triangle = new Triangle(3, 4, 5);

// Create an array of figures
Figure[] figures = new Figure[3];
figures[0] = rectangle;
figures[1] = circle;
figures[2] = triangle;

// Display information about all figures
Console.WriteLine("\nFigures Information:");
foreach (Figure figure in figures)
{
    figure.Display();
    Console.WriteLine($"Area: {figure.CalculateArea()}");
    Console.WriteLine($"Perimeter: {figure.CalculatePerimeter()}");
    Console.WriteLine();
}
// task-2-end

// task-3-start
Console.WriteLine("\nTask 3 - Exception Handling with ArrayTypeMismatchException");

// Create and run the array operations
ArrayOperations arrayOps = new ArrayOperations();
arrayOps.RunDemonstration();
// task-3-end

/// <summary>
/// 
/// Top-level statements must precede namespace and type declarations.
/// Оператори верхнього рівня мають передувати оголошенням простору імен і типу.
/// Створення класу(ів) або оголошенням простору імен є закіченням  іструкцій верхнього рівня
/// 
/// </summary>

// task-1-start
/// <summary>
/// Base class for all vehicles
/// </summary>
public class Vehicle : IComparable<Vehicle>, IEnumerable<Vehicle>
{
    protected string Name { get; set; } = string.Empty;
    protected double MaxSpeed { get; set; }
    protected int Capacity { get; set; }

    // Public accessors for the protected properties
    public string GetName() => Name;
    public double GetMaxSpeed() => MaxSpeed;
    public int GetCapacity() => Capacity;

    public Vehicle(string name, double maxSpeed, int capacity)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        Capacity = capacity;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Maximum Speed: {MaxSpeed} km/h");
        Console.WriteLine($"Capacity: {Capacity} passengers");
    }

    // Implementation of IComparable<Vehicle> interface
    public int CompareTo(Vehicle? other)
    {
        // If other is null, this object is greater
        if (other == null) return 1;
        
        // Compare by MaxSpeed
        return MaxSpeed.CompareTo(other.MaxSpeed);
    }

    // Implementation of IEnumerable<Vehicle> for Vehicle itself
    // This allows using foreach directly on a Vehicle object
    // In this implementation, it just returns itself as the only element
    public IEnumerator<Vehicle> GetEnumerator()
    {
        // Return only this instance in the enumeration
        yield return this;
    }

    // Explicit implementation of non-generic IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

/// <summary>
/// Automobile class derived from Vehicle
/// </summary>
public class Automobile : Vehicle
{
    protected string Type { get; set; } = string.Empty;
    protected string Manufacturer { get; set; } = string.Empty;
    protected int Year { get; set; }

    public Automobile(string name, double maxSpeed, int capacity, string type, string manufacturer, int year)
        : base(name, maxSpeed, capacity)
    {
        Type = type;
        Manufacturer = manufacturer;
        Year = year;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Manufacturer: {Manufacturer}");
        Console.WriteLine($"Year: {Year}");
    }
}

/// <summary>
/// Train class derived from Vehicle
/// </summary>
public class Train : Vehicle
{
    protected int Wagons { get; set; }
    protected string PowerSource { get; set; } = string.Empty;

    public Train(string name, double maxSpeed, int capacity, int wagons, string powerSource)
        : base(name, maxSpeed, capacity)
    {
        Wagons = wagons;
        PowerSource = powerSource;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Number of Wagons: {Wagons}");
        Console.WriteLine($"Power Source: {PowerSource}");
    }
}

/// <summary>
/// Express class derived from Train with additional features
/// </summary>
public class Express : Train
{
    protected bool HasWifi { get; set; }
    protected string ServiceClass { get; set; } = string.Empty;

    public Express(string name, double maxSpeed, int capacity, int wagons, string powerSource, bool hasWifi, string serviceClass)
        : base(name, maxSpeed, capacity, wagons, powerSource)
    {
        HasWifi = hasWifi;
        ServiceClass = serviceClass;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"WiFi Available: {(HasWifi ? "Yes" : "No")}");
        Console.WriteLine($"Service Class: {ServiceClass}");
    }
}

/// <summary>
/// Collection of vehicles that implements IEnumerable to support foreach
/// </summary>
public class VehicleCollection : IEnumerable<Vehicle>
{
    private List<Vehicle> _vehicles = new List<Vehicle>();

    public void Add(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    // Implementation of IEnumerable<Vehicle> interface
    public IEnumerator<Vehicle> GetEnumerator()
    {
        return _vehicles.GetEnumerator();
    }

    // Implementation of IEnumerable interface
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Method to sort vehicles by speed
    public void SortBySpeed()
    {
        _vehicles.Sort();
    }
}
// task-1-end

// task-2-start
/// <summary>
/// Interface for all figures
/// </summary>
public interface Figure
{
    double CalculateArea();
    double CalculatePerimeter();
    void Display();
}

/// <summary>
/// Rectangle class implementing Figure interface
/// </summary>
public class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    public void Display()
    {
        Console.WriteLine("Rectangle:");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Height: {Height}");
    }
}

/// <summary>
/// Circle class implementing Figure interface
/// </summary>
public class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void Display()
    {
        Console.WriteLine("Circle:");
        Console.WriteLine($"Radius: {Radius}");
    }
}

/// <summary>
/// Triangle class implementing Figure interface
/// </summary>
public class Triangle : Figure
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public void Display()
    {
        Console.WriteLine("Triangle:");
        Console.WriteLine($"Side A: {SideA}");
        Console.WriteLine($"Side B: {SideB}");
        Console.WriteLine($"Side C: {SideC}");
    }
}
// task-2-end

// task-3-start
/// <summary>
/// Custom exception class for array index out of bounds
/// </summary>
public class ArrayIndexOutOfRangeException : Exception
{
    public int InvalidIndex { get; }
    public int ArraySize { get; }

    public ArrayIndexOutOfRangeException(string message, int invalidIndex, int arraySize) 
        : base(message)
    {
        InvalidIndex = invalidIndex;
        ArraySize = arraySize;
    }

    public override string ToString()
    {
        return $"{Message}\nInvalid Index: {InvalidIndex}, Array Size: {ArraySize}";
    }
}

/// <summary>
/// Custom exception class for array type mismatch
/// </summary>
public class CustomArrayTypeMismatchException : Exception
{
    public Type ExpectedType { get; }
    public Type ActualType { get; }

    public CustomArrayTypeMismatchException(string message, Type expectedType, Type actualType) 
        : base(message)
    {
        ExpectedType = expectedType;
        ActualType = actualType;
    }

    public override string ToString()
    {
        return $"{Message}\nExpected Type: {ExpectedType.Name}, Actual Type: {ActualType.Name}";
    }
}

/// <summary>
/// Class to demonstrate array operations with exception handling
/// </summary>
public class ArrayOperations
{
    public void RunDemonstration()
    {
        Console.WriteLine("\n1. Handling ArrayTypeMismatchException:");
        HandleArrayTypeMismatch();

        Console.WriteLine("\n2. Handling custom exceptions:");
        HandleCustomExceptions();

        Console.WriteLine("\n3. Working with arrays correctly:");
        WorkWithArraysCorrectly();
    }

    // Method that demonstrates ArrayTypeMismatchException
    private void HandleArrayTypeMismatch()
    {
        try
        {
            // Create an array of objects
            object[] array = new object[3];
            array[0] = "String element"; // String
            array[1] = 42;              // Integer (boxed)
            array[2] = new DateTime();  // DateTime

            // Attempt to cast array to string array (will throw ArrayTypeMismatchException)
            string[] stringArray = (string[])array;
            
            // This line won't execute due to exception
            Console.WriteLine("This line won't execute");
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine($"Standard ArrayTypeMismatchException caught: {ex.Message}");
            Console.WriteLine($"Source: {ex.Source}");
            Console.WriteLine($"StackTrace: {ex.StackTrace.Split('\n')[0]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected exception: {ex.Message}");
        }
    }

    // Method that demonstrates custom exceptions
    private void HandleCustomExceptions()
    {
        try
        {
            object[] array = new object[3];
            array[0] = "String";
            array[1] = 100;
            array[2] = 3.14;

            // Try to access elements with direct casting
            for (int i = 0; i < 4; i++) // Note: goes out of bounds on purpose
            {
                try
                {
                    if (i >= array.Length)
                    {
                        throw new ArrayIndexOutOfRangeException(
                            "Attempted to access an element outside array bounds", 
                            i, 
                            array.Length);
                    }

                    // Try to cast element to string
                    if (!(array[i] is string))
                    {
                        throw new CustomArrayTypeMismatchException(
                            "Element is not of expected type", 
                            typeof(string), 
                            array[i].GetType());
                    }

                    string strValue = (string)array[i];
                    Console.WriteLine($"Element {i}: {strValue}");
                }
                catch (ArrayIndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Custom Exception: {ex}");
                }
                catch (CustomArrayTypeMismatchException ex)
                {
                    Console.WriteLine($"Custom Exception: {ex}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected exception: {ex.Message}");
        }
    }

    // Method that shows the correct way to work with arrays and types
    private void WorkWithArraysCorrectly()
    {
        try
        {
            // Create arrays properly
            object[] mixedArray = new object[] { "Hello", 42, 3.14, true };
            string[] stringArray = new string[] { "Hello", "World", "C#" };

            // Safely work with the mixed array
            Console.WriteLine("Working with mixed array:");
            for (int i = 0; i < mixedArray.Length; i++)
            {
                Console.WriteLine($"Element {i}: {mixedArray[i]} (Type: {mixedArray[i].GetType().Name})");
                
                // Safe type checking
                if (mixedArray[i] is string)
                {
                    string str = (string)mixedArray[i];
                    Console.WriteLine($"  String length: {str.Length}");
                }
                else if (mixedArray[i] is int)
                {
                    int num = (int)mixedArray[i];
                    Console.WriteLine($"  Integer squared: {num * num}");
                }
            }

            // Safely work with string array
            Console.WriteLine("\nWorking with string array:");
            foreach (string str in stringArray)
            {
                Console.WriteLine($"String: {str}, Length: {str.Length}");
            }
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine($"Array type mismatch: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected exception: {ex.Message}");
        }
    }
}
// task-3-end

