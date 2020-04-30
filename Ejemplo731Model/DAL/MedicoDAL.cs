using Ejemplo731Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model.DAL
{
    public class MedicoDAL
    {
        //Atributos
        public static List<Medico> medicos = new List<Medico>();

        //Metodos
        public void Ingresar(Medico m)
        {
            medicos.Add(m);
        }
        public List<Medico> Mostrar()
        {
            return medicos;
        }
        public void Eliminar(Medico m)
        {
            medicos.Remove(m);
        }
    }
}
