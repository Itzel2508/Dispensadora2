using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensadora
{
    public class Maquina
    {
        public List<consumable> productos { get; set; }
        public string pago { get; set; }
        public Maquina() {

            this.productos = new List<consumable>();

            consumable cocacola = new consumable();
            
            cocacola.Nombre = "cocacola";
            cocacola.cantidad = 2;
            cocacola.valor = 2000;
            cocacola.codigo = "01";
            

            

            consumable galletas = new consumable();

            
            galletas.Nombre = "galletas";
            galletas.cantidad= 5;
            galletas.valor = 3000;
            galletas.codigo = "02";
            

            

            consumable minichips = new consumable();
            
            minichips.Nombre = "minichips";
            minichips.cantidad= 5;
            minichips.valor = 2000;
            minichips.codigo = "03";


            this.productos.Add(cocacola);
            this.productos.Add(galletas);
            this.productos.Add(minichips);


        }

        public int validaproducto(string codigo)
        {
            int encontro = -1;

            for (int i=0; i < this.productos.Count; i++)
            {
                if (this.productos[i].codigo == codigo) 
                { encontro = i; }
            }

            return encontro;
        }
            

        public bool agregarproducto( consumable producto)
        {
            int enc = this.validaproducto(producto.codigo);
           if(enc >= 0)
            {
                this.productos[enc].sumarcantidad(producto.cantidad);
            }
            else 
            {
                this.productos.Add(producto);
            }
            return true;
        }



        public double validarmonedas(string[] monedas)
        {
            double total = 0;
            foreach(string moneda in monedas)
            {
                switch (moneda)
                {
                    case "500":
                        total += 500;
                        break;
                    case "200":
                        total += 200;
                        break;
                    case "100":
                        total += 100;
                        break;
                    case "50":
                        total += 50;
                        break;
                    default:
                        Console.WriteLine("Monedas no reconocida: " + moneda);
                        break;
                }
            }

            return total;
        }
        //monedas de 500-200-100-50
        public consumable vender(string codigo)
        {
            int enc = this.validaproducto(codigo);
            if(enc >= 0)
            { 
             if (this.productos[enc].validarcantidad())
             {
                    string[] monedas = this.pago.Split('-');
                    double total = this.validarmonedas(monedas);
                    if (this.productos[enc].validarvalor(total))
                    {

                        double cambio = total - this.productos[enc].valor;

                        int monedasDeQuinientos = (int)Math.Floor(cambio / 500);
                        cambio -= monedasDeQuinientos * 500;

                        int monedasDeDoscientos = (int)Math.Floor(cambio / 200);
                        cambio -= monedasDeDoscientos * 200;

                        int monedasDeCien = (int)Math.Floor(cambio / 100);
                        cambio -= monedasDeCien * 100;

                        int monedasDeCincuenta = (int)Math.Floor(cambio / 50);
                        cambio -= monedasDeCincuenta * 50;

                        if (cambio > 0)
                        {
                            Console.WriteLine("No se puede devolver todo el cambio. Sobran " + cambio + " unidades.");
                        }

                        consumable resultado = this.productos[enc];
                        resultado.cambio = monedasDeQuinientos * 500 + monedasDeDoscientos * 200 + monedasDeCien * 100 + monedasDeCincuenta * 50;


                        this.productos[enc].restarproducto();


                        return this.productos[enc];
                    }


             }
            }
            return null;
        }

        public string listarproducto()
        {
            string lista = "";
            foreach (consumable item in this.productos)
            {
                lista += item.codigo + " " + item.Nombre + " " + item.cantidad + " " + item.valor+ "\n";
            }
            return lista;
        }
    }
}
