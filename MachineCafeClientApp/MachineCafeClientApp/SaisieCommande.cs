using System;
namespace MachineCafeClientApp
{
    public class SaisieCommande
    {
        public InfoCommande GetBoisson(int badge)
        {
            InfoCommande cmd = new InfoCommande();
            cmd.BadgeId = badge;
            Console.WriteLine("              ********** Selectionnez votre boisson *********\n" +
            	"                            The      --> 1\n" +
            	"                            Cafe     --> 2\n" +
            	"                            Chocolat --> 3\n");

            int boisson = int.Parse(Console.ReadLine());

            Console.WriteLine("              ********** Selectionnez la quantite de sucre *********\n" +
                "                            Sans_Sucre  --> 1\n" +
                "                            Moyenne     --> 2\n" +
                "                            Elevee      --> 3\n");

            int quantiteSucre = int.Parse(Console.ReadLine());

            Console.WriteLine("              ********** Utilisez-vous votre mug?! Y/N *********\n");

            string m = Console.ReadLine().ToUpper();
            bool mug = m == "Y" ? true : false;

            cmd.Boisson = (Boisson)boisson;
            cmd.Sucre = (Quantite_Sucre)quantiteSucre;
            cmd.Mug = mug;
            return cmd;
        }
    }
}
