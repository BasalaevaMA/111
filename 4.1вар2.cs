using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*4.3.2 
 * В рамках консольного приложения создать класс А с полями а и b и свойством с. 
* Свойство – значение выражения над полями а и b (выражение и типы полей – см. вариант в таблице 4.1). /=,+
* Поля инициализировать при объявлении класса. 
* Конструктор оставить по умолчанию. 
* Проследить, чтобы поля а и b напрямую в других классах были недоступны. 
* Создать класс Programm с одним методом – точкой входа. 
* В теле метода создать объект класса А, вывести на экран значение свойства с [6].
*/
namespace ConsoleApplication2
{
    class A
    {
        private float a, b;
        public A()
        {
            a = 4.8f;
            b = 1.6f;
        }
        public float c
        {
            get
            {
                return a /= b;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            A obja = new A();
            Console.WriteLine("obja.c={0}", obja.c);
            Console.ReadKey();
                }
    }
   
}




