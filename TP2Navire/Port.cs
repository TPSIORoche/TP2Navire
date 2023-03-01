using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;
using GestionNavire.ClassesMetier;

namespace Navire.Classesmetier
{
    class Port
    {
        private string nom;
        private int nbNaviresMax;
        private Dictionary<string, Navire> navires;
        private List<Stockage> stockages;

        public Port(string nom)
        {
            this.nom = nom;
            this.nbNaviresMax = 5;
            this.navires = new Dictionary<string, Navire>();
            this.stockages = new List<Stockage>();

        }

        internal Dictionary<string, Navire> Navires { get => navires; set => navires = value; }



        public void EnregistrerArrivee(Navire navire)
        {
            try
            {
                if (this.navires.Count < this.nbNaviresMax)
                {
                    this.navires.Add(navire.Imo, navire);
                }
                else
                {
                    throw new GestionPortException("Ajout impossible, le port est complet");
                }
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
            }

        }

        public bool EstPresent(String imo)
        {
            return navires.ContainsKey(imo);
        }

        public bool EstPresent(Navire navire)
        {
            return navires.ContainsKey(navire.Imo);
        }

        public void EnregistrerDepart(String imo)
        {
            if (EstPresent(imo))
            {
                this.navires.Remove(imo);
            }
            else
            {
                throw new GestionPortException("Impossible d'enregistrer le départ du navire " + imo + ", il n'est pas dans le port");
            }
        }

        public void Dechargement(String imo)
        {
            Navire navire = GetNavire(imo);
            if (navire != null && navire.LibelleFret == "Porte-conteneur")
            {
                int i = 0;
                while (i < stockages.Count() && !navire.EstDecharge())
                {
                    //On est sur un stockage
                    // On tes d'abord si le stockage disponible est > 0
                    // 2 possibilités : Soit décharger l'entierté du bateau soit partiellement
                    if (this.stockages[i].CapaciteDispo > 0)
                    {
                        // On va pouvoir décharger
                        if (navire.QteFret <= stockages[i].CapaciteDispo)
                        {
                            // On va décharger la totalité du navire
                            stockages[i].Stocker(navire.QteFret);
                            navire.Decharger(navire.QteFret);
                        }
                        else
                        {
                            //On décharge partiellement
                            navire.Decharger(stockages[i].CapaciteDispo);
                            stockages[i].Stocker(stockages[i].CapaciteDispo);

                        }
                    }
                    i++;
                }
                // On sort de la boucle et on test comment on est sorti de la boucle
                // On déclenchera une exception si le navire n'est pas complètement déchargé

                if (!navire.EstDecharge())
                {
                    throw new GestionPortException("Le navire n'a pas pu être entièrement déchargé");
                }
            }
            else
            {
                throw new GestionPortException("Le navire ne peut pas être déchargé");
            }
        }

        public void AjoutStockage(Stockage stockage)
        {
            stockages.Add(stockage);
        }

        public Navire GetNavire(String imo)
        {
            if (navires.ContainsKey(imo))
            {
                return navires[imo];
            }
            else
            {
                return null;
            }
        }

        Navire n;
        public bool GetNavire(String imo, out Navire n)
        {
            return navires.TryGetValue(imo, out n);
        }
    }
}

