namespace task1;

class PointSpace
{
    protected int x, y, z;

    public PointSpace(int x, int y, int z)
    {
        this.x = x; this.y = y; this.z = z;
    }

    public void Print() => 
        Console.WriteLine($"x = {x}, y = {y}, z = {z}");

    virtual public double Leng()
    {
        Console.WriteLine("Обчислення відстані у просторі");
        return Math.Sqrt(x * x + y * y + z * z);
    }
}

class PointPlane : PointSpace
{
    public PointPlane(int x, int y) : base(x, y, 0)
    {}

    override public double Leng()
    {
        Console.WriteLine("Обчислення відстані на площині");
        return Math.Sqrt(x * x + y * y);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        PointSpace p;

        for (int i = 0; i < 3; i++)
        {
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            int z = rnd.Next(0, 2);

            if (z == 0)
                p = new PointPlane(x, y);
            else
                p = new PointSpace(x, y, z);

            p.Print();
            Console.WriteLine($"Відстань до початку координат: {p.Leng():F2}\n");
        }
    }
}

