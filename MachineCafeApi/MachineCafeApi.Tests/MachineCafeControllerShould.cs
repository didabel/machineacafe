using NFluent;
using MachineCafeApi.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace MachineCafeApi.Tests
{
    public class MachineCafeControllerShould
    {
        [Test]
        public void Update_Last_Commande_For_BadgeId_In_Database()
        {

            var option = new DbContextOptionsBuilder<CommandeContext>()
                .UseInMemoryDatabase(databaseName: "Add_Commande_To_Database")
                .Options;
            var context = new CommandeContext(option);
            var providerData = new ProviderData(context);

            providerData.SaveCommande(new Commande
            {
                Boisson = Boisson.Cafe,
                Sucre = Quantite_Sucre.Elevee,
                Mug = true,
                BadgeId = 999
            });

            var resultat_1 = providerData.GetLastCommande(999);
            Check.That(context.Commandes).CountIs(2);

            Commande New_Commande = new Commande()
            {
                Boisson = Boisson.Chocolat,
                Sucre = Quantite_Sucre.Sans_sucre,
                Mug = false,
                BadgeId = 999
            };
            providerData.SaveCommande(New_Commande);

            Check.That(context.Commandes).CountIs(2);
            var resultat_2 = providerData.GetLastCommande(999);

            Check.That(context.Commandes).CountIs(2); 
            Check.That(resultat_2.Boisson).Equals(Boisson.Chocolat);
        }
    }
}
