using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;
using Navire.Classesmetier;

namespace Navire.Classesmetier
{
    class Port
    {
        private string nom;
        private int nbNavireMax;
        private Dictionary<string,Navire> navires;

        public Port(string nom)
        {
            this.nom = nom;
            this.nbNavireMax = 5;
            this.navires = new Dictionary<string, Navire>();
        }

        internal Dictionary<string, Navire> Navires { get => navires; set => navires = value; }


        public void EnregistrerArriver(Navire navire)
        {
            try
            {
                if (this.navires.Count < this.nbNavireMax)
                {
                    this.navires.Add(navire.Imo, navire);
                }
                else
                {
                    throw new GestionPortException("Ajout impossible,le port est complet");
                }
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
            }
        }
        
        public void EnregistrerDepart(String imo)
        {
            try
            {
                this.navires.Remove(imo);
            }
            catch (KeyNotFoundException)
            {
                throw new GestionPortException("Impossible d'enregistrer le départ du navire "+ imo + ", il n'est pas dans le port");
            }
        }
    }
}

namespace GestionNavire.Exceptions
{
    class GestionPortException : Exception
    {
        public GestionPortException(string message)
            : base("Erreur de : " + Environment.UserName + " le " + DateTime.Now.ToLocalTime() + "\n" + message) { }
    }
}
