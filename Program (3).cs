using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Laba5

{

    class Transport

    {

        protected string name;

        public Transport()

        {

            Console.WriteLine("Name?");

            this.name = Console.ReadLine();

        }

        public virtual string get()

        {

            return String.Format("Transport : Name - {0}", this.name);

        }

    }



    class Vodnyy : Transport

    {

        protected string klassif;

        public Vodnyy()

        {

            this.klassif = "Lodka";

        }

        public override string get()

        {

            return String.Format("Vodnyy : Name - {0}, klassif - {1} ", this.name, this.klassif);

        }



    }

    class Nazemnyy : Transport

    {

        protected string number;

        public Nazemnyy()

        {

            this.number = "А323ПЛ";



        }

        public override string get()

        {

            return String.Format("Nazemnyy: Name - {0}, number - {1} ", this.name, this.number);

        }

    }

    class Korably : Vodnyy

    {

        protected string tip;

        public Korably()

        {

            this.tip = "Одномачтовый";

        }

        public override string get()

        {

            return String.Format("Korably : Name - {0}, Tip - {1} ", this.name, this.tip);

        }



    }



    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Enter Vodnyy Info");

            Transport B = new Vodnyy();

            Console.WriteLine("Enter Nazemnyy Info");

            Transport C = new Nazemnyy();

            Console.WriteLine("Enter Korably Info");

            Transport D = new Korably();

            Console.WriteLine(B.get());

            Console.WriteLine(C.get());

            Console.WriteLine(D.get());

            Console.ReadKey();

        }

    }

}