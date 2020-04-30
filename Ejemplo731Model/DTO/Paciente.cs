using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model
{
    public class Paciente:Persona
    {
        //Atributos
        private int prioridad;
        private string salud;

        public Paciente(string run, string nombre, string paterno,string materno,
            int prioridad, string salud):base(run,nombre,paterno,materno)
        {
            base.Run = run;
            base.Nombre = nombre;
            base.Paterno = paterno;
            base.Materno = materno;
            this.prioridad = prioridad;
            this.salud = salud;
        }

        //Metodos
        public int Prioridad { get => prioridad; set => prioridad = value; }
        public string Salud { get => salud; set => salud = value; }

        public override string ToString()
        {
            return base.ToString()+ " Sist. Salud: "+ this.salud;
        }
    }
}
