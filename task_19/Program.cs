using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp1 = new Computer(1,"dfg", "dfsg", 866, 1024, 4000, 2, 50000, 1);

            var selectedComputers = from t in computers // определяем каждый объект из Computers как t
                                where t.ToUpper().StartsWith("") //фильтрация по критерию
                                orderby t  // упорядочиваем по возрастанию
                                select t; // выбираем объект

            foreach (string s in selectedComputers)
                Console.WriteLine(s);
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