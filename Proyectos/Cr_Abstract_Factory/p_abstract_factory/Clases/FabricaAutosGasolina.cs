using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_abstract_factory.Interfaces;

namespace p_abstract_factory.Clases
{
    public class FabricaAutosGasolina:IFabricaAutos
    {
        public ICarroceria CrearCarroceria() => new CarroceriaGasolina();

        public IMotor CrearMotor() => new MotorGasolina();
    }
    
}