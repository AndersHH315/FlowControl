
using System.Security.Cryptography.X509Certificates;

namespace FlowControl
{
    class Program
    {    
        static string age = "";
        static int youth = 0;
        static int middleage = 0;
        static int pensioner = 0;
        static void Main(string[] args)
        {
            string? input = "";
            string? amount = "";
            int result = 0;
            do
            {
                Console.WriteLine("------Main Menu------");
                Console.WriteLine("Skriv 1 för att köpa en biobiljett");
                Console.WriteLine("Skriv 2 för att köpa flera biobiljetter");
                Console.WriteLine("Skriv 0 för att stänga ner");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("Programmet kommer att stängas ner!");
                        break;
                    case "1":
                        Console.WriteLine("Ange din ålder: ");
                        age = Console.ReadLine();
                        while (int.TryParse(age, out int check) == false)
                        {   
                            Console.WriteLine("Skriv din ålder i siffror!");    
                            age = Console.ReadLine();
                        };
                        Console.WriteLine(Receipt(age));
                        break;
                    case "2":
                        Console.WriteLine("Ange antalet biljetter");
                        amount = Console.ReadLine();
                        while (int.TryParse(amount, out int check) == false)
                        {   
                            Console.WriteLine("Skriv antal i siffror!");    
                            amount = Console.ReadLine();
                        }
                        result = int.Parse(amount);
                        Receipt(result);
                        break;
                    default:
                        Console.WriteLine("Fel input!");
                        break;
                }
                
            } while (input != "0");


        }
        static int CheckAge(string age)
        {
            int check = int.Parse(age);
            if(check < 20)
            {
                youth++;
                return 80;                   
                
            }
            else if(check > 64)
            {
                pensioner++;
                return 90;                   
            }
            else
            {
                middleage++;
                return 120;               
            }
        }

        static int AmountOfTickets(int amount)
        {
            int sum = 0;
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Ange din ålder: ");
                age = Console.ReadLine();
                while (int.TryParse(age, out int check) == false)
                {   
                    Console.WriteLine("Skriv din ålder i siffror!");    
                    age = Console.ReadLine();
                }
                sum += CheckAge(age);
            }

            return sum;
        }

        static string Receipt(string age)
        {
            int checkType = CheckAge(age);
            if(youth != 0)
            {
                youth = 0;
                return $"Ungdomspris: {checkType}kr";
            }
            else if(middleage != 0)
            {
                middleage = 0;
                return $"Standardpris: {checkType}kr";
            }
            else if(pensioner != 0)
            {
                pensioner = 0;
                return $"Pensionärspris: {checkType}kr";
            }
            else
            {
                return "Inget köp gjort";          
            }
        }

        static void Receipt(int amount)
        {
            int sum = AmountOfTickets(amount);
            int[] checkPeople = {youth, middleage, pensioner};
            for (int i = 0; i < checkPeople.Length; i++)
            {
                if(youth != 0)
                {
                    Console.WriteLine($"{youth}: Ungdomar");    
                    youth = 0;
                }
                else if(middleage != 0)
                {
                    Console.WriteLine($"{middleage}: Vuxna");    
                    middleage = 0;                  
                }
                else if(pensioner != 0)
                {
                    Console.WriteLine($"{pensioner}: Pensionärer");
                    pensioner = 0;
                    
                }
            }
            Console.WriteLine($"Totalsumma: {sum}kr");

        }
    }

}
