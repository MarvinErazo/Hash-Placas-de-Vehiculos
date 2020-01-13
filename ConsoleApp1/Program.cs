using System;
using System.Collections; //libreri que contiene tabla hash
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DatosV //Objeto que contiene los detalles de cada vehiculo
    {
        string tipo;
        string modelo;
        int año;

        public DatosV()
        {
            this.Tipo = "n/a";
            this.Modelo = "n/a";
            this.Año = 1;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Año { get => año; set => año = value; }

        public void Ingresar()
        {
            Console.Write("Tipo: ");
            Tipo = Console.ReadLine();
            Console.Write("Modelo: ");
            Modelo = Console.ReadLine();
            Console.Write("Año: ");
            Año = int.Parse(Console.ReadLine());
        }
        public void Mostrar()
        {
            Console.WriteLine("Tipo: "+Tipo);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Año: " + Año);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            string clave;
            DatosV obj;
            DatosV aux = new DatosV();
            Hashtable placa = new Hashtable();
            do
            {
                op = Menu();
                Console.Clear();
                if (op == 1)
                {
                    Console.WriteLine("INGRESO DE NUEVO VEHICULO\n");
                    obj = new DatosV();
                    Console.Write("Placa: ");
                    clave = Console.ReadLine();
                    
                    try
                    {
                        placa.Add(clave, obj);
                        obj.Ingresar();
                        Console.WriteLine("\nVehiculo agregado exitosamente..");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("La placa {0} ya esta en uso",clave);
                        Console.ReadKey();

                    }

                }
                if (op == 2)   
                {
                    Console.WriteLine("BUSQUEDA DE VEHICULO\n");
                    Console.Write("Placa: ");
                    string auxP = Console.ReadLine();
                    if (placa.Contains(auxP))
                    {
                        Console.WriteLine("Datos---------\n");
                        aux = (DatosV)placa[auxP];
                        Console.WriteLine("Placa: " + auxP);
                        aux.Mostrar();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Esta placa no existe");
                        Console.ReadKey();
                    }
                    
                }
                Console.Clear();
            } while (op!=3);
        }
        static int Menu()
        {
            Console.WriteLine("1.- Agregar Vehiculo");
            Console.WriteLine("2.- Datos Vehiculo (placa)");
            Console.WriteLine("3.- Salir");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
    }
}
