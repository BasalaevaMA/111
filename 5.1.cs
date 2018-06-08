//	1. Спроектировать абстракции и представить иерархию классов в виде схемы.
//	2. Разработать конструкторы, атрибуты и методы для каждого из определяемых классов.
//	3. Реализовать программу на C# в соответствии с вариантом исполнения, в которой используются экземпляры описанных классов.
//	4. Применить и объяснить необходимость использования принципа инкапсуляции.
//	5.4. Предложения по модификации алгоритмов, кода.
//	
//	2) Служащий, персона, рабочий, инженер

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace la0501
{
	public class Persona
	{
		protected string fio;
		protected int age;
		public Persona()
		{
			Console.Write("Имя: ");
			this.fio = Console.ReadLine();
			Console.Write("Возраст: ");
			this.age = Convert.ToInt32(Console.ReadLine());
		}
//		public Persona(string fio, int age)
//		{
//			this.fio = fio;
//			this.age = age;
//		}
		public virtual string getInfo()
		{
			return string.Format("  ФИО: {0}\n  Возраст: {1}", fio, age);
		}
		public virtual string printAll()
		{
			return "Персона:\n"+this.getInfo();
		}
	}
	public class Slug : Persona
	{
		protected int zarplat;
		public Slug()
		{
			Console.Write("Зарплата: ");
			this.zarplat = Convert.ToInt32(Console.ReadLine());
		}

		public override string getInfo()
		{
			return string.Format("{0}\n  Зарплата: {1}", base.getInfo(), zarplat);
		}
		public override string printAll()
		{
			return "Служащий:\n"+this.getInfo();
		}
	}
	public class Rabotnik : Slug
	{
		protected string ceh;
		public Rabotnik()
		{
			Console.Write("Цех: ");
			this.ceh = Console.ReadLine();
		}
		public override string getInfo()
		{
			return string.Format("{0}\n  Цех: {1}", base.getInfo(), ceh);
		}
		public override string printAll()
		{
			return "Работник:\n"+this.getInfo();
		}
	}
	public class Ingener : Slug
	{
		protected string spec;
		public Ingener()
		{
			Console.Write("Специальность: ");
			this.spec = Console.ReadLine();
		}
		public override string getInfo()
		{
			return string.Format("{0}\n  Специальность: {1}", base.getInfo(), spec);
		}
		public override string printAll()
		{
			return "Инженер:\n"+this.getInfo();
		}
	}
    
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите информацию о служащем");
			Persona s = new Slug();
			Console.WriteLine("Введите информацию о рабочем");
			Persona r = new Rabotnik();
			Console.WriteLine("Введите информацию о инженере");
			Persona i = new Ingener();
			Console.WriteLine(s.printAll());
			Console.WriteLine(r.printAll());
			Console.WriteLine(i.printAll());
			Console.ReadKey();
		}
	}

}
