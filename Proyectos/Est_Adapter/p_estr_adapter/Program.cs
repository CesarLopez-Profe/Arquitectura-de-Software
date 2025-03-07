// See https://aka.ms/new-console-template for more information
using p_estr_adapter.Clases;
using p_estr_adapter.Interfaces;

IAutoGasolina autoCombustion = new AutoGasolina();
        autoCombustion.EncenderMotor();
        autoCombustion.Acelerar();

        // Nuevo auto eléctrico adaptado al sistema antiguo
        AutoElectrico autoElectrico = new AutoElectrico();
        IAutoGasolina adaptado = new AdaptadorAutoElectrico(autoElectrico);
        
        adaptado.EncenderMotor();  // Se traduce a EncenderSistemaElectrico
        adaptado.Acelerar();       // Se traduce a PresionarAcelerador