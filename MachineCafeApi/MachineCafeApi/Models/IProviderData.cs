namespace MachineCafeApi.Models
{
    public interface IProviderData
    {
        Commande GetLastCommande(int BadgeId);
        void SaveCommande(Commande commande);
    }
}
