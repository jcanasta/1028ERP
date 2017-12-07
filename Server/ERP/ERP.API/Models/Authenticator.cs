using ERP.Core.DAL.Entities;
using ERP.Core.Factories;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ERP.API.Models
{
    public class Authenticator
    {
        public LoginResponse Authenticate(SignInModel model)
        {
            try
            {
                var response = new LoginResponse();
                var repo = new RepositoryFactory().CreateRepository<User>();

                var user = repo.Get(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();

                if (user == null)
                {
                    response.Message = "Invalid username or password";
                    return response;
                }

                var id = Convert.ToInt32(user.MasterDataID);
                response.UserID = id;

                if (user.Type == User.UserType.Customer)
                {
                    var customerRepo = new RepositoryFactory().CreateRepository<Customer>();
                    var customer = customerRepo.Get(x => x.ID == id).FirstOrDefault();
                    response.Name = customer.Name;
                }
                else
                {
                    var empRepo = new RepositoryFactory().CreateRepository<Employee>();
                    var emp = empRepo.Get(x => x.ID == id).FirstOrDefault();
                    response.Name = $"{emp.FirstName} {emp.LastName}";
                }

                response.Token = CreateToken(user);
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateToken(User user)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = Math.Round((now.AddHours(12) - unixEpoch).TotalSeconds); //12 hours expiry

            //add claims in payload for now we will leave it blank
            var payload = new Dictionary<string, object>
            {
                { "exp", expiry },
                { "user", user }
            };

            var secret = ConfigurationManager.AppSettings["jwtSecret"];
            return encoder.Encode(payload, secret);
        }
    }
}