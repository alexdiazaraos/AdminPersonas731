using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model.DAL
{
    public class PacienteDAL
    {
        //Atributos
        public static List<Paciente> pacientes = new List<Paciente>();

        //metodos 
        public void Ingresar(Paciente p)
        {
            pacientes.Add(p);
        }
        public List<Paciente> Mostrar()
        {
            return pacientes;
        }
        public void Eliminar(Paciente p)
        {
            pacientes.Remove(p);
        }
    }
}
