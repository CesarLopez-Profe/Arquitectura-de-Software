using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P_Repaso.Interfaces
{
    public interface IValidaAutomovil
    {
        bool ValidarPlaca(string placa);
        bool ValidarMarca(string marca);
        bool ValidarModelo(string modelo);
        bool ValidarValor(ulong valor);
        bool ValidarAno(ushort ano);
        bool ValidarCilindraje(ushort cilindraje);
        bool ValidarNroPuestos(byte nro_puestos);
        bool ValidarNroPuertas(byte nro_puertas);
    }
}