using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Repositories;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using FullCRUDImplementationWithJquery.Core.UnitOfWorks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfwork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository) {
            
        }

        public BaseResponse<User> FindByUserNameAndPassword(string userName, string password) {
            try {
                User user= this._unitOfWork.Users.FindByUserNameAndPassword(userName, password);
                if (user != null) {
                    return new BaseResponse<User>(user);
                }
                return new BaseResponse<User>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception) {
                return new BaseResponse<User>(new ErrorMessageCode().ErrorCreated);
            }
        }
        /*
        public User Authenticate(string kullaniciAdi, string sifre)
        {
            var user = _users.SingleOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre);

            // Kullanici bulunamadıysa null döner.
            if (user == null)
                return null;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.KullaniciAdi.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.Sifre = null;

            return user;
        }
        */
    }
}
