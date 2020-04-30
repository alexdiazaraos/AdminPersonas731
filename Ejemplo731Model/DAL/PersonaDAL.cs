using Ejemplo731Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model.DAL
{
    public class PersonaDAL
    {
        //Atributos
        //Creamos una lista vacia para almacenar los objetos
        private static List<Persona> personas = new List<Persona>();

        //Creamos los Estados que puede tomar una persona de acuerdo a su IMC
        public static readonly Estado OBESIDAD = new Estado()
        {
            Nombre = "Aguatonao",
            Codigo = "E01"
        };
        public static readonly Estado NORMAL = new Estado()
        {
            Nombre = "Pulento",
            Codigo = "E02"
        };
        public static readonly Estado DELGADO = new Estado()
        {
            Nombre = "Peter la Anguila",
            Codigo = "E03"
        };


        //Metodos
        public void Ingresar(Persona p)
        {
            personas.Add(p);
        }

        public List<Persona> Mostrar()
        {
            return personas;
        }

        public void Eliminar(Persona p)
        {
            personas.Remove(p);
        }
    }
}
