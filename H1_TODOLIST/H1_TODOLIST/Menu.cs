using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_TODOLIST
{
    internal class Menu
    {
        ConsoleKey lastInput; 
        List<ToDoItem> toDoItems;
        //Menu
        public void ShowMenu()
        {
            Console.WriteLine("[1]View Your Todo List [2]Create New Todo [3]Delete Todo [4]Edit Todo [5]Read Todo Info");

            if(lastInput != default)
            {
                switch(lastInput)
                {
                    case ConsoleKey.D1:
                        ViewToDoList();
                        break;
                    case ConsoleKey.D2:
                        CreateToDo();
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                }          
            }              
            GetInput();
        }
          
        //View TodoList
        void ViewToDoList()
        {
            Console.WriteLine("Todo list:\n");
            if(toDoItems != null)
            {
                foreach (ToDoItem item in toDoItems)
                {
                    Console.WriteLine($"Id [{toDoItems.IndexOf(item)}] {item.whatToDo}");
                }
            }
        }

        //Create new ToDo item
        void CreateToDo()
        {
            Console.Clear();
            string whatToDo;
            DateTime deadLine;
            long repeat;
            bool isFavourite = false;
            
            while (true)
            {
                
                Console.WriteLine("What do you want to do?");
                whatToDo = Console.ReadLine();
                if (whatToDo.Trim() != "")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("WrongInput try again");
                }
            }
            string dlSI;
            Console.WriteLine("When whould you like to have this done?\n Date:");
            while(true)
            {
                string s = Console.ReadLine().Trim();
                int date;
                if(Int32.TryParse(s, out date))
                {
                    if (s.Length > 2 || date > 31)
                    { 
                        Console.WriteLine(date + " not correct date please try again");
                    }
                    else
                    {
                        dlSI = s;
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input");
                }
            }
            Console.WriteLine("Month: ");
            while (true)
            {
                string s = Console.ReadLine().Trim();
                int month;
                if (Int32.TryParse(s, out month))
                {
                    if (s.Length > 2 || month > 12)
                    {
                        Console.WriteLine(month + " not correct date please try again");
                    }
                    else
                    {
                        dlSI += $" {s} 23";
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input");
                }
            }
            deadLine = DateTime.Parse(dlSI);
            Console.Clear();
            
            while (true)
            {
                bool r = false;
                Console.WriteLine("Do you want to favourite this?\n[1] YES!\n[2] NO");
                switch (Console.ReadKey(true).Key) 
                {
                    case ConsoleKey.D1:
                        isFavourite= true;
                        r = true;
                        break;
                    case ConsoleKey.D2: 
                        isFavourite= false;
                        r = true;
                        break;
                }
                if (r == true) break;
                Console.Clear();
                Console.WriteLine("Press 1 or 2 please");
            }
        }

        //Read Todo Item

        //Edit Todo Item
        
        //Delete an item

        void GetInput()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        lastInput = ConsoleKey.D1;
                        break;
                    case ConsoleKey.D2:
                        lastInput= ConsoleKey.D2;
                        break;
                    case ConsoleKey.D3:
                        lastInput = ConsoleKey.D3;
                        break;
                    case ConsoleKey.D4:
                        lastInput= ConsoleKey.D4;
                        break;
                    case ConsoleKey.D5:
                        lastInput= ConsoleKey.D5;
                        break;
                }
                break;
            }
            Console.Clear();
            ShowMenu();
        }
    }
}
                    