using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_estr_facade.Clases
{
    public class AutoFacade
    {
        private Motor motor;
        private Freno frenos;
        private AireAcondicionado aire;

        public AutoFacade()
        {
            motor = new Motor();
            frenos = new Freno();
            aire = new AireAcondicionado();
        }

        public void ArrancarAutomovil()
        {
            motor.Encender();
            aire.Encender();
            frenos.Desactivar();
            Console.WriteLine("Automóvil arrancado y listo para conducir.");
        }

        public void DetenerAutomovil()
        {
            frenos.Activar();
            motor.Apagar();
            aire.Apagar();
            Console.WriteLine("Automóvil detenido.");
        }

    }
}