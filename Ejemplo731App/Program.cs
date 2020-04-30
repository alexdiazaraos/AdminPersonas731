using Ejemplo731Model;
using Ejemplo731Model.DAL;
using Ejemplo731Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731App
{
    class Program
    {
        //Atributos
        //No olvidar referenciar el proyecto Model al proyecto App
        //para poder hacer el "using Ejemplo731Model.DAL"
        //  crear el personaDal para poder utilizar una lista dentro del Program
        private static PersonaDAL personaDal = new PersonaDAL();
        private static MedicoDAL medicoDAL = new MedicoDAL();
        private static PacienteDAL pacienteDAL = new PacienteDAL();
        
        static void Main(string[] args)
        {
            while (Menu()) ;
        }

        private static bool Menu()
        {
            bool continuar = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** Menu de Opciones ******");
            Console.WriteLine("1 Para ingresar Medico");
            Console.WriteLine("2 Para Mostrar los Medicos");
            Console.WriteLine("3 Para Eliminar Medico");
            Console.WriteLine("4 Para Ingresar Paciente");
            Console.WriteLine("5 Para Mostrar los Pacientes");
            Console.WriteLine("6 Para eliminar Paciente");
            Console.WriteLine("0 Para Salir del Programa");
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string opcion = Console.ReadLine().Trim();
            //Evaluar la opción del usuario
            switch (opcion)
            {
                case "1": IngresarMedico();
                    break;
                case "2": MostrarMedicos();
                    break;
                case "3": EliminarMedico();
                    break;
                case "4": IngresarPaciente();
                    break;
                case "5": MostrarPacientes();
                    break;
                case "6": EliminarPaciente();
                    break;
                case "0": continuar = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("....Nos vemos");
                    Console.ReadKey();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("debe ingresar una opción válida");
                    break;
            }

            return continuar;
        }

        private static void EliminarPaciente()
        {
            throw new NotImplementedException();
        }

        private static void MostrarPacientes()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<Paciente> pacientes = pacienteDAL.Mostrar();
            if (pacientes.Count() < 1)
            {
                Console.WriteLine("No se Registran Pacientes");
            }
            else
            {
                foreach (Paciente p in pacientes)
                {
                    Console.WriteLine("Pacientes");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(p);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        private static void IngresarPaciente()
        {
            //1 Solicitamos al usuario los valores para almacenar en variables locales
            Console.WriteLine("Ingrese el RUN del Paciente");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Nombre del Paciente");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Paterno del Paciente");
            string paterno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Materno del Paciente");
            string materno = Console.ReadLine().Trim();
            //solicitar y validar la prioridad
            bool prioridadValida;
            int prioridad;
            do
            {
                Console.WriteLine("Ingrese la prioridad del Paciente");
                string prioridadTxt = Console.ReadLine().Trim();
                prioridadValida = Int32.TryParse(prioridadTxt, out prioridad);
            } while (!prioridadValida);
            Console.WriteLine("Ingrese el Sistema de Salud del Paciente");
            string salud = Console.ReadLine().Trim();
            //Creamos el Objeto de la clase Paciente
            Paciente pacientico = new Paciente(run, nombre, paterno, materno, prioridad, salud);

            //************ Asociamos el paciente a un Medico ***********************
            List<Medico> medicos = medicoDAL.Mostrar();
            for (int i = 0; i < medicos.Count(); i++)
            {
                Console.WriteLine("{0} {1}", i, medicos[i]);
            }
            //solicitar el indice del Medico que asociara al paciente
            bool indiceValido;
            int indice;
            do
            {
                Console.WriteLine("Ingrese el INDICE del Paciente");
                string indiceTXT = Console.ReadLine().Trim();
                indiceValido = Int32.TryParse(indiceTXT, out indice);
                //Agregar a pacientico a la lista de medicos
                medicos[indice].Pacientes.Add(pacientico);
            } while (!indiceValido && indice <= medicos.Count());
            //**********************************************************************
            //Agregar el pacientico a las lista de Pacientes
            pacienteDAL.Ingresar(pacientico);
        }

        private static void EliminarMedico()
        {
            throw new NotImplementedException();
        }

        private static void MostrarMedicos()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<Medico> medicos = medicoDAL.Mostrar();
            if (medicos.Count() < 1)
            {
                Console.WriteLine("No se Registran Medicos");
            }
            else
            {
                foreach (Medico m in medicos)
                {
                    Console.WriteLine("Medicos");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine(m);
                    if (m.Pacientes.Count()<1)
                    {
                        Console.WriteLine("     No se Registran Pacientes");
                    }
                    else
                    {
                    Console.WriteLine("     Pacientes asignados");
                    Console.WriteLine("     ------------------------------");
                    for (int i = 0; i < m.Pacientes.Count(); i++)
                    {
                            Console.WriteLine("{0} {1}",i+1,m.Pacientes[i]);
                    }
                    Console.WriteLine("     ------------------------------");
                    }
                    Console.WriteLine("------------------------------");
                }
            }
        }

        private static void IngresarMedico()
        {
            //1 Solicitamos al usuario los valores para almacenar en variables locales
            Console.WriteLine("Ingrese el RUN del Medico");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Nombre del Medico");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Paterno del Medico");
            string paterno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Materno del Medico");
            string materno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese la Especialidad del Medico");
            string especialidad = Console.ReadLine().Trim();
            //Crear un objeto de la clase Medico
            Medico mediquito = new Medico(run, nombre, paterno, materno, especialidad);
            //Agregamos el Objeto a la lista
            medicoDAL.Ingresar(mediquito);
        }
        /*
        private static void Eliminar()
        {
            Console.WriteLine("***** Listado de Personas para Eliminar ****");
            Console.WriteLine("--------------------------------------------");
            //Crear una lista igual a la lista que tiene PersonaDAL
            List<Persona> personas = personaDal.Mostrar();
            if (personas.Count() < 1)
            {
                Console.WriteLine("No se registran personas en la lista");
            }
            else
            {
                for (int i = 0; i < personas.Count(); i++)
                {
                    //Console.WriteLine(i+" ==> "+ personas[i]);
                    Console.WriteLine("{0} ==> {1}",i,personas[i]);
                }
                Console.WriteLine("...Indique el indice de la persona a eliminar");
                //Validamos el indice
                int indice;
                bool indiceValido;
                do
                {
                    string indiceTxt = Console.ReadLine().Trim();
                    indiceValido = Int32.TryParse(indiceTxt, out indice);
                } while (!indiceValido || indice<0 || indice>personas.Count()-1);
                personaDal.Eliminar(personas[indice]);
                Mostrar();
           }
            Console.WriteLine("------------------------------------------\n");
        }
        */
        /*
        private static void Mostrar()
        {
            Console.WriteLine("***** Listado de Personas ****");
            Console.WriteLine("------------------------------");
            //Crear una lista igual a la lista que tiene PersonaDAL
            List<Persona> personas = personaDal.Mostrar();
            if (personas.Count()<1)
            {
                Console.WriteLine("No se registran personas en la lista");
            }
            else
            {
                foreach(Persona p in personas)
                {
                    //Console.WriteLine(p);
                    Console.WriteLine(p + " - IMC: " + p.IMC + " - Estado: "
                        + p.Estado.Nombre + "(" + p.Estado.Codigo + ")");
                }
            }
            Console.WriteLine("------------------------------\n");
        }
        */
        /*
        private static void Ingresar()
        {
            //1 Solicitamos al usuario los valores para almacenar en variables locales
            Console.WriteLine("Ingrese el RUN de la persona");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Nombre de la Persona");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Paterno de la Persona");
            string paterno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el Apellido Materno de la Persona");
            string materno = Console.ReadLine().Trim();
            //1.1 Solicitamos y validamos el peso
            bool pesoValido;
            double peso;
            do
            {
                Console.WriteLine("Ingrese el Peso de la Persona");
                string pesoTxt = Console.ReadLine().Trim();
                pesoValido = Double.TryParse(pesoTxt, out peso);
            } while (!pesoValido);
            //1.2 Solicitamos y validamos la estatura
            bool estaturaValida;
            double estatura;
            do
            {
                Console.WriteLine("Ingrese la estura de la Persona");
                string estaturaTxt = Console.ReadLine().Trim();
                estaturaValida = Double.TryParse(estaturaTxt, out estatura);
            } while (!estaturaValida);

            //3 Crear objeto persona y pasamos las variables a sus atributos
            Persona personita = new Persona(run,nombre,paterno,materno);
            personita.Peso = peso;
            personita.Estatura = estatura;
    //********   Esto se agrego por el struct de Estado del IMC *********************
            if (personita.IMC<18.5)
            {
                personita.Estado = PersonaDAL.DELGADO;
            }
            else if (personita.IMC >= 18.5 && personita.IMC < 25)
            {
                personita.Estado = PersonaDAL.NORMAL;
            }
            else
            {
                personita.Estado = PersonaDAL.OBESIDAD;
            }
    //******************************************************************************
            //4 Agregamos el objeto a la lista de personas
            personaDal.Ingresar(personita);

        }*/
    }
}
