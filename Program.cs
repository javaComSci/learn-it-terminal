using System;

namespace learn_it_terminal
{
    class Program
    {
        static void DisplayMenu() {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new words from file!");
            Console.WriteLine("2. View all my words");
            Console.WriteLine("2. Test me!");
            Console.WriteLine("Press any other key to exit");
            Console.WriteLine("Your Choice: ");
        }

        static int ReadOptions(){
            string lineRead = Console.ReadLine();
            Console.WriteLine();
            int readNum;
            try {
                readNum = Int32.Parse(lineRead);
                if(readNum != 1 && readNum != 2 && readNum != 3) {
                    readNum = -1;
                }
            } catch (Exception e) {
                readNum = -1;
            }
            return readNum;
        }

        static void AddWords() {
            Console.WriteLine("Specify name of file to add words from");
            string fileName;
            try {
                fileName = Console.ReadLine();
                WordAdder w = new WordAdder();
                w.AddWordsFromFile(fileName);
                Console.WriteLine("Words successfully added. \n");
            } catch (Exception e) {
                fileName = null;
                Console.WriteLine("Error adding words from file. Please add again. \n");
            }
        }

        static void ViewWords(){
            WordViewer wordViewer = new WordViewer();
            wordViewer.ViewWords();
        }

        static void TestWords() {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("------------Welcome to learn it!---------");
            while(true){
                DisplayMenu();
                int option = ReadOptions();
                if(option == -1) {
                    break;
                } else if(option == 1) {
                    AddWords();
                } else if(option == 2) {
                    ViewWords();
                } else {
                    TestWords();
                }
            }

        }
    }
}
