using System;

namespace learn_it_terminal
{
    class Program
    {
        static void DisplayMenu() {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new words!");
            Console.WriteLine("2. Test me!");
            Console.WriteLine("3. Exit");
        }

        static int ReadOptions(){
            string lineRead = Console.ReadLine();
            int readNum;
            try {
                readNum = Int32.Parse(lineRead);
                if(readNum != 1 && readNum != 2) {
                    readNum = -1;
                }
            } catch (Exception e) {
                readNum = -1;
            }
            return readNum;
        }

        static void AddWords() {

        }

        static void TestWords() {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to learn it!");
            while(true){
                DisplayMenu();
                int option = ReadOptions();
                if(option == -1) {
                    break;
                } else if(option == 1) {
                    AddWords();
                } else {
                    TestWords();
                }
            }

        }
    }
}
