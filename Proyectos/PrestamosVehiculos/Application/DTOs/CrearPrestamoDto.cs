namespace PrestamosVehiculos.Application.DTOs
{
    public class CrearPrestamoDto
    {
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public int PlazoMeses { get; set; }
        public decimal TasaInteres { get; set; }
    }
}
