using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Todo_list_v5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todo_list = new List<Todo>();
            bool keep_running = true;
            todo_list = LoadList();


            while (keep_running)
            {
                string answer = Menu();

                switch (answer)
                {
                    case "1":
                        ShowList(todo_list);
                        break;
                    case "2":
                        AddItem(todo_list);
                        break;
                    case "3":
                        UpdateItem(todo_list);
                        break;
                    case "4":
                        DeleteItem(todo_list);
                        break;
                    case "5":
                        Quit();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("\n");
            }



        }

        public static string Menu()
        {
            Console.WriteLine("Please select an option");
            Console.WriteLine("1 - Read todo list");
            Console.WriteLine("2 - Add item");
            Console.WriteLine("3 - Update item");
            Console.WriteLine("4 - Delete item");
            Console.WriteLine("5 - Quit \n");

            return Console.ReadLine();
        }




        public static void ShowList(List<Todo> l)
        {
            int i = 1;
            Console.WriteLine("\n");
            Console.WriteLine("----------------------");
            foreach (Todo item in l)
            {
                Console.WriteLine("Item " + i);
                Console.WriteLine("Title: " + item.GetTitle());
                Console.WriteLine("Description: " + item.GetDesc());
                Console.WriteLine("\n");
                i++;
            }
            Console.WriteLine("----------------------");
        }

        public static void AddItem(List<Todo> l)
        {
            Console.WriteLine("Please enter a title");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the description");
            string desc = Console.ReadLine();

            Todo todo_item = new Todo(title, desc);

            l.Add(todo_item);
            Console.WriteLine("Item added succesfully");

            string json = System.Text.Json.JsonSerializer.Serialize(l);
            var curDir = Directory.GetCurrentDirectory();
            curDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\"));
            curDir = Path.GetFullPath(Path.Combine(curDir, @"List\Todo.json"));
            File.WriteAllText(curDir, json);
        }

        public static void UpdateItem(List<Todo> l)
        {
            Console.WriteLine("Please enter the number of the item you want to change");
            ShowList(l);
            int change_item = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Please enter the new title");
            string new_title = Console.ReadLine();
            Console.WriteLine("Please enter the new description");
            string new_desc = Console.ReadLine();
            l[change_item].SetTitle(new_title);
            l[change_item].SetDesc(new_desc);

            Console.WriteLine("Item updated succesfully");


            string json = System.Text.Json.JsonSerializer.Serialize(l);
            var curDir = Directory.GetCurrentDirectory();
            curDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\"));
            curDir = Path.GetFullPath(Path.Combine(curDir, @"List\Todo.json"));
            File.WriteAllText(curDir, json);
        }

        public static void DeleteItem(List<Todo> l)
        {
            Console.WriteLine("Please enter the number of the item you want to delete");
            ShowList(l);
            int delete_item = int.Parse(Console.ReadLine()) - 1;

            l.RemoveAt(delete_item);

            Console.WriteLine("Item deleted succesfully");


            string json = System.Text.Json.JsonSerializer.Serialize(l);
            var curDir = Directory.GetCurrentDirectory();
            curDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\"));
            curDir = Path.GetFullPath(Path.Combine(curDir, @"List\Todo.json"));
            File.WriteAllText(curDir, json);
        }

        public static List<Todo> LoadList()
        {
            List<Todo> l = new List<Todo>();
            var curDir = Directory.GetCurrentDirectory();

            curDir = Path.GetFullPath(Path.Combine(curDir, @"..\..\..\"));
            curDir = Path.GetFullPath(Path.Combine(curDir, @"List\Todo.json"));

            var json = File.ReadAllText(curDir);

            l = JsonConvert.DeserializeObject<List<Todo>>(json);
            return l;
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}

