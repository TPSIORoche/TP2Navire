using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Navire.Classesmetier
{
    class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
        }

        public Navire(string imo, string nom) : this(imo, nom, "Indéfini", 0)
        {
            //this.imo = imo;
            //this.nom = nom;
            //this.libelleFret = "0";
            //this.qteFretMaxi = 0;
        }

        public string Nom { get => nom; set => nom = value; }
        public string LibelleFret { get => libelleFret; set => libelleFret = value; }


        //public string Affiche(Navire navire)
        //{
        //    return ($"\nIdentification : {navire.imo}\nNom : {navire.nom}\nType de frêt : {navire.libelleFret}\nQuantité de frêt : {navire.qteFretMaxi}\n-------------------------------");
        //}
        public string Imo 
        { get => imo;
            set
            {
                if (Regex.IsMatch(value, @"^IMO[0-9]{7}$"))
                {
                    this.imo = value;
                }
                else
                {
                    throw new Exception("Erreur,syntax invalide");
                }
            }
        }


        public int QteFretMaxi
        {
            get => qteFretMaxi;
            set
            {
                if (value <= 0)
                {
                    this.qteFretMaxi = value;
                }
                else
                {
                    throw new Exception("Erreur, quantité de fret non valide");
                }
            }
        }


        public string Affiche(Navire navire)
        {
            return ($"{navire.imo.ToString()}\n{navire.nom.ToString()}\n{navire.libelleFret.ToString()}\n{navire.qteFretMaxi.ToString()}\n");
        }
    }
}