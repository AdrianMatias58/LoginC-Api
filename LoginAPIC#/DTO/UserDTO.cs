namespace LoginAPIC_.DTO
{
    public class UserDTO
    {
        public record LoginDto(
            string Email,
            string Password
        );
        public record RegistroDto(
            string Email,
            string Password,
            string Nombre,
            string Apellido,
            string Identificacion
        );
        public record UserReturnDto(
            string Email,
            string Nombre,
            string Apellido,
            string Identificacion
        );
    }
}
