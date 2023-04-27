

using Linq.Clases;

namespace Linq.Interfaces
{
    public interface IServicioCargaDatos
    {
        List<ClaseAnimal> CargarClasesAnimales();
        List<Gato> CargarGatos();
        
    }
}
