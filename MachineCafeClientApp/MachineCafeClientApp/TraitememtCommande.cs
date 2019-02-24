using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MachineCafeClientApp
{
    public class TraitememtCommande : IDisposable
    {
        static HttpClient httpClient = new HttpClient();
        static InfoCommande cmd;

        public static void Start()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5001/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task TraitementAsync()
        {
            try
            {
                Console.WriteLine("\nAvez-vous un badge !? Y/N");
                string commandeBadge = Console.ReadLine().ToUpper();

                if (commandeBadge == "Y")
                {
                    Console.WriteLine("\nVeuillez saisir le numero de votre Badge");

                    int badge = int.Parse(Console.ReadLine());

                    cmd = await ProposeCommadeAsync(badge);

                    if (cmd != null)
                    {
                        string mug = cmd.Mug == true ? "Avec votre Mug" : "Sans votre Mug";

                        Console.WriteLine("\nDesirez vous prendre un " + cmd.Boisson + ", quantite_Sucre " + cmd.Sucre + " , " + mug + " ?!  Y/N");

                        string choix = Console.ReadLine().ToUpper();

                        if (choix == "Y")
                        {
                            Console.WriteLine(await GetCommande(cmd));
                            Console.WriteLine("\nVotre boisson est prete veuillez la prendre");
                        }

                        else
                        {
                            PrepareCommande(badge);
                        }
                    }

                    else
                    {
                        PrepareCommande(badge);
                    }
                }
                else
                {
                    PrepareCommande(0);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static async Task<InfoCommande> ProposeCommadeAsync(int badgeId)
        {
            InfoCommande commande = new InfoCommande();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                "api/MachineCafe/ProposingBoisson", badgeId);

            if (response.IsSuccessStatusCode)
            {
                commande = await response.Content.ReadAsAsync<InfoCommande>();
            }
            return commande;
        }

        static async Task<string> GetCommande(InfoCommande commande)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
            "api/MachineCafe/ServirBoisson", commande);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsAsync<string>();
                return result;
            }
            return null;   
        }

        static async void PrepareCommande(int badgeId)
        {
            SaisieCommande saisie = new SaisieCommande();
            cmd = saisie.GetBoisson(badgeId);
            Console.WriteLine(await GetCommande(cmd));
            Console.WriteLine("\nVotre boisson est prete veuillez la prendre");
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}
