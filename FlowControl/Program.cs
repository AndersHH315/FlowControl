
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
                Console.WriteLine("Type 1 buy a cinema ticket");
                Console.WriteLine("Type 0 to exit the program");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("The program will close now!");
                        break;
                    case "1":
                        Console.WriteLine("How old are you?");
                        age = Console.ReadLine();
                        while (int.TryParse(age, out int check) == false)
                        {   
                            Console.WriteLine("Type your age in numbers!");    
                            age = Console.ReadLine();
                        }
                        int result = int.Parse(age);
                        Console.WriteLine(checkAge(result));
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
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
