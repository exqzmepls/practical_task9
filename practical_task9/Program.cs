using System;
using ListLibrary;

namespace practical_task9
{
    class Program
    {
        // Вывод меню
        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // Выбор пункта из меню
        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice == 0) choice = menuItems.Length;
                        choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == menuItems.Length - 1) choice = -1;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        // Ввод целого числа
        public static int IntInput(int lBound = int.MinValue, int uBound = int.MaxValue, string info = "")
        {
            bool exit;
            int result;
            Console.Write(info);
            do
            {
                exit = int.TryParse(Console.ReadLine(), out result);
                if (!exit) Console.Write("Введено нецелое число! Повторите ввод: ");
                else if (result <= lBound || result >= uBound)
                {
                    exit = false;
                    Console.Write("Введено недопустимое значение! Повторите ввод: ");
                }
            } while (!exit);
            return result;
        }
        
        static void Main(string[] args)
        {
            // Пункты меню
            string[] MENU_ITEMS = { "Задать исходный список", "Выйти из программы" };

            // Индекс пункта - выход из программы
            const int EXIT_CHOICE = 1;

            // Индекс пункта меню, который выбрал пользователь
            int userChoice;

            while (true)
            {
                // Пользователь выбирает действие (выйти или создать список)
                userChoice = MenuChoice(MENU_ITEMS, "Программа для создания нового списка, включающего элементы, содержащие те же значения в информационных полях, что и элементы исходного списка, но в обратном порядке\nВыберите действие:");
                if (userChoice == EXIT_CHOICE) break;
                Console.Clear();

                // Ввод размера списка
                int n = IntInput(lBound: 0, info: "Введите размер списка (целое число больше 0): ");

                // Ввод элементов
                Console.WriteLine("Введите элементы списка (каждый c новой строки)");
                string[] nodes = new string[n];
                for (int i = 0; i < n; i++) nodes[i] = Console.ReadLine();
                
                // Создание списка
                MyLinkedList<string> list = new MyLinkedList<string>(nodes);

                // Вывод полученного списка
                Console.Clear();
                Console.WriteLine("Полученный список:");
                list.Print("; ");

                // Разворот элементов списка (рекурсивный и нерекурсивный методы)
                MyLinkedList<string> rList2 = MyLinkedList<string>.Reverse(list);
                MyLinkedList<string> rList1 = list.Reverse();

                // Вывод результатов
                Console.WriteLine("Результат нерекурсивного метода:");
                rList1.Print("; ");
                Console.WriteLine("Результат рекурсивного метода:");
                rList2.Print("; ");
                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
                Console.ReadLine();
            }
        }
    } 
}
