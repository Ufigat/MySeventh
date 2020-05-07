using System;

namespace ConsoleApp1
{
    class Person
    {
        public string fam; // записать 1 раз
        public  string status = "alive"; // только читать
        public double salary; // недоступна для чтения
        public int age; //чтение запись
        private string health = "100%";//скрыто и не записывается
        public int Age
        {
            set { age = value; }
            get { return (age); }
        }
        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }
        public string Status
        {
            private set { status = value; }
            get { return (status); }
        }
        public double Salary
        {
            set { salary = value; }
            private get { return (salary); }
        }
       /* public string Health
        {
            private set { health = value; }
            private get { return (health); }
        }*/


    }

    class Rational
    {
        public int m;
        public int n;
        public static readonly Rational Zero, One;
        private Rational(int a, int b, string t)
        {
            m = a; n = b;
        }
        static Rational()

        {

            Console.WriteLine("static constructor Rational");

            Zero = new Rational(0, 1, "private");

            One = new Rational(1, 1, "private");

        }
        public static bool operator ==(Rational r1, Rational r2)

        {

            return ((r1.m == r2.m) && (r1.n == r2.n));

        }

        public static bool operator !=(Rational r1, Rational r2)

        {

            return ((r1.m != r2.m) || (r1.n != r2.n));

        }
        public static bool operator <(Rational r1, double r2)

        {

            return ((double)r1.m / (double)r1.n < r2);

        }

        public static bool operator >(Rational r1, double r2)

        {

            return ((double)r1.m / (double)r1.n > r2);

        }

        public void TestRationalConst()

        {

            Rational r1 = new Rational(2, 8), r2 = new Rational(2, 5);

            Rational r3 = new Rational(4, 10), r4 = new Rational(3, 7);

            Rational r5 = Rational.Zero, r6 = Rational.Zero;

            if ((r1 != Rational.Zero) && (r2 == r3)) r5 =

             (r3 + Rational.One) * r4;

            r6 = Rational.One + Rational.One;

            r1.PrintRational("r1: (2,8)");

            r2.PrintRational("r2: (2,5)");

            r3.PrintRational("r3: (4,10)");

            r4.PrintRational("r4: (3,7)");

            r5.PrintRational("r5: ((r3 +1)*r4)");

            r6.PrintRational("r6: (1+1)");

        }
        public Rational(int a, int b)

        {

            if (b == 0) { m = 0; n = 1; }
            else

            {
               if  ( b<0) {b=-b; a=-a;}
                int d = Del(a,b);
                m = a / d; n = b / d;
            }

        }
        public Rational()

        {


        }
        public static Rational operator +(Rational a, Rational b)
        {
            Rational n = new Rational();
            if (a.n != b.n)
            {
                n.n = a.n * b.n;
                n.m = a.m * b.n + b.m * a.n;
            }
            return n;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            Rational n = new Rational();
            if (a.n != b.n)
            {
                n.n = a.n * b.n;
                n.m = a.m * b.n - b.m * a.n;
            }
            return n;
        }
        public static Rational operator *(Rational a, Rational b)
        {
            Rational n = new Rational();            
            n.n = a.n * b.n;
            n.m = a.m * b.m;            
            return n;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            Rational n = new Rational();
                n.n = a.n * b.m;
                n.m = a.m * b.n;
            return n;
        }


        public static int Del(int n, int m)
        {
            while (n != 0)
            {
                var t = n;
                n = m % n;
                m = t;
            }
            return m;
        }
        public void PrintRational(string name)

        {

            Console.WriteLine(" {0} = {1}/{2}", name, m, n);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person f1 = new Person();
            Console.WriteLine("Введите возвраст");
            f1.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Возвраст: {0}", f1.age);
            Console.WriteLine("Введите фамилию");
            f1.fam = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Фамилия: {0}", f1.fam);
            //Console.WriteLine("Введите статус");
            //f1.status = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Статус: {0}", f1.status);
            Console.WriteLine("Введите зарплату");
            f1.salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Зарплата: {0}", f1.salary);
            Console.WriteLine("Введите здоровье");
            //f1.health = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("Здоровье: {0}", f1.health);

            //второе задание
            Rational t1 = new Rational(25, 100);
            Rational t2 = new Rational(5, 15);
            Rational t3 = new Rational();
            t1.PrintRational("nod");
            t2.PrintRational("nod");
            t3 = t1 + t2;
            t3.PrintRational("+");
            t3 = t1 - t2;
            t3.PrintRational("-");
            t3 = t1 * t2;
            t3.PrintRational("*");
            t3 = t1 / t2;
            t3.PrintRational("/");
            t3.TestRationalConst();
        }
    }
}
