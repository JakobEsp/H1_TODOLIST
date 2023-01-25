using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace H1_TODOLIST
{
    internal class Menu
    {
        ConsoleKey lastInput; 
        List<ToDoItem> toDoItems = new();
        //Menu
        public void ShowMenu()
        {
            Console.WriteLine("[1]View Your Todo List [2]Create New Todo [3]Delete Todo [4]Edit Todo [5]Read Todo Item Info");

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
                        DeleteToDo();
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        ReadToDo();
                        break;
                }          
            }              
            GetInput();
        }
          
        //View TodoList
        void ViewToDoList()
        {
            Console.WriteLine("\nTodo list:\n");
            if(toDoItems != null)
            {
                foreach (ToDoItem item in toDoItems)
                {
                    Console.WriteLine($"[{toDoItems.IndexOf(item)}] {item.whatToDo} \n   When: {item.deadLine}");
                }
            }
        }

        //Create new ToDo item
        void CreateToDo()
        {
            Console.Clear();
            string whatToDo;
            DateTime deadLine;
            long? repeat;
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
            ToDoItem newItem = new ToDoItem(DateTime.Now, deadLine, null, whatToDo, false, isFavourite);
            toDoItems.Add(newItem);
            Console.Clear();
            lastInput = default;
            ShowMenu();
        }

        //Read Todo Item
        void ReadToDo()
        {
            int id;
            Console.WriteLine("Write id of the Todo you would like to read");
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out id))
                {
                    if (id <= toDoItems.Count)
                    {
                        ToDoItem standIn = toDoItems[id];
                        Console.WriteLine($"\n" +
                            $"Task: {standIn.whatToDo}\n" +
                            $"Status: {(standIn.isDone ? "Finished" : "Unfinished")}\n" +
                            $"Made: {standIn.created}\n" +
                            $"Deadline: {standIn.deadLine}\n" +
                            $"{(standIn.isFavorite ? "Favourite" : "")}");
                        lastInput = default;
                        break;
                    }
                    else Console.WriteLine("Invalid id");
                }
                else Console.WriteLine("Invalid input");
            }
        }

        //Edit Todo Item
        void EditItem()
        {
            while (true)
            {
                int id;
                bool valid = false;
                ViewToDoList();
                Console.WriteLine("Write the ID of the Todo that you would like to Edit");
                string input = Console.ReadLine().Trim();

                if (Int32.TryParse(input, out id))
                {
                    if (id <= toDoItems.Count)
                    {
                        ToDoItem standIn= toDoItems[id];
                        Console.WriteLine($"\n" +
                            $"Task: {standIn.whatToDo}\n" +
                            $"Status: {(standIn.isDone ? "Finished" : "Unfinished")}\n" +
                            $"Made: {standIn.created}\n" +
                            $"Deadline: {standIn.deadLine}\n" +
                            $"{(standIn.isFavorite ? "Favourite" : "")}");
                        break;
                    }
                    else Console.WriteLine("invalid id");
                }
                else Console.WriteLine("could not parse");

            }
        }
        
        //Delete an item
        void DeleteToDo()
        {
            while(true)
            {
                int id;
                bool valid = false;
                ViewToDoList();
                Console.WriteLine("Write the ID of the Todo that you would like to remove");
                string input = Console.ReadLine().Trim();

                if (Int32.TryParse(input, out id))
                {
                    if (id <= toDoItems.Count)
                    {
                        toDoItems.RemoveAt(id);
                        valid= true;
                    }
                    else Console.WriteLine("invalid id");
                }
                else Console.WriteLine("could not parse");

                if (valid){
                    Console.WriteLine("Todo was deleted");
                    lastInput = default;
                    break;
                }
            }
        }

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
                    