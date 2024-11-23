using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._1
{
    struct RepositoryWorkers
    {
        public Workers[] workers;
        public string path;

        public RepositoryWorkers(string path)
        {
            this.path = path;
            this.workers = new Workers[1];
            Check(path);
            GetAllWorkers();
        }
        /// <summary>
        /// Проверка существования файла
        /// </summary>
        /// <param name="path"></param>
        public void Check(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                Console.WriteLine("Файл создан");
            }
            else
            {
                Console.WriteLine("Файл существует");
            }
        }
        /// <summary>
        /// Вывод всех сотрудников
        /// </summary>
        public void PrintAllWorkers()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Print(line);
                }
            }
        }
        /// <summary>
        /// присваиваем worker уникальный ID,
        /// дописываем нового worker в файл
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Workers worker)
        {

            worker.ID = GetWorkerId();
            string s = "#";
            using (StreamWriter wr = new StreamWriter(this.path, true))
            {
                wr.WriteLine(string.Join(s, worker.ID, worker.DateWorker, worker.FIO, worker.Age, worker.Height, worker.Bithday, worker.PlaseBithday));
            }
        }

        /// <summary>
        ///  здесь происходит чтение из файла
        /// и возврат массива считанных экземпляров
        /// </summary>
        /// <returns></returns>
        public Workers[] GetAllWorkers()
        {
            string[] lines = File.ReadAllLines(this.path);
            workers = new Workers[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                workers[i] = Patern(lines[i]);
            }

            return workers;
        }
        /// <summary>
        /// происходит чтение из файла, возвращается Worker
        /// с запрашиваемым ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Workers GetWorkerById(int id)
        {
            string[] lines = File.ReadAllLines(path);
            int i = 0;
            if (id < 0 || id > lines.Length)
            {
                Console.WriteLine("\nТакого сотрудника не существует");
            }
            else
            {
                foreach (string e in lines)
                {
                    Workers workers = Patern(e);
                    if (id == workers.ID)
                    {
                        Console.WriteLine();
                        Print(e);
                    }
                }
            }

            return workers[i];
        }
        /// <summary>
        /// считывается файл, находится нужный Worker
        /// происходит запись в файл всех Worker,
        /// кроме удаляемого
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            string[] lines = File.ReadAllLines(this.path);
            using (StreamWriter sw = new StreamWriter(this.path))
            {
                foreach (string e in lines)
                {
                    Workers worker = Patern(e);
                    if (worker.ID != id)
                    {
                        sw.WriteLine(e);
                    }
                    else
                    {
                        Console.Write("\nБыл удален:");
                        Print(e);
                    }
                }
            }
        }
        /// <summary>
        /// здесь происходит чтение из файла
        /// фильтрация нужных записей
        /// и возврат массива считанных экземпляров
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Workers[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Workers worker = Patern(line);
                    if (worker.DateWorker >= dateFrom && worker.DateWorker <= dateTo)
                    {
                        Print(line);
                    }
                }
            }
            return workers;

        }
        /// <summary>
        /// Вывод на экран массива из строки
        /// </summary>
        /// <param name="a"></param>
        public void Print(string line)
        {
            string s = "#";
            string[] data = line.Split('#');
            Console.WriteLine($"\t{string.Join(s, data[0], data[1], data[2], data[3], data[4], data[5], data[6])}");
        }
        /// <summary>
        /// Сортировка по выбранному полю
        /// </summary>
        public void Sort()
        {
            char key = ' ';
            do
            {
                Console.WriteLine("1-Сортировка по ID" +
                "\n2-Сортировка по дате" +
                "\n3-Сортировка по Ф.И.О." +
                "\n4-Сортировка по возрасту" +
                "\n5-Соритровка по росту" +
                "\n6-Сортировка по дате рождения" +
                "\n0-Выход из сортировки");
                Console.WriteLine();
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        var workID = workers.OrderBy(w => w.ID);
                        PrintSort(workID);
                        break;
                    case '2':
                        var workDate = workers.OrderBy(w => w.DateWorker);
                        PrintSort(workDate);
                        break;
                    case '3':
                        var workFIO = workers.OrderBy(w => w.FIO);
                        PrintSort(workFIO);
                        break;
                    case '4':
                        var workAge = workers.OrderBy(w => w.Age);
                        PrintSort(workAge);
                        break;
                    case '5':
                        var workHeight = workers.OrderBy(w => w.Height);
                        PrintSort(workHeight);
                        break;
                    case '6':
                        var workBithday = workers.OrderBy(w => w.Bithday);
                        PrintSort(workBithday);
                        break;
                }

            } while (key != '0');

        }
        /// <summary>
        /// Метод для вывода сортировки по полю
        /// </summary>
        /// <param name="sortWorkers"></param>
        private void PrintSort(IOrderedEnumerable<Workers> sortWorkers)
        {
            string s = "#";
            foreach (var w in sortWorkers)
                Console.WriteLine($"\t{string.Join(s, w.ID, w.DateWorker, w.FIO, w.Age, w.Height, w.Bithday, w.PlaseBithday)}");
            Console.WriteLine();
        }
        /// <summary>
        /// Инициализация сотрудника
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Workers Patern(string line)
        {
            string[] data = line.Split('#');
            return new Workers
            {
                ID = int.Parse(data[0]),
                DateWorker = Convert.ToDateTime(data[1]),
                FIO = data[2],
                Age = int.Parse(data[3]),
                Height = int.Parse(data[4]),
                Bithday = int.Parse(data[5]),
                PlaseBithday = data[6],
            };
        }

        /// <summary>
        /// Генерация уникального ID
        /// </summary>
        /// <returns></returns>
        private int GetWorkerId()
        {
            Workers[] workers = GetAllWorkers();
            int maxId = 0;

            foreach (Workers worker in workers)
            {
                if (worker.ID > maxId)
                {
                    maxId = worker.ID;
                }
            }

            return maxId + 1;
        }

    }
}
