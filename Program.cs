using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        // Spytaj użytkownika, jakie działania chce podjąć:
        Console.WriteLine("Co chcesz zrobic? ");
        Console.WriteLine("a) zapis do pliku ");
        Console.WriteLine("b) odczyt z pliku");

        string str_menu = Console.ReadLine();
        string patch = "C:/Users/Program-W2/Desktop/rejestr.txt";

        if(!string.IsNullOrEmpty(str_menu))
        {
            try
            {
                char menu = char.Parse(str_menu);

                if(menu == 'a')
                {
                    // Spytaj użytkownika o tekst
                    Console.WriteLine("Wprowadz tekst: ");
                    string tekst = Console.ReadLine();
                    
                    //Konwersja DateTime na string
                    DateTime timing = DateTime.Now;
                    string czas = timing.ToString();

                    //Zapis do pliku
                    Console.WriteLine("Zapisano tekst!");
                    Zapis(patch, tekst, czas);
                    Console.ReadKey();
                }

                else if(menu == 'b')
                {
                    Odczyt(patch);
                }

                else
                {
                    Console.WriteLine("Nie ma takiej opcji");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Nie mozesz wprowadzic tej zmiennej!");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Pole wyboru jest puste!");
            Console.ReadKey();
        }
    }

    public static void Zapis(string patch, string tekst,  string czas)
    {
        using (StreamWriter zapis = new StreamWriter(patch, true))
        {
           zapis.WriteLine(czas + " | " + tekst);
        }
    }

    public static void Odczyt(string patch)
    {
        if(File.Exists(patch))
        {
            using (StreamReader odczyt = new StreamReader(patch))
            {
                string wiersze;
                while((wiersze = odczyt.ReadLine()) != null)
                {
                    Console.WriteLine(wiersze);
                }
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Plik nie istnieje!");
            Console.ReadKey();
        }
    }
}