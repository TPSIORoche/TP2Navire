using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;

namespace GestionNavire.ClassesMetier
{
    class Stockage
    {
        private readonly int numero;
        private int capaciteMaxi;
        private int capaciteDispo;

        public int CapaciteDispo
        {
            get => capaciteDispo;

            private set
            {
                if (value <= 0)
                {
                    throw new GestionPortException("la quantité à stocker dans un stockage ne peut être négative");
                }
                else if (this.capaciteDispo >= value)
                {
                    this.capaciteDispo = value;
                }
                else
                {
                    throw new GestionPortException("Impossible de stocker plus que la capacité disponible dans le stockage");
                }
            }
        }

        public Stockage(int numero, int capaciteMaxi, int capaciteDispo)
        {
            if (capaciteMaxi <= 0)
            {
                throw new GestionPortException("Impossible de créer un stockage avec une capacité négative");
            }
            else if (capaciteDispo > capaciteMaxi)
            {
                throw new GestionPortException("La capacité disponible doit être inférieure à la capacité maximum");
            }

            this.numero = numero;
            this.capaciteMaxi = capaciteMaxi;
            this.capaciteDispo = capaciteDispo;
        }

        public Stockage(int numero, int capaciteMaxi) : this(numero, capaciteMaxi, capaciteMaxi)
        {
        }

        public void Stocker(int quantite)
        {
            this.CapaciteDispo -= quantite;
        }
    }
}
