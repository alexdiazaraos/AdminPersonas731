using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model.DTO
{
    public class Medico:Persona
    {
        //Atributos
        private string especialidad;
        private List<Paciente> pacientes= new List<Paciente>();

        public Medico(string run, string nombre, string paterno,
            string materno, string especialidad) : base(run,nombre,paterno,materno)
        {
            base.Run = run;
            base.Nombre = nombre;
            base.Paterno = paterno;
            base.Materno = materno;
            this.especialidad = especialidad;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        public List<Paciente> Pacientes { get => pacientes; set => pacientes = value; }

        public override string ToString()
        {
            return base.ToString() + " - " + this.especialidad;
        }
    }
}
