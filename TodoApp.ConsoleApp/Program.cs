using System;
using TodoApp.Services;

namespace TodoApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this program is making a task's and save them to xml document. Enjoy :)");
            Console.WriteLine();
            
             TodoServices.ReadOrWrite();
        }
    }
}
