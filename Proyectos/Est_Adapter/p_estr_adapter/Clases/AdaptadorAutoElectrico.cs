using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_estr_adapter.Interfaces;

namespace p_estr_adapter.Clases
{
    public class AdaptadorAutoElectrico:IAutoGasolina
    {
        private AutoElectrico autoElectrico;
        public AdaptadorAutoElectrico(AutoElectrico autoElectrico)
        {
            this.autoElectrico = autoElectrico;
        }
        public void EncenderMotor()
        {
            autoElectrico.EncenderSistemaElectrico();
        }
        public void Acelerar()
        {
            autoElectrico.PresionarAcelerador();
        }
    }
}