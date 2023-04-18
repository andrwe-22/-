using System;

namespace Task4._29
{
    // Класс 1-го уровня
    class Matchbox
    {
        public string manufacturer; // фирма изготовитель
        public int matchesCount; // число спичек в коробке
        public double matchBurnTime; // время горения одной спички (с)

        public Matchbox(string manufacturer, int matchesCount, double matchBurnTime)
        {
            this.manufacturer = manufacturer;
            this.matchesCount = matchesCount;
            this.matchBurnTime = matchBurnTime;
        }

        // Функция, которая определяет «качество» объекта – Q по заданной формуле
        public double Q()
        {
            return matchesCount * matchBurnTime;
        }

        // Функция вывода информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine("Manufacturer: " + manufacturer);
            Console.WriteLine("Matches count: " + matchesCount);
            Console.WriteLine("Match burn time: " + matchBurnTime);
            Console.WriteLine("Q: " + Q());
        }
    }

    // Класс 2-го уровня (класс-потомок)
    class DefectiveMatchbox : Matchbox
    {
        public double defectPercentage; // средний % бракованных спичек в коробке

        public DefectiveMatchbox(string manufacturer, int matchesCount, double matchBurnTime, double defectPercentage)
            : base(manufacturer, matchesCount, matchBurnTime)
        {
            this.defectPercentage = defectPercentage;
        }

        // Функция, которая определяет «качество» объекта класса 2-го уровня – Qp
        // которая перекрывает функцию качества класса 1-го уровня (Q)
        // выполняя вычисление по новой формуле
        public new double Q()
        {
            return (100 - defectPercentage) * base.Q() / 100;
        }

        // Функция вывода информации об объекте
        public new void PrintInfo()
        {
            Console.WriteLine("Manufacturer: " + manufacturer);
            Console.WriteLine("Matches count: " + matchesCount);
            Console.WriteLine("Match burn time: " + matchBurnTime);
            Console.WriteLine("Defect percentage: " + defectPercentage);
            Console.WriteLine("Qp: " + Q());
        }
    }


    // пример использования классов
    class Program
    {
        static void Main(string[] args)
        {
            Matchbox m1 = new Matchbox("Match Company A", 50, 0.5);
            m1.PrintInfo();

            DefectiveMatchbox dm1 = new DefectiveMatchbox("Match Company B", 100, 0.4, 10);
            dm1.PrintInfo();

            Console.ReadLine();
        }

    }
}