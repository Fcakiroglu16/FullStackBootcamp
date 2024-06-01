namespace FullStackBootcamp.App2;

internal class Program
{
    static void Main(string[] args)
    {
        Pen pen1 = new Pen();

        pen1.Height = 100;
        pen1.Width = 200;
        pen1.Color = "red";

        int value = 500;
        Console.WriteLine($"Value:{value}");
        Write2(value);
        Console.WriteLine($"Value:{value}");
        Console.WriteLine($"Width:{pen1.Width}");
        Write(pen1);


        Console.WriteLine($"Width:{pen1.Width}");

        Console.WriteLine("Hello, World!");
    }


    static void Write(Pen pen)
    {
        pen.Width = 500;
    }

    static int Write2(int val)
    {
        val = 100 * 2;
        return val;
    }
}