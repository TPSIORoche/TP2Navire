using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navire.Classesmetier;
using GestionNavire.Exceptions;

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
                //Instanciations();
                try { TesterEnregistrerArrivee(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }

                try { TesterEnregistrerArriveeV2(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }
                

                try { TesterEnregistrerDepart(); }
                catch (GestionPortException ex)
                {Console.WriteLine(ex.Message);}
                
                Console.WriteLine("Fin normale du programme");
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }
        

        private static void Instanciations()
        {
            try
            {
                Navire.Classesmetier.Navire navire = new Classesmetier.Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                navire = new Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500);
                navire = new Classesmetier.Navire("IMO8715871", "MSC PILAR", "Porte-conteneurs", 67183);
                navire = new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750);
                navire = new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrowarbures", 51201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TesterEnregistrerArrivee()
        {
            Classesmetier.Navire navire = null;
            try
            {
                //Classesmetier.Navire navire = new Classesmetier.Navire("IMO927639", "Copper Spirit", "Hydrocarbure",156827);
                //port.EnregistrerArriver(navire);
                //Classesmetier.Navire navire2 = new Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500);
                //port.EnregistrerArriver(navire2);
                //Classesmetier.Navire navire3 = new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750);
                //port.EnregistrerArriver(navire3);
                //Classesmetier.Navire navire4 = new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrowarbures", 51201);
                //port.EnregistrerArriver(navire4);
                navire = new Classesmetier.Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArriver(navire);
                navire = new Classesmetier.Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArriver(navire);
            }
            catch(GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TesterEnregistrerArriveeV2()
        {
            Classesmetier.Navire navire = null;
            try
            {
                port.EnregistrerArriver(new Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
                port.EnregistrerArriver(new Classesmetier.Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerArriver(new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750));
                port.EnregistrerArriver(new Classesmetier.Navire("IMO9405423", "SERENA", "Tanker", 158583));
                port.EnregistrerArriver(new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrowarbures", 51201));
                port.EnregistrerArriver(new Classesmetier.Navire("IMO9748681", "NORDIC SPACE", "Tanker",15787));
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
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
            catch(GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
