using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Laba5

{

    class Raspisanie

    {

        protected string Nomer;

        public Raspisanie()

        {

            Console.WriteLine("Введите номер поезда?");

            this.Nomer = Console.ReadLine();

        }

        public virtual string get()

        {

            return String.Format("Raspisanie : Номер - {0}", this.Nomer);

        }

    }



    class Train : Raspisanie

    {

        protected string hm, st;

        public Train()

        {

            this.hm = "12:50";
            this.st = "Белгород";

        }

        public override string get()

        {

            return String.Format("Поезд : Номер поезда - {0}, Время отправления - {1} , Станция назначения - {2}", this.Nomer, this.hm, this.st);

        }



    }

    class Train1 : Raspisanie

    {

        protected string hm, st;

        public Train1()

        {

            this.hm = "21:30";
            this.st = "Орел";



        }

        public override string get()

        {

            return String.Format("Поезд: Номер поезда - {0}, Время отправления - {1}, Станция назначения - {2} ", this.Nomer, this.hm, this.st);

        }

    }

    class Train2 : Raspisanie

    {

        protected string hm, st;

        public Train2()

        {

            this.hm = "06:00";
            this.st = "Москва";

        }

        public override string get()

        {

            return String.Format("Поезд : Номер поезда - {0}, Время отправления - {1}, Станция назначения - {2}", this.Nomer, this.hm, this.st);

        }



    }


    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Поезд");

            Raspisanie B = new Train();

            Console.WriteLine("Поезд");

            Raspisanie C = new Train1();

            Console.WriteLine("Поезд");

            Raspisanie D = new Train2();
            Console.WriteLine(B.get());

            Console.WriteLine(C.get());

            Console.WriteLine(D.get());
            Console.ReadKey();

        }

    }

}
