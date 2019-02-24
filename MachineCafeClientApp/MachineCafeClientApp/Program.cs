using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace MachineCafeClientApp
{
    class Program
    {
     static void Main(string[] args)
        {
            TraitememtCommande.Start();

            while (true)
            {
                Console.WriteLine("              *************************************\n" +
                "              ********** Machine a cafe ***********\n" +
                "              *************************************");


                TraitememtCommande.TraitementAsync().GetAwaiter().GetResult();


                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
