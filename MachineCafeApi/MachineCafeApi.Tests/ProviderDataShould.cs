using MachineCafeApi.Models;
using Microsoft.EntityFrameworkCore;
using NFluent;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MachineCafeApi.Tests
{
    public class UnitTest1
    {
        [Test]
        public void Add_Commande_To_Database()
        {

            var options = new DbContextOptionsBuilder<CommandeContext>()
                .UseInMemoryDatabase(databaseName: "Add_Commande_To_Database")
                .Options;

            using (var context = new CommandeContext(options))
            {
                var providerData = new ProviderData(context);
                Commande info = new Commande()
                {
                    Boisson = Boisson.Cafe,
                    BadgeId = 456,
                    Mug = true
                };


                providerData.SaveCommande(info);

                Check.That(context.Commandes).IsNotNull().And.CountIs(2);
            }
        }


        [Test]
        public void Return_Commande_With_BadgeId()
        {
            var options = new DbContextOptionsBuilder<CommandeContext>()
                .UseInMemoryDatabase(databaseName: "Return_Commande_With_BadgeId")
                .Options;


            using (var context = new CommandeContext(options))
            {
                var providerData = new ProviderData(context);

                var commandes = new List<Commande>()
                {
                    new Commande
                    {
                        Boisson = Boisson.Chocolat,
                        BadgeId = 111,
                        Mug = false

                    },

                    new Commande
                    {
                        Boisson = Boisson.The,
                        BadgeId = 222,
                        Mug = true
                    },

                    new Commande
                    {
                        Boisson = Boisson.Chocolat,
                        BadgeId = 333,
                        Mug = true
                    }
                 };

                foreach (Commande cmd in commandes)
                {
                    providerData.SaveCommande(cmd);
                }

                Check.That(context.Commandes.Count()).IsEqualTo(4);

                var result = context.Commandes.FirstOrDefault(p => p.BadgeId == 222);
                Check.That(result).IsNotNull();

                result = context.Commandes.FirstOrDefault(p => p.BadgeId == 999);
                Check.That(result).IsNull();
            }
        }
    }
}