
namespace FlowControl
{
    class Program
    {
        static void Main(string[] args)
        {

            string? input = "";
            do
            {
                Console.WriteLine("------Main Menu------");
                Console.WriteLine("Type 0 to exit the program!");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("The program will close now!");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            } while (input != "0");
        }
    }
}
