using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo731Model
{
    //Crear el struct
    public struct Estado
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    public class Persona
    {
        //Atributos
        private string run;
        private string nombre;
        private string paterno;
        private string materno;
        private double peso;
        private double estatura;
        public Estado Estado { get; set; }

        //Constructor con parametros
        public Persona(string run, string nombre, string paterno, string materno)
        {
            this.run = run;
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.peso = 20;
            this.estatura = 100;
        }

        //Getter y Setter
        public string Run { get => run; set => run = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Paterno { get => paterno; set => paterno = value; }
        public string Materno { get => materno; set => materno = value; }
        public double Peso { get => peso; set => peso = value; }
        public double Estatura { get => estatura; set => estatura = value; }

        //Calculamos y retornamos el IMC
        public double IMC
        {
            get
            {
                return (this.peso / (this.estatura * this.estatura))*100;
            }
        }
        
            //Metodos
        
        public override string ToString()
        {
            return "Sr.(a) " + this.nombre + " " + this.paterno + " " + materno;
        }

    }
}
