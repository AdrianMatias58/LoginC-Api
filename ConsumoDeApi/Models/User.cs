namespace ConsumoDeApi.Models
{
    public class User
    {
        public int IdUsere { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
    }
}
