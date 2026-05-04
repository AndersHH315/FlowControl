
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

namespace FlowControl
{
    class Program
    {    
        //Globara variablar som används för ålder och vilken ålder
        static string age = "";
        static int child = 0;
        static int youth = 0;
        static int middleage = 0;
        static int pensioner = 0;
        static int pensionerOverHundred = 0;
        static void Main(string[] args)
        {
            //Variablar som hanterar inputs för de olika metoderna i switch case satsen
            string? input = "";
            string? amount = "";
            int result = 0;
            do
            {
                Console.WriteLine("------Main Menu------");
                Console.WriteLine("Skriv 1 för att köpa en biobiljett");
                Console.WriteLine("Skriv 2 för att köpa flera biobiljetter");
                Console.WriteLine("Skriv 3 och mata sedan in en text");
                Console.WriteLine("Skriv 4 mata in en mening på minst 3 ord");
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
                        Console.WriteLine(Receipt(result));
                        break;
                    case "3":
                        Console.WriteLine("Skriv något här och se vad som händer!");
                        input = Console.ReadLine();
                        Console.WriteLine(RepeatTenTimes(input));
                        break;
                    case "4":
                        Console.WriteLine("Skriv en mening på minst 3 ord!");
                        input = Console.ReadLine();
                        while (input.Split(' ').Count() !<= 2)
                        {
                            Console.WriteLine("Meningen måste innehålla minst 3 ord");
                            input = Console.ReadLine();
                        }
                        Console.WriteLine(TheThirdWord(input));
                        break;
                    default:
                        Console.WriteLine("Fel input!");
                        break;
                }
                
            } while (input != "0");

        }
        //Metod som kollar priset beroende på ålder
        //Samt adderar till youth/pensioner/middleage för att sedan kunna skriva ut det på ett kvitto
        static int CheckAge(string age)
        {
            int check = int.Parse(age);
            if(check < 5)
            {
                child++;
                return 0;
            }
            else if(check < 20)
            {
                youth++;
                return 80;                      
            }
            else if(check > 100)
            {
                pensionerOverHundred++;
                return 0;
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
        //Metod för att räkna priset på mängden biljetter som köps och ber om varjes persons ålder
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
        //Skriver ut ett kvitto på köpet för en person
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
        //Skriver ut ett kvitto på ett fler köp
        static string Receipt(int amount)
        {
            int sum = AmountOfTickets(amount);
            string totalPersons = "";
            for (int i = 0; i < 3; i++)
            {
                if(child != 0)
                {
                    totalPersons += $"{child}: Barn\n";
                    child = 0;
                }
                else if(youth != 0)
                {
                    if(youth < 2)
                        totalPersons += $"{youth}: Ungdom\n";
                    else
                        totalPersons += $"{youth}: Ungdomar\n";
                    youth = 0;
                }
                else if(middleage != 0)
                {
                    if(middleage < 2)
                        totalPersons += $"{middleage}: Vuxen\n";
                    else
                        totalPersons += $"{middleage}: Vuxna\n";
                    middleage = 0;              
                }
                else if(pensioner != 0)
                {
                    if(pensioner < 2)
                        totalPersons += $"{pensioner}: Pensionär\n";
                    else
                        totalPersons += $"{pensioner}: Pensionärer\n";
                    pensioner = 0;
                }
                else if(pensionerOverHundred != 0)
                {
                    if(pensionerOverHundred < 2)
                        totalPersons += $"{pensionerOverHundred}: Pensionär över 100\n";
                    else
                        totalPersons += $"{pensionerOverHundred}: Pensionärer över 100\n";
                    pensionerOverHundred = 0;
                }
            }
            return $"Antal personer: \n{totalPersons}Totalsumma: {sum}kr";

        }
        //Repeterar en mening tio gånger
        static string RepeatTenTimes(string repeat)
        {
            string sum = ""; 
            for (int i = 1; i < 11; i++)
            {
                sum += $"{i}." + repeat + " ";
            }
            return sum;
        }
        //Tar in en mening på 3 ord eller mer sedan splitar meningen och skickar tillbaka det tredje ordet i meningen.
        static string TheThirdWord(string sentence)
        {
            var split = sentence.Split(' ');
            string thirdWord = split[2].ToString();

            return thirdWord;

        }
    }

}
