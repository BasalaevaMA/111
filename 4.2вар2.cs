/*4.3.3 
 * 	+	В рамках консольного приложения разработать класс В – наследник класса А (задание 2) с полем d и свойством с2. 
 * 	+	Свойство с2 – результат вычисления выражения над полями a, b, d. 				(/=, +)
 * 	+	В теле свойства использовать управляющий оператор (см. вариант в таблице 4.2). 	(switch)
 * 	+	У класса А создать конструктор, инициализирующий его поля. 
 * 		Для класса В определить 2 конструктора: 
 * 	+			один – наследуется от конструктора класса А, 
 * 	+			второй – собственный. 
 * 	+	В теле программы создать объекты классов А и В, продемонстрировав работу всех конструкторов. 
 * 	+	Вывести значения свойства на экран.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication2
{
    class A
    {
        private float a;
        private float b;
        public A()                      //конструктор по умолчанию
        {
            a = 4.8f;
            b = 1.6f;
        }
        public A(float a, float b)      //конструктор с инициализацией полей
        {
            this.a = a;
            this.b = b;
        }
        public float c
        {
            get
            {
                return a /= b;
            }
        }
    }

    class B : A                         //класс B - наследник класса A
    {
        private float d;
        public float c2                     //свойство c2
        {
            get
            {
                switch ((int)d)
                {
                    case 5:
                        return c + d / 2;
                        break;
                    case 10:
                        return c + d * 2;
                        break;
                    default:
                        return c + d;
                        break;
                }
            }
        }
        //конструктор класса B - наследуется от конструктора класса А
        public B(float a, float b, float d) : base(a, b)
        {
            this.d = d;
        }
        //конструктор класса B - свой собственный
        public B(float d)
        {
            this.d = d;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //создаем объект класса A. Используем конструктор по умолчанию
            A obja1 = new A();
            Console.WriteLine("obja1.c={0}", obja1.c);

            //создаем объект класса A. Используем конструктор с инициализацией полей
            A obja2 = new A(6, 3);
            Console.WriteLine("obja2.c={0}", obja2.c);

            //создаем объект класса B. Используем конструктор класса B, наследуемый от конструктора класса А
            B objb1 = new B(6, 3, 10);
            Console.WriteLine("objb1.c2={0}", objb1.c2);

            //создаем объект класса B. Используем конструктор класса B - свой собственный
            B objb2 = new B(5);
            Console.WriteLine("objb2.c2={0}", objb2.c2);
            Console.ReadKey();
          
        }
    }
}
