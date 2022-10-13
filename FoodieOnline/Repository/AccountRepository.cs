using FoodieOnline.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodieOnline.Repository
{
    
    public class AccountRepository : IAccountRepository
    {

        private readonly FoodieContext _context;

        public AccountRepository(FoodieContext context)
        {
            _context = context;
        }
        public async Task<LoginResponse> Login(LoginModel model)
        {
            try
            {
                var user = _context.Register.Where(x => x.Email == model.Email && x.Password == model.Password).Any();
                var fullName = _context.Register.SingleOrDefaultAsync(x => x.Email == model.Email).Result.FullName;
                if (user == true)
                {
                    return new LoginResponse
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = "Login Successfully",
                        registerModel = new RegisterModel { Email = model.Email, FullName = fullName },
                    };

                }
                else
                {
                    return new LoginResponse
                    {
                        IsSuccess=false,
                        StatusCode = 400,
                        Message = "Invalid UserName Or Password"
                    };

                }
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 400
                };
            }
          
        }

        public async Task<LoginResponse> Register(RegisterModel model)
        {

            try
            {
                var GetUserName=_context.Register.FirstOrDefaultAsync(x=>x.FullName == model.FullName).Result;
                if(GetUserName!=null)
                {
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = "User Name Is Allready Exist",
                        StatusCode = 403
                    };
                }
                var GetUserMail= _context.Register.FirstOrDefaultAsync(x=>x.Email == model.Email).Result;
                if(GetUserMail!=null)
                {
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = "Email Allready Exist",
                        StatusCode = 403
                    };
                }
               
                    RegisterModel Obj = new RegisterModel();
                    Obj.FullName = model.FullName;
                    Obj.Password = model.Password;
                    Obj.Email = model.Email;
                    Obj.Phone = model.Phone;
                    var Data = _context.Register.AddAsync(Obj);
                    await _context.SaveChangesAsync();
                    return new LoginResponse
                    {
                        IsSuccess = true,
                        Message = "New User Registered Successfully",
                        StatusCode = 200
                    };
                
             
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    IsSuccess=false,
                    Message =ex.Message,
                    StatusCode = 400
                };
            }
        }
    }
}
