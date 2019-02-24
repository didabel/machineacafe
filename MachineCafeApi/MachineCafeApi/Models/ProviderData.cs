using System.Linq;

namespace MachineCafeApi.Models
{
    public class ProviderData : IProviderData
    {
        private CommandeContext _context;

        public ProviderData(CommandeContext context)
        {
            _context = context;

            if (_context.Commandes.Count() == 0)
            {
                // Create a new commande if collection is empty
                _context.Commandes.Add(new Commande { Boisson = Boisson.Chocolat, Sucre = Quantite_Sucre.Moyenne, Mug = false, BadgeId = 123});
                _context.SaveChanges();
            }
        }


        public Commande GetLastCommande(int BadgeId)
        {
            var result = _context.Commandes.FirstOrDefault(p => p.BadgeId == BadgeId);
            return result;
        }


        public void SaveCommande(Commande commande)
        {
            var cmd_BadgeId = _context.Commandes.FirstOrDefault(p => p.BadgeId == commande.BadgeId);
           
            if (cmd_BadgeId != null)
            {
                cmd_BadgeId.Boisson = commande.Boisson;
                cmd_BadgeId.Sucre = commande.Sucre;
                cmd_BadgeId.Mug = commande.Mug;
            }

            else
            {
                _context.Commandes.Add(commande);
            }

            _context.SaveChanges();
        }
    }
}


/*
 * using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SkypeLocation.WebApi.ViewModels.Dal;

namespace SkypeLocation.WebApi.ViewModels
{
    public class ProviderData : IProviderData
    {
        private PositionLearningContext _context;

        public ProviderData(PositionLearningContext context)
        {
            _context = context;
        }

        public IList<InfoPositions> GetAllPositions()
        {
            IList<InfoPositions> result;
            result = _context.InfoPositions.ToList();
            return result;
        }

       

        public void SaveModelIntoDatabase(MemoryStream stream)
        {
            byte[] file = stream.ToArray();

            var info = new InfoLearning()
            {
                LearnModel = file,
                Date =  DateTimeOffset.Now
            };

            var model = _context.InfoLearning.FirstOrDefault();
            if (model != null)
            {
                model.LearnModel = info.LearnModel;
                model.Date = info.Date;
            }

            else
            {
                _context.InfoLearning.Add(info);
            }
            
            _context.SaveChanges();
        }

       

        //public IList<string> GetMacAddressList()
        //{
        //  var result = _context.InfoPositions.Select(p => new {p.Bssid1, p.Bssid2, p.Bssid3, p.Bssid4}).ToString();
        //  return result.l;
        //}
    }
}

*/
