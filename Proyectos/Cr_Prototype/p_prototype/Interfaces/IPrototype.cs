using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_prototype.Interfaces
{
    public interface IPrototype<T> //Delegado genérico que permite que la interfaz sea genérica y reutilizable para múltiples tipos de datos sin acoplarla a una clase específica.
    {
        T Clone();
    }
}