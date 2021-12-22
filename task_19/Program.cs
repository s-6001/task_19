using System;
using System.Linq;

namespace task_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer[] computers = new Computer[8];
            Computer comp1 = new Computer(1, "Бюджетный", "intell", 866, 1024, 4000, 2, 10000, 100);
            Computer comp2 = new Computer(2, "Бюджетный 2", "amd", 866, 1024, 4000, 2, 20000, 30);
            Computer comp3 = new Computer(3, "Средний", "amd", 1366, 2048, 8000, 4, 30000, 5);
            Computer comp4 = new Computer(4, "Средний 2", "intell", 2048, 1024, 12000, 6, 40000, 10);
            Computer comp5 = new Computer(5, "Дорогой", "intell", 1600, 4096, 16000, 8, 50000, 15);
            Computer comp6 = new Computer(6, "Дорогой 2", "amd", 1600, 4096, 20000, 12, 60000, 10);
            Computer comp7 = new Computer(7, "Ультра", "amd", 1600, 8192, 32000, 15, 160000, 3);
            Computer comp8 = new Computer(8, "Ультра 2", "intell", 1600, 16384, 64000, 18, 160000, 2);
            computers[0] = comp1;
            computers[1] = comp2;
            computers[2] = comp3;
            computers[3] = comp4;
            computers[4] = comp5;
            computers[5] = comp6;
            computers[6] = comp7;
            computers[7] = comp8;

            //все компьютеры с указанным процессором
            Console.Write("Введите требуемое название процессора: ");
            string processorType = Console.ReadLine();
            Console.WriteLine("Все компьютеры с процессором {0}: ", processorType);
            var selectedComputers1 = from t in computers // определяем каждый объект из Computers как t
                                     where t.ProcessorType == processorType //фильтрация по типу процессора
                                     select t; // выбираем объект
            foreach (Computer s in selectedComputers1)
                Console.WriteLine("Код: {0}, название компьютера: {1}, тип процессора: {2}", s.Code, s.Name, s.ProcessorType);
            Console.WriteLine();

            //все компьютеры с объемом ОЗУ не ниже, чем указано.
            int ramAmount = 0;
            Console.Write("Введите требуемый объем ОЗУ: ");
            try
            {
                ramAmount = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Не удалось распознать объем ОЗУ.");
            }
            Console.WriteLine("Все компьютеры с объемом ОЗУ не ниже, чем {0}: ", ramAmount);
            var selectedComputers2 = from t in computers // определяем каждый объект из Computers как t
                                     where t.RamAmount >= ramAmount //фильтрация
                                     select t; // выбираем объект
            foreach (Computer s in selectedComputers2)
                Console.WriteLine("Код: {0}, название компьютера: {1}, объем оперативной памяти: {2}", s.Code, s.Name, s.RamAmount);
            Console.WriteLine();

            //весь список, отсортированный по увеличению стоимости
            Console.WriteLine("Весь список, отсортированный по увеличению стоимости:");
            var selectedComputers3 = from t in computers // определяем каждый объект из Computers как t
                                     orderby t.Price //сортировка
                                     select t; // выбираем объект
            foreach (Computer s in selectedComputers3)
                Console.WriteLine("Код: {0}, название компьютера: {1}, цена: {2}", s.Code, s.Name, s.Price);
            Console.WriteLine();

            //весь список, отсортированный по увеличению стоимости
            Console.WriteLine("Весь список, сгруппированный по типу процессора:");
            var selectedComputers4 = from t in computers
                                     group t by t.ProcessorType into g
                                     select new
                                     {
                                         Name = g.Key,
                                         computers = from p in g select p
                                     };
            foreach (var group in selectedComputers4)
            {
                foreach (Computer item in group.computers)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine();

            //найти самый дорогой и самый бюджетный компьютер
            double maxPrice = computers.Max(n => n.Price);
            var nameMaxPrice = computers.Where(x => x.Price == maxPrice);
            Console.WriteLine("Самый дорогой компьютер:");
            foreach (Computer item in nameMaxPrice)
            {
                Console.WriteLine("\"{0}\". Цена: {1}", item.Name, maxPrice);
            }
            Console.WriteLine();
            double minPrice = computers.Min(n => n.Price);
            var nameMinPrice = computers.Where(x => x.Price == minPrice);
            Console.WriteLine("Самый бюджетный компьютер:");
            foreach (Computer item in nameMinPrice)
            {
                Console.WriteLine("\"{0}\". Цена: {1}", item.Name, minPrice);
            }
            Console.WriteLine();

            //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            var computerQuantity = computers.Where(x => x.Quantity >= 30);
            Console.WriteLine("Компьютер в количестве не менее 30шт:");
            foreach (Computer item in computerQuantity)
            {
                Console.WriteLine("\"{0}\"", item.Name);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    class Computer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string ProcessorType { get; set; }
        public int Frequency { get; set; }
        public int RamAmount { get; set; }
        public int HardDiskAmount { get; set; }
        public int VideoAmount { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Computer(int c, string n, string pt, int f, int r, int h, int v, double p, int q)
        {
            Code = c;    //код
            Name = n;  //название марки
            ProcessorType = pt;   //тип процессора
            Frequency = f;  //частота процессора
            RamAmount = r;  // объем оперативной памяти
            HardDiskAmount = h; //объем жесткого диска
            VideoAmount = v;    //объем памяти видеокарты
            Price = p;  //цена
            Quantity = q;   //количество в наличии
        }
    }
}