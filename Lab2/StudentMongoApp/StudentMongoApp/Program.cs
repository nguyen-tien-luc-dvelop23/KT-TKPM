using System.Text;

namespace StudentMongoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.InputEncoding = Encoding.UTF8;

            new StudentUI().Run();
        }
    }
}