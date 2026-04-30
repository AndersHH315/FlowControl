
using System.Security.Cryptography.X509Certificates;

namespace FlowControl
{
    class Program
    {
        static void Main(string[] args)
        {

            string? input = "";
            string? age = "";
            do
            {
                Console.WriteLine("------Main Menu------");
                Console.WriteLine("Skriv 1 för att köpa en biobiljett");
                Console.WriteLine("Skriv 0 för att stänga ner");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("Programmet kommer att stängas ner!");
                        break;
                    case "1":
                        Console.WriteLine("Hur gammal är du?");
                        age = Console.ReadLine();
                        while (int.TryParse(age, out int check) == false)
                        {   
                            Console.WriteLine("Skriv din ålder i siffror!");    
                            age = Console.ReadLine();
                        }
                        int result = int.Parse(age);
                        Console.WriteLine(checkAge(result));
                        break;
                    default:
                        Console.WriteLine("Fel input!");
                        break;
                }
                
            } while (input != "0");


        }
        static string checkAge(int age)
        {

            if(age < 20)
                return "Ungdomspris: 80kr";                   
            else if(age > 64)
                return "Pensionärspris: 90kr";                   
            else
                return "Standardpris: 120kr";               
        }
    }
}
