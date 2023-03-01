using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using GestionNavire.Exceptions;

namespace Navire.Classesmetier
{
    class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;
        private int qteFret;


        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi, int qteFret)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
            this.QteFret = qteFret;
        }
        public Navire(string imo, string nom) : this(imo, nom, "Indéfini", 0, 0) { }


        public int QteFret
        {
            get => qteFret;
            set
            {
                if (value >= 0 && value <= qteFretMaxi)
                {
                    this.qteFret = value;
                }
                else
                {
                    throw new  GestionPortException("Valeur incohérente pour la quantité de fret stockée dans le navire");
                }
            }
        }

        public string Imo
        {
            get => imo;
            set
            {
                if (Regex.IsMatch(value, @"^IMO[0-9]{7}$"))
                {
                    this.imo = value;
                }
                else
                {
                    throw new GestionPortException("erreur : numéro IMO non valide");
                }
            }
        }

        public string Nom => nom;
        public string LibelleFret { get => libelleFret; set => libelleFret = value; }
        public int QteFretMaxi
        {
            get => qteFretMaxi;
            set
            {
                if (value >= 0)
                {
                    this.qteFretMaxi = value;
                }
                else
                {
                    throw new GestionPortException("Erreur, quantité de fret non valide");
                }
            }
        }

        public void Decharger(int quantite)
        {
            if (quantite < 0)
            {
                throw new GestionPortException("La quantité à décharger ne peut être négative ou nulle");
            }
            else if (quantite > this.QteFret)
            {
                throw new GestionPortException("Impossible de décharger plus que la quantité de fret dans le navire");
            }
            this.QteFret -= quantite;
        }

        public bool EstDecharge()
        {
            return this.QteFret == 0;
        }
    }
}
