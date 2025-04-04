namespace PrestamosVehiculos.Domain.Entities
{
    using PrestamosVehiculos.Domain.Services;

    public class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int HistorialCrediticio { get; private set; }
        
        private readonly EvaluadorCreditoService _evaluadorCredito;

        protected Cliente() { }

        public Cliente(int id, string nombre, int historialCrediticio)//, EvaluadorCreditoService evaluadorCredito)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (historialCrediticio < 0 || historialCrediticio > 1000)
                throw new ArgumentException("El historial crediticio debe estar entre 0 y 1000.");

            Id = id;
            Nombre = nombre;
            HistorialCrediticio = historialCrediticio;
            //_evaluadorCredito = evaluadorCredito;
        }

        /*public bool EsAptoParaPrestamo()
        {
            if (_evaluadorCredito != null)
                return _evaluadorCredito.EsClienteElegible(HistorialCrediticio);
            else
                throw new Exception("El evaluador Crédito llega en null Cliente.cs"); //esta llegando en null
        }*/
    }
}
