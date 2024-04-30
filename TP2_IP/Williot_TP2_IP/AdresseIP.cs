using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Williot_TP2_IP
{
    internal class AdresseIP
    {
        string sIP  = "192.168.51.14" ; // adresse IP
        string smask = "255.255.254.0"; //masque
        int[] tabIP = new int[4]; // IP
        int[] tabMask = new int[4]; //masque
        int[] tabSsReseau = new int[4]; //sous réseau
        int[] tabBroadcast = new int[4];// adresse broadcast
        int[] tabAdresseHote = new int[4]; // n° hôte de l'IP
        int nbMaxIpDispos;      //nb max d'IP dispos dans le ss-réseau

        public AdresseIP()
        {
           saisir();
            creerTabIP(); // transforme la stringIP en un tableau de 4 entiers tabIP
            creerMask();  // transforme la stringMask en un tableau de 4 entiers tabIP
            afficherIP();
            afficherMask();
            afficherIPHexa();
            afficherMaskHexa();
            afficherIPBin();
            afficherMaskBin();
            calculSsReseau();  // calcule tabSsReseau
            afficherSsReseau();
            calculAdresseBroadCast();   // calcul tabBroadcast
            afficherAdresseBroadcast();
            calculNbAdresseDispo();
            calculAdresseHote();
            afficherAdresseHote();
            afficherAdresseCIDR();
            Console.ReadKey();
        }



        static void Main(string[] args)
        {
            new AdresseIP();
        }

        public void saisir()
        {
            Console.WriteLine("Entrez l'adresse IP : ");
            sIP = Console.ReadLine();
            Console.WriteLine("Entrez le masque : ");
            smask = Console.ReadLine();

        }
        public void creerTabIP()
        {
            string[] tab = sIP.Split('.');
            for (int i = 0; i < 4; i++)
            {

                tabIP[i] = int.Parse(tab[i]);
            }

        }

        public void creerMask()
        {
            string[] tab = smask.Split('.');
            for (int i = 0; i < 4; i++)
            {

                tabMask[i] = int.Parse(tab[i]);
            }
        }

        public void afficherIP()
        {
            Console.WriteLine("address IP : " + "\t" + tabIP[0] + "." + tabIP[1] + "." + tabIP[2] + "." + tabIP[3]);

        }
        public void afficherMask()
        {
            Console.WriteLine("Masque sous-reseau : " + "\t" + smask);
            Console.Write("\n");

        }
        public void afficherIPHexa()
        {
            Console.Write("convertion ip en hexadecimal  : " + "\n");

            for (int i = 0; i < 4; i++)
            {
                string hexaValue = tabIP[i].ToString("X");
                Console.Write(hexaValue + ".");

            }

            Console.Write("\n");
            Console.Write("\n");


        }
        public void afficherMaskHexa()
        {
            Console.WriteLine("convertion mask en hexadecimal  : ");
            for (int i = 0; i < 4; i++)
            {
                string hexaValueMask = tabMask[i].ToString("X");
                Console.Write(hexaValueMask + ".");
            }
            Console.WriteLine("\n");
        }
        public void afficherIPBin()
        {
            Console.WriteLine("convertion Ip en Binaire  : ");
            for (int i = 0; i < 4; i++)
            {
                string decValueBinary = Convert.ToString(tabIP[i], 2);
                Console.Write(decValueBinary + ".");
            }

            Console.WriteLine("\n");
        }
        public void afficherMaskBin()
        {
            Console.WriteLine("convertion Mask en Binaire  : " + "\t");
            for (int i = 0; i < 4; i++)
            {
                string decValueBinary = Convert.ToString(tabMask[i], 2);
                Console.Write(decValueBinary + ".");
            }

            Console.WriteLine("\n");
        }
        public void calculSsReseau()
        {
            for (int i = 0; i < 4; i++)
            {
                tabSsReseau[i] = tabIP[i] & tabMask[i];

            }
        }
        public void afficherSsReseau()
        {
            Console.WriteLine("Clacule de sous réseaux : ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(tabSsReseau[i] + ".");
            }
            Console.WriteLine("\n");
        }
        public void calculAdresseBroadCast()
        {

            for (int i = 0; i < 4; i++)
            {
                int m = ~tabMask[i];
                m = m & 255;
                tabBroadcast[i] = tabIP[i] | m;

            }

        }
        public void afficherAdresseBroadcast()
        {
            Console.WriteLine("Calcul de broadcast : ");
            Console.Write("\r");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(tabBroadcast[i] + ".");
            }
            Console.Write("\r");
        }


        public void calculNbAdresseDispo()
        {
            Console.Write("\n");
            Console.Write("\n");

            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int m = tabMask[i];
                for (int j = 0; j < 8; j++)
                {
                    
                    if ((m & 1) == 0)
                    {
                        count++;
                    }
                    m = (m >> 1);
                }

            }
            nbMaxIpDispos = (int)(Math.Pow(2, count) - 2);
            Console.WriteLine("Nombre d'addresses disponible : " + nbMaxIpDispos);

        }

        public void calculAdresseHote()
        {
            Console.Write("\n");
            for (int i = 0; i < 4; i++)
            {
                tabAdresseHote[i] = tabIP[i] & ~tabMask[i];

            }
        }

        public void afficherAdresseHote()
        {
            Console.WriteLine("Calcul d'hotes : ");
            Console.Write("\r");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(tabAdresseHote[i] + ".");
            }
            Console.Write("\n");
        }

        public void afficherAdresseCIDR()
        {
            Console.Write("\n");
            Console.Write("\n");

            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int mask = tabMask[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((mask & 1) != 0)
                    {
                        count++;
                    }
                    mask = (mask >> 1) ;
                }

            }
            nbMaxIpDispos = count;
            Console.WriteLine("Address Cidr : " + sIP + "/" + nbMaxIpDispos);
        }
    }
}
    
        
    

    
    

