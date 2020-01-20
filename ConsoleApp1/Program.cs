/*===========SIMULADOR DE CONTROL DE PLACAS DE VEHICULOS=======

-Objetivo: ingreso y búsqueda de placas de vehículos 
           mediante el uso de tablas Hash 
           Obteniendo como Clave la placa del vehículo.

-Autor: Marvin Erazo
-Fecha: 6/11/2019
-Version: 1.0
*/

//======================LIBRERIAS===============================
using System;
using System.Collections; //libreria que contiene el tipo HashTable
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{

//=========================================================================
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

        public void Ingresar() //F que permite el ingreso de los datos del vehiculo
        {
            Console.Write("Tipo: ");
            Tipo = Console.ReadLine();
            Console.Write("Modelo: ");
            Modelo = Console.ReadLine();
            Console.Write("Año: ");
            Año = int.Parse(Console.ReadLine());
        }

        public void Mostrar()//F que muestra los datos del vehiculo
        {
            Console.WriteLine("Tipo: "+Tipo);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Año: " + Año);

        }
        
    }//Fin DatosV

//=================================================================
    class Program
    {

        static void Main(string[] args) // Funcion Prinical
        {
            int op;
            string clave;
            DatosV obj;//Objeto que se guarda en el item de HashTable
            DatosV aux = new DatosV(); //auxiliar que guarda el item del HashTable
            Hashtable placa = new Hashtable();

            do
            {
                op = Menu();
                Console.Clear();

                if (op == 1) //Ingresa un vehiculo
                {
                    Console.WriteLine("INGRESO DE NUEVO VEHICULO\n");
                    obj = new DatosV();
                    Console.Write("Placa: ");
                    clave = Console.ReadLine();
                    
                    try //manejo de claves iguales
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

                if (op == 2)//busca un vehiculo por su key(placa)
                {
                    Console.WriteLine("BUSQUEDA DE VEHICULO\n");
                    Console.Write("Placa: ");
                    string auxP = Console.ReadLine();

                    if (placa.Contains(auxP))//verifica que exista esa placa
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

                if (op == 3)//despliega la tabla hash
                {
                    foreach (DictionaryEntry val in placa)
                    {
                        Console.WriteLine("Key = {0}", val.Key);

                        Console.WriteLine("Datos--------- ");
                        aux =(DatosV)val.Value;
                        aux.Mostrar();
                    }
                    Console.ReadKey();
                }

                Console.Clear();

            } while (op!=4);
        }//Fin Main

//=================================================================

        static int Menu()//Opciones en pantalla
        {
            Console.WriteLine("1.- Agregar Vehiculo");
            Console.WriteLine("2.- Datos Vehiculo (placa)");
            Console.WriteLine("3.- Desplegar Hash");
            Console.WriteLine("4.- Salir");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
 //===============================================================
    }
}
