using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1
{
   public class Operacion
    {
        public Persona BuscarPersona(int id)
        {
            var personas = ObtenerPersonas();
            var p = (from persona in personas
                     where persona.Id == id
                     select persona).First();
            return p;

        }
        public List<Persona> ObtenerPersonas()
        {
            var datos = ObtenerLineas();
            List<Persona> personas = new List<Persona>();
            foreach (var item in datos)
            {
                string[] info = item.Split(',');
                Persona persona = new Persona
                {
                    Id = int.Parse(info[0]),
                    Nombre = info[1],
                    Profesion = info[2],
                    Edad = int.Parse(info[3])
                };
                personas.Add(persona);
            }
            return personas;
        }
        public List<string> ObtenerLineas()
        {
            try
            {
                List<string> lineas = new List<string>();
                string[] info = null;
                if (File.Exists("Datos.txt"))
                {
                    info = File.ReadAllLines("Datos.txt");
                }

                foreach (string item in info)
                {
                    lineas.Add(item);
                }
                return lineas;
            }
            catch (System.Exception)
            {


            }
            return null;
        }
    }
}
