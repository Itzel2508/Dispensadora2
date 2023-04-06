using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dispensadora
{
    public class consumable
    {

        public string codigo { get; set; }
        public string Nombre { get; set; }
        
        public int cantidad { get; set; }
        public double valor { get; set; }

        public double cambio { get; set; }

        public void sumarcantidad(int cantidad)
        {
            this.cantidad += cantidad;
        }

        public bool validarcantidad()
        {
            if
               (this.cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool validarvalor(double valor)
        {
            if (this.valor <= valor)
            {
                this.cambio = valor - this.valor; 
                
                
                return true;
            }
            return false;
        }

        public void restarproducto()
        { this.cantidad --;
        }

    }
}

