using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_abstract_factory.Interfaces
{
    public interface IFabricaAutos
    {
        ICarroceria CrearCarroceria();
        IMotor CrearMotor();
    }
}