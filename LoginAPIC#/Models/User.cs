using System.ComponentModel.DataAnnotations;

namespace LoginAPIC_.Models
{
    public class User
    {
        [Key]
        public int IdUsuario { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Identificacion { get; set; }
    }
}
