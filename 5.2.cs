//И базовый, и производный классы должны иметь как минимум
//	конструктор по умолчанию, 
//	конструктор копирования, 
//	деструктор (если необходимо), 
//	перегруженную операцию присваивания.
//Где это возможно, необходим вызов функций (методов, конструкторов) базового класса, а не копирование фрагментов кода.
//
//Вариант 2. 
//	Реализуйте однонаправленный список как класс. 
//	Используя механизм наследования, 
//	реализуйте на базе списка расписание занятий 1 курса факультета компьютерных наук с полями 
//		«День недели», 
//		«Номер пары»,
//		«Название курса». 
//	Интерфейс должен позволять просматривать все расписание 
//		на неделю, 
//		на отдельный день 
//		и редактировать поле «название курса».

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0502
{
	class Program
	{
		//////////////////////////////////////////////////////////////////////////////
		//узел списка
		class Node
		{
			public Node next;		//указывает на следующий узел
			public Object data;		//данные узла
		}
		//////////////////////////////////////////////////////////////////////////////
		//однонаправленный список
		class List
		{
			public Node firstNode;		//первый узел
			public Node lastNode;
		//	public int Length { get; private set; }
			public int length;

			public List()
			{
				// создание пустого списка
				this.firstNode = null;
				this.lastNode = this.firstNode;
				this.length = 0;
			}

			//добавляет узел в начало списка
			public void AddFirst(Object _data)
			{
				if (firstNode == null)		//список пустой
				{
					this.AddLast(_data);	//добавить узел в конец списка
				}
				else
				{
					Node newNode = new Node();		// создать временный узел
					newNode.data = _data;
					//сделать временный узел "первым"
					newNode.next = this.firstNode;	
					this.firstNode = newNode;
				}
			}
			
			//добавляет узел в конец списка
			public void AddLast(Object _data)
			{
				if (firstNode == null)		//список пустой
				{
					this.firstNode = new Node();		// создать узел, сделать его "первым"
					this.firstNode.data = _data;
					this.lastNode = this.firstNode;		// этот же узел и является "последним"
					this.firstNode.next = null;			// следующего узла нет
				}
				else
				{
					Node newNode = new Node();			// создать временный узел
					newNode.data = _data;
					
					this.lastNode.next = newNode;		// следующий за "последним" узлом - новый временный узел
					this.lastNode = newNode;			// новый временный узел становится "последним"
					
					this.lastNode.next = null;			// следующего узла пока нет
				}
				++this.length;							//увеличить длину списка
			}
			
			//вставляет узел в список после узла "_node"
			public void InsAfter(Node _node, Object _data)
			{
				Node newNode = new Node();	//создать новый узел
				newNode.data = _data;		//записать в новый узел данные
				//вставка нового узла после _node
				newNode.next = _node.next;
				_node.next = newNode;
			}
		}
		//////////////////////////////////////////////////////////////////////////////
		//инф-ия о расписании
		class RaspData
		{
			public int dayOfWeek;	//день недели
			public int nPar;		//№ пары
			public string curs;		//название курса
			public RaspData(int _dayOfWeek, int _nPar, string _curs)	//конструктор
			{
				this.dayOfWeek = _dayOfWeek;
				this.nPar = _nPar;
				this.curs = _curs;
			}
		}
		//////////////////////////////////////////////////////////////////////////////
		//узел в расписании
		class NodeRasp: Node
		{
			public NodeRasp(int _dayOfWeek, int _nPar, string _curs)	//конструктор
			{
				this.data = new RaspData(_dayOfWeek, _nPar, _curs);
			}
		}
		//////////////////////////////////////////////////////////////////////////////
		//расписание (Наследник от списка)
		class ListRasp: List
		{
			//добавление в расписание (вставка узла в "нужную" позицию)
			public void Insert(int _dayOfWeek, int _nPar, string _curs)
			{
				RaspData raspData = new RaspData(_dayOfWeek, _nPar, _curs);
				
				if (firstNode == null)	//если список пустой
				{
					AddLast(raspData);	//добавить узел в конец списка
				}
				else					//список не пустой
				{
					RaspData d = (RaspData)firstNode.data;
					if ((d.dayOfWeek > _dayOfWeek) || ((d.dayOfWeek == _dayOfWeek) && (d.nPar > _nPar)))
					{
						AddFirst(raspData);	//добавить узел в начало списка
					}
					else
					{
						Node tmpNode = firstNode;
						while (tmpNode.next != null)
						{
							d = (RaspData)tmpNode.next.data;
							if ((d.dayOfWeek > _dayOfWeek) || ((d.dayOfWeek == _dayOfWeek) && (d.nPar > _nPar)))
							{
								InsAfter(tmpNode, raspData);	//добавляем узел после tmpNode
								return;							//выход из процедуры
							}
							tmpNode = tmpNode.next;
						}
						AddLast(raspData);						//добавить узел в конец списка
					}
				}
			}
			
			//все расписание на неделю
			public string printAll()
			{
				string s = "";
				for (int i=1; i<=7; i++)
				{
					s = s + printDay(i);
				}
				return s;
			}
			//расписание на отдельный день 
			public string printDay(int _dayOfWeek)
			{
				string s = string.Format("День {0}:\n", _dayOfWeek);
				Node tmpNode = firstNode;
				RaspData d;
				while (tmpNode != null)
				{
					d = (RaspData)tmpNode.data;
					if (d.dayOfWeek == _dayOfWeek)
					{
						s = s + string.Format("    {0} пара - {1}. \n", d.nPar, d.curs);
					}
					tmpNode=tmpNode.next;
				}
				return s;
			}
			//редактировать поле «название курса».
			public void editCurs(int _dayOfWeek, int _nPar, string _curs)
			{
				Node tmpNode = firstNode;
				RaspData d;
				while (tmpNode != null)
				{
					d = (RaspData)tmpNode.data;
					if ((d.dayOfWeek == _dayOfWeek) && (d.nPar == _nPar))
					{
						d.curs = _curs;
					}
					tmpNode = tmpNode.next;
				}
			}
		}
		
////////////////////////////////////////////////////////////////////////////
		static void Main(string[] args)
		{
		    ListRasp rasp = new ListRasp();
		    //наполнить расписание
			rasp.Insert(1, 1, "1-1-Информатика");
			rasp.Insert(1, 4, "1-4-Информатика");
			rasp.Insert(1, 2, "1-2-Информатика");
			rasp.Insert(2, 1, "2-1-Информатика");
			rasp.Insert(2, 3, "2-3-Информатика");
			rasp.Insert(6, 3, "6-3-Информатика");
			rasp.Insert(6, 1, "6-1-Информатика");
			rasp.Insert(4, 2, "4-2-Информатика");
			rasp.Insert(4, 4, "4-4-Информатика");

			Console.WriteLine("Все расписание на неделю");
			Console.WriteLine(rasp.printAll());
			Console.WriteLine("------------------------");
			Console.WriteLine("Все расписание на вторник");
			Console.WriteLine(rasp.printDay(2));
			Console.WriteLine("------------------------");
			Console.WriteLine("Все расписание на четверг");
			Console.WriteLine(rasp.printDay(4));
			Console.WriteLine("------------------------");
			Console.WriteLine("Заменяем в четверг 2 пару на 'ZZZZZZZZZZZ'");
			rasp.editCurs(4,2,"ZZZZZZZZZZZ");
			Console.WriteLine(rasp.printDay(4));

			Console.ReadKey();
		}
	}

}
