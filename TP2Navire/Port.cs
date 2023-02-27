using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!(this.nbNavireMax == this.navires.Count))
            {
                this.navires.Add(navire.Imo,navire);
            }
            else
            {
                throw new Exception("Ajout impossible,le port est complet");
            }
        }
    }

}
