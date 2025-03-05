using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_abstract_factory.Interfaces;

namespace p_abstract_factory.Clases
{
    public class ClienteFabricaAutos
    {
        private readonly ICarroceria carroceria;
        private readonly IMotor motor;

        public ClienteFabricaAutos(IFabricaAutos fabrica)
        {
            carroceria = fabrica.CrearCarroceria();
            motor = fabrica.CrearMotor();
        }

        public void ArmarAuto()
        {
            carroceria.Ensamblar();
            motor.Instalar();
        }



    }
}