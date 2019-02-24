using Microsoft.AspNetCore.Mvc;
using MachineCafeApi.Models;


namespace MachineCafeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineCafeController : ControllerBase
    {
        // POST api/MachineCafe/ServirBoisson
        [HttpPost]
        [Route("ServirBoisson")]
        public string ServirBoisson([FromServices]IProviderData providerData, [FromBody]Commande commande)
        {
            if (commande.BadgeId != 0)
            {
                providerData.SaveCommande(commande);
            }

            return "\nBoisson en cours de préparation ... ";
        }


        // POST api/MachineCafe/ProposingBoisson
        [HttpPost]
        [Route("ProposingBoisson")]
        public Commande ProposingBoisson([FromServices]IProviderData providerData, [FromBody]int badgeId)
        {
            Commande commande = providerData.GetLastCommande(badgeId);
            return commande;
        }
    }
}
