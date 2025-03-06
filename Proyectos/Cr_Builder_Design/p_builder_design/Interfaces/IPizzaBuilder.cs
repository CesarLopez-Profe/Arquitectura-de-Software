using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p_builder_design.Clases;

namespace p_builder_design.Interfaces
{
    public interface IPizzaBuilder
    {
        void Comenzar(); //Reset, comienza a crear una nueva pizza
        void ExtenderMasa(string masa);
        void PonerSalsa(string salsa);
        void AdicionarIngrediente(string ingrediente);
        Pizza RecogerProducto(); //GetResult
    }
}