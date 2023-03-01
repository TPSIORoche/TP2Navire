using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navire.Classesmetier;
using GestionNavire.Exceptions;
using GestionNavire.ClassesMetier;

namespace Navire.Application
{
    class Program
    {
        private static Port port;

        static void Main(string[] args)
        {
            try
            {
                port = new Port("Toulon");
                try { TesterEnregistrerArrivee(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }
                try { TesterEnregistrerArriveeV2(); }
                catch(GestionPortException ex)
                { Console.WriteLine(ex.Message); }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("--------Début des déchargements----------");
                Console.WriteLine("-----------------------------------------");
                AjouterStockages();
                TesterDechargerNavires();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("----------Fin des déchargements----------");
                Console.WriteLine("-----------------------------------------");
                try { TesterEnregistrerDepart(); }
                catch(GestionPortException ex) { Console.WriteLine(ex.Message); }
                Console.WriteLine("Fin normale du programme");
                ////Instanciations();
                //try { TesterEnregistrerArrivee(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                //try { TesterEnregistrerArriveeV2(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                //try { TesterEnregistrerDepart(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                //TesterDecharger();
                //TesterInstanciationsStockage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }

        public static void Instanciations()
        {
            try
            {
                Classesmetier.Navire navire = new Classesmetier.Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 50);
                navire = new Navire.Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-Conteneurs", 197500, 50);
                navire = new Classesmetier.Navire("IMO8715871", "MSC Pilar", "Porte-conteneurs", 67183, 50);
                navire = new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750, 50);
                navire = new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201, 50);
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TesterEnregistrerArrivee()
        {
            Classesmetier.Navire navire = null;
            try
            {
                navire = new Classesmetier.Navire("IMO9427639", "Navire1", "Hydrocarbures", 156827, 50);
                port.EnregistrerArrivee(navire);
                navire = new Classesmetier.Navire("IMO9427639", "Navire1", "Hydrocarbures", 156827, 50);
                port.EnregistrerArrivee(navire);
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TesterEnregistrerArriveeV2()
        {
            Classesmetier.Navire navire = null;
            try
            {
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500, 50));
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO8715871", "MSC Pilar"));
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750, 50));
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9405423", "SERENEA", "Tanker", 158583, 50));
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201, 50));
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9748681", "NORDIC SPACE", "Tanker", 157587, 50));
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire" + navire.Imo + " est déjà enregistré");
            }
        }

        public static void TesterEnregistrerDepart()
        {
            try
            {
                port.EnregistrerDepart("IMO9427639");
                port.EnregistrerDepart("IMO9405423");
                port.EnregistrerDepart("IMO1111111");
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TesterDecharger()
        {
            try
            {
                Classesmetier.Navire navire = null;
                navire = new Classesmetier.Navire("IMO9427639", "Navire1", "Hydrocarbures", 156827, 50);
                navire.Decharger(51);
                Console.WriteLine("Bien déchargée");
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TesterInstanciationsStockage()
        {
            try
            { new Stockage(1, 15000); }
            catch (GestionPortException ex)
            { Console.WriteLine(ex.Message); }
            try
            { new Stockage(2, 12000, 10000); }
            catch (GestionPortException ex)
            { Console.WriteLine(ex.Message); }
            try
            { new Stockage(3, -25000, -10000); }
            catch (GestionPortException ex)
            { Console.WriteLine(ex.Message); }
            try
            { new Stockage(4, 15000, 20000); }
            catch (GestionPortException ex)
            { Console.WriteLine(ex.Message); }

        }

        public static void AjouterStockages()
        {
            port.AjoutStockage(new Stockage(1, 160000));
            port.AjoutStockage(new Stockage(2, 12000));
            port.AjoutStockage(new Stockage(3, 25000));
            port.AjoutStockage(new Stockage(4, 15000));
            port.AjoutStockage(new Stockage(5, 15000));
            port.AjoutStockage(new Stockage(6, 15000));
            port.AjoutStockage(new Stockage(7, 15000));
            port.AjoutStockage(new Stockage(8, 15000));
            port.AjoutStockage(new Stockage(9, 35000));
            port.AjoutStockage(new Stockage(10, 19000));
        }

        public static void TesterDechargerNavires()
        {
            try
            {
                string imo = "IMO9839272";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                string imo = "IMO1111111";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                string imo = "IMO9574004";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9786841","EVER GLOBE","Porte-conteneurs",198937,190000));
                string imo = "IMO9786841";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Classesmetier.Navire("IMO9776432", "CHACGM LOUIS BLERIOT", "Porte-conteneurs", 202684, 190000));
                string imo = "IMO9776432";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }
        


    }
}

