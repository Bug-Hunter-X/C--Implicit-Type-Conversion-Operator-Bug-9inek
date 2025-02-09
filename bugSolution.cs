public class MyClass
{
    public int MyProperty { get; set; }

    public MyClass(int value)
    {
        MyProperty = value;
    }

    public static implicit operator int(MyClass myClass)
    {
        return myClass.MyProperty;
    }

    public static implicit operator MyClass(int value)
    {
        return new MyClass(value);
    }
    //Add explicit operator to avoid ambiguity
    public static explicit operator MyClass(double value)
    {
        return new MyClass((int)value);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyClass obj1 = 5; // Implicit conversion from int to MyClass
        int num = obj1; // Implicit conversion from MyClass to int

        Console.WriteLine(num); // Output: 5

        MyClass obj2 = new MyClass(10);
        int num2 = obj2 + 5; // Implicit conversion + Operator Overloading

        Console.WriteLine(num2); // Output: 15

        // Example of explicit conversion handling potential ambiguity
        MyClass obj3 = (MyClass)12.5;
        Console.WriteLine(obj3.MyProperty); //Output 12
    }
}