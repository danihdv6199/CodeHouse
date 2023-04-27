using Linq.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Clases
{
    public class ServicioCargaDatos : IServicioCargaDatos
    {
        public List<ClaseAnimal> CargarClasesAnimales()
        {
            List<ClaseAnimal> result = new List<ClaseAnimal>();

            result.AddRange(new List<ClaseAnimal>
            {
                new ClaseAnimal
                {
                    Id = 1,
                    Descripcion = "Mamifero"
                },
                new ClaseAnimal
                {
                    Id = 2,
                    Descripcion = "Oviparo"
                },
            });

            return result;
        }

        public List<Gato> CargarGatos()
        {
            List<Gato> result = new List<Gato>();

            result.AddRange(new List<Gato>
            {
                new Gato
                {
                    TipoAnimal = 1,
                    Color = "Blanco",
                    Edad = 3
                },

                 new Gato
                {
                    TipoAnimal = 2,
                    Color = "negro",
                    Edad = 2
                },
                  new Gato
                {
                    TipoAnimal = 2,
                    Color = "marron",
                    Edad = 2
                },
            });

            return result;
        }
    }
}
