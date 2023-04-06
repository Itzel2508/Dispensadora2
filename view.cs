using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dispensadora;


namespace app_dispensadora
{
    public class view
    {
        public static void Main(string[] args)
        {
            Maquina dispensadora = new Maquina();
            Console.WriteLine("Bienvenidos a la dispensadora de Itzel");
            bool repetir = true;
            while (repetir)
            {
                string popcion;
                do
                {
                    Console.WriteLine("Es cliente o proveedor?");
                    popcion = Console.ReadLine();


                    if (popcion == "cliente")
                    {
                        Console.WriteLine(dispensadora.listarproducto());
                        Console.WriteLine("codigo del producto que desee comprar ");
                        string codigo_venta = Console.ReadLine();

                        Console.WriteLine(" Solo se reciben monedas de (500-200-100-50)");
                        Console.WriteLine(" Ingrese las monedas con un - en el medio. Ej: 500-500-500-500");


                        dispensadora.pago = Console.ReadLine();


                        consumable comprado = dispensadora.vender(codigo_venta);

                        if (comprado == null)
                        {
                            Console.WriteLine("No se pudo sacar el producto");

                        }
                        else
                        {
                            Console.WriteLine("Su cambio es {0} y el producto es {1}", comprado.cambio, comprado.Nombre);
                        }



                    }

                    else if (popcion == "proveedor")
                    {
                        Console.WriteLine("Estos son los productos que tiene actualmente la maquina expendedora");
                        Console.WriteLine(dispensadora.listarproducto());
                        Console.WriteLine("Si desea agregar un producto nuevo no repita algun codigo que ya existe pero si quiere rellenar un producto ya existente ingrese el mismo codigo,nombre,valor");


                        consumable producto = new consumable();
                        Console.WriteLine("Ingrese el codigo");
                        producto.codigo = Console.ReadLine();

                        Console.WriteLine("Nombre");
                        producto.Nombre = Console.ReadLine();

                        Console.WriteLine("cantidad");
                        producto.cantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Valor");
                        producto.valor = double.Parse(Console.ReadLine());

                        dispensadora.agregarproducto(producto);

                    }
                    else
                    {
                        Console.WriteLine("Opción inválida, por favor intente de nuevo.");
                    }
                } while (popcion != "cliente" && popcion != "proveedor");
            } 
                Console.WriteLine("¿Desea realizar otra operación? (s/n)");
                string respuesta = Console.ReadLine();
                repetir = respuesta == "s";
            }


    }
}