
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication2
{
	
	class Cnt16
	{
	
		int minZn;
		int maxZn;
		int curZn;

		
		public Cnt16()
		{
			this.minZn = 0;
			this.maxZn = 256;
			this.curZn = 5;			
		}
		
		public Cnt16(int min, int max, int cur)
		{
			this.minZn = min;
			this.maxZn = max;
			this.curZn = cur;
		}
		
		public int Incr()
		{
			
			Cur=Cur+1;
            return Cur;
		}
		
		public int Decr()
		{
			
			Cur=Cur-1;
            return Cur;
		}
		
		public int Cur
		{
			get
			{
				return curZn;
			}
			set
			{
                if (value < minZn)
                    throw new Exception("значение меньше минимального");
                else if (value > maxZn)
                    throw new Exception("значение больше максимального");
                else
                    curZn = value;

            }
        }
		
		public void Print()
		{
            
            Console.WriteLine("16   Min= 0x{0:x} \t Max = 0x{1:x}  \t Cur = 0x{2:x} ", minZn, maxZn, curZn);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
            try
            {
                Cnt16 c1 = new Cnt16();
                c1.Print();

                Console.WriteLine("Введите минимальное, макс и тек");
                int mi = Int32.Parse(Console.ReadLine());
                int ma = Int32.Parse(Console.ReadLine());
                int c  = Int32.Parse(Console.ReadLine());


                Cnt16 c2 = new Cnt16(mi, ma, c);   
                c2.Print();
                c2.Incr();
                c2.Print();
                c2.Incr();
                c2.Print();
                c2.Decr();
                //c2.Print();
            
             
               
                c1.Decr();
                c1.Print();
            
               
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadKey();
		}
	}
}

