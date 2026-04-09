using LoginAPIC_.Context;
using LoginAPIC_.DTO;
using LoginAPIC_.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace LoginAPIC_.Servicio
{
    public class UserServ
    {
        private readonly IDataProtector _dataP;
        private readonly Api_DBContext _context;
        public UserServ(Api_DBContext context, IDataProtectionProvider dp)
        {
            _dataP = dp.CreateProtector("LoginAPIC_.Passwords");
            _context = context;
        }
        private string EncryptPassword(string password) => _dataP.Protect(password);
        private string DecryptPassword(string password)=> _dataP.Unprotect(password); 
        

        public async Task<UserDTO.UserReturnDto> login(UserDTO.LoginDto dt)
        {
            if(dt == null) return null;
            var user  =  await _context.User.FirstOrDefaultAsync(u=> u.Email == dt.Email);
            var desencriptar = DecryptPassword(user.Password);
            if(desencriptar != dt.Password) return null;
            return new UserDTO.UserReturnDto(user.Email,user.Nombre,user.Apellido,user.Identificacion);
        }
        public async Task<UserDTO.UserReturnDto> Regitro(UserDTO.RegistroDto dt)
        {
            if (dt == null) return null;
            var user = new User
            {
                Email = dt.Email,
                Password = EncryptPassword(dt.Password),
                Nombre = dt.Nombre,
                Apellido = dt.Apellido,
                Identificacion = dt.Identificacion
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new UserDTO.UserReturnDto(user.Email,user.Nombre,user.Apellido,user.Identificacion);
        }

    }
}
