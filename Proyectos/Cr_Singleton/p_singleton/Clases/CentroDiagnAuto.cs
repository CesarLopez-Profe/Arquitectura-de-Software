using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_singleton
{
    //Singleton con atributo estático y Lazy Initialization
    public class CentroDiagnAuto
    {
        // Atributo estático: se comparte en toda la aplicación
        public static int TotalAutomoviles = 0;

        // Instancia única del Singleton (Lazy Initialization)
        //La clase Lazy<T> en C# proporciona una forma segura y eficiente 
        //de inicializar objetos de manera diferida (Lazy Initialization).
        private static readonly Lazy<CentroDiagnAuto> instancia =
            new Lazy<CentroDiagnAuto>(() => new CentroDiagnAuto()); //Expresion lambda que define cómo se debe crear la instancia cuando sea necesaria.

        // Propiedad pública para acceder a la única instancia, es el getter de la propiedad
        // expresion de cuerpo miembro que equivale a: public static CentroControlAutomoviles Instancia {get { return instancia.Value; }}
        //Value es una propiedad de Lazy<T> que obtiene el valor de la instancia única.

        public static CentroDiagnAuto Instancia => instancia.Value; //El primer acceso a la propiedad Value crea la instancia única.

        // Constructor privado para evitar instanciación externa
        private CentroDiagnAuto()
        {
            Console.WriteLine("Centro de diagnóstico automotriz, inicializado.");
        }

        // Método para registrar un automóvil
        public void RegistrarAutomovil(string modelo)
        {
            TotalAutomoviles++; // Incrementa el contador estático
            Console.WriteLine($"Automóvil registrado: {modelo}. Total registrados: {TotalAutomoviles}");
        }
    }
}