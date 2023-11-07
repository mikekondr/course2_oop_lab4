namespace example;

class Trapezoid
{
    protected double a, b, c, d;

    public Trapezoid() {}

    public Trapezoid(double a, double b, double c, double d)
    {
        this.a = a; this.b = b; this.c = c; this.d = d;
    }

    //метод для наслідування
    public void Print() =>
        Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");

    //метод для наслідування
    public double Perimetr() => a + b + c + d;

    //віртуальний метод
    //він переназначається у дочірньому класі
    virtual public double Sqrt()
    {
        Console.WriteLine("Обчислюємо площу для звичайної трапеції");
        double x = ((b - a) * (b - a) + c * c - d * d) / (2 * (b - a));
        double x2 = Math.Pow(x, 2);
        double s = (a + b) * Math.Sqrt(c * c - x2) / 2;
        return s;
    }
}

class Izoscelesl : Trapezoid
{
    public Izoscelesl() {}

    public Izoscelesl(double a, double b, double c)
    {
        this.a = a; this.b = b; this.c = c; this.d = c;
    }

    //перевизначення методу обчислення площі
    override public double Sqrt()
    {
        Console.WriteLine("Обчислюємо для рівнобедренної трапеції");
        double s = (a + b) * Math.Sqrt(c * c - (a - b) * (a - b) / 4) / 2;
        return s;
    }

    //власний метод визначення радіусу вписаного кола
    public double Radius()
    {
        double r = Math.Sqrt(a * b) / 2;
        return r;
    }
}

class Program
{
    static void Main(string[] args)
    {
        double p, s, r = 0;
        int a=10, b=15, c=7, d=8;

        //описуємо змінну батьківського класу
        Trapezoid t;

        if (c == d) //рівнобедренна трапеція
        {
            //створюємо у змінній обʼєкт дочірнього класу
            t = new Izoscelesl(a, b, c);

            //цей обʼєкт необхідний, оскільки у батьківського класу
            //немає методу обчислення радіусу вписаного кола
            Izoscelesl t1 = new Izoscelesl(a, b, c);
            r = t1.Radius();
        }
        else //звичайна трапеція
            t = new Trapezoid(a, b, c, d);

        t.Print(); p = t.Perimetr();
        s = t.Sqrt();
        Console.WriteLine($"P = {p}, S = {s:F2}");
        if (c == d)
            Console.WriteLine($"R = {r:F2}");
    }
}

