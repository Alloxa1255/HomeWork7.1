using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "db.txt";
            RepositoryWorkers rep = new RepositoryWorkers(path);
            char key = 'a';
            do
            {
                Console.WriteLine("\n1-Ввод сотрудник" +
                    "\n2-Вывести всех сотрудников" +
                    "\n3-Вывод сотрудника по ID" +
                    "\n4-Удалить сотрудника по ID" +
                    "\n5-Вывод сотрудников в диапозоне дат" +
                    "\n6-Сортировка сотрудников" +
                    "\n0-Выйти\n");
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        Workers worker = new Workers();
                        DateTime now = DateTime.Now;
                        Console.WriteLine($"Дата Добавления:{now}");
                        worker.DateWorker = now;
                        Console.Write("Введите Ф.И.О.:");
                        worker.FIO = Console.ReadLine();
                        Console.Write("Введите возраст:");
                        worker.Age = int.Parse(Console.ReadLine());
                        Console.Write("Введите рост:");
                        worker.Height = int.Parse(Console.ReadLine());
                        Console.Write("Введите дату рождения:");
                        worker.Bithday = int.Parse(Console.ReadLine());
                        Console.Write("Введите место рождения:");
                        worker.PlaseBithday = Console.ReadLine();
                        rep.AddWorker(worker);
                        break;
                    case '2':
                        rep.PrintAllWorkers();
                        break;
                    case '3':
                        Console.Write("Введите ID сотрудника:");
                        int idWorker = int.Parse(Console.ReadLine());
                        rep.GetWorkerById(idWorker);
                        break;
                    case '4':
                        Console.Write("Введите ID удаляемого сотрудника:");
                        int idDeleteWorker = int.Parse(Console.ReadLine());
                        rep.DeleteWorker(idDeleteWorker);
                        break;
                    case '5':
                        Console.Write("Введите дату начала сортировки:");
                        var dateFrom = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Введите дату окончания сортировки:");
                        var dateTo = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine();
                        rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        break;
                    case '6':
                        rep.Sort();
                        break;

                }
            } while (key != '0');

        }
    }
}
