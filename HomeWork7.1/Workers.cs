using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._1
{
    struct Workers
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Bithday { get; set; }
        public string PlaseBithday { get; set; }
        public DateTime DateWorker { get; set; }

        public Workers(int id, string fio, int age, int height, int bithday, string plasebithday, DateTime dateWorker)
        {
            this.ID = id;
            this.FIO = fio;
            this.Age = age;
            this.Height = height;
            this.Bithday = bithday;
            this.PlaseBithday = plasebithday;
            this.DateWorker = dateWorker;
        }
    }
}
