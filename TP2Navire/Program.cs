using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navire.Classesmetier;

namespace Navire.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Instanciations();
                Console.WriteLine("Fin normale du programme");
            }
            catch(Exception ex)
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
                navire = new Classesmetier.Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", -197500);
                navire = new Classesmetier.Navire("IMO8715871", "MSC PILAR", "Porte-conteneurs", 67183);
                navire = new Classesmetier.Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750);
                navire = new Classesmetier.Navire("IMO9574004", "TRITON SEAHAWK", "Hydrowarbures", 51201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
