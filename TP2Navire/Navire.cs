﻿using System;
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
        private double qteFret;

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
            this.QteFret = qteFret;
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

        private double QteFret 
        { 
            get => qteFret;
            set
            {
                if (value >= 0 && value <= this.QteFretMaxi)
                {
                    this.qteFret = value;
                }
                else
                {
                    throw new Exception("Erreur, quantité de fret non valide");
                }
            }
        }

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
                if (value >= 0)
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

        public void Decharger(int quantite)
        {
            //try
            //{
                if (0 > quantite)
                {
                    throw new Exception("La quantité à décharger ne peut être négative ou nulle");
                }
                if (this.qteFret < quantite)
                {
                    throw new Exception("Impossible de décharger plus que la quantité de fret dans le navire");
                }
                else
                {
                    this.qteFret = qteFret - quantite;
                }
            //}
            //catch(Exception ex)
            //{
                
            //}
        }

        public bool EstDecharge()
        {
            return this.qteFret == 0;
        }
    }
}

namespace GestionNavire.ClassesMetier
{
    class Stockage
    {
        private int numero;
        private int capaciteMaxi;
        private int capciteDispo;

        public int CapciteDispo { get => capciteDispo;}
        public int CapaciteMaxi 
        { 
            get => capaciteMaxi;
            set 
            {
                if (value <= 0)
                {
                    throw new GestionPortException("Impossible de créer un stockage avec une capacité négative");
                }
                else
                {
                    this.capaciteMaxi = value;
                }
            }
        }

        public Stockage(int numero, int capaciteMaxi, int capciteDispo)
        {
            this.numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.capciteDispo = capciteDispo;
        }
    }
}