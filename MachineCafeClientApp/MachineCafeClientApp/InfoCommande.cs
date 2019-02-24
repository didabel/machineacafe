
namespace MachineCafeClientApp
{
    public enum Boisson { The = 1, Cafe, Chocolat };
    public enum Quantite_Sucre { Sans_sucre = 1, Moyenne, Elevee };

    public class InfoCommande
    {
        public Boisson Boisson { get; set; }
        public Quantite_Sucre Sucre { get; set; }
        public bool Mug { get; set; }
        public int BadgeId { get; set; }
    }
}
