using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationManager.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace JWTAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_Secret_Key = "G-KaPdSgVkYp3s6v9y/B?E(H+MbQeThWmZq4t7w!z%C&F)J@NcRfUjXn2r5u8x/A";
        private const int JWT_Token_Validty_Min = 20;

        // private readonly List<UserAccount> userAccounts;

        public JwtTokenHandler()
        {
            /*
            userAccounts = new List<UserAccount>(){
                new UserAccount(){Username="admin", Password="admin@123", Role="Admin"},
                new UserAccount(){Username="user", Password="user@123", Role="User"}
            };
            */
        }

        public AuthenticationResponse GenerateToken(AuthenticationRequest request, string role)
        {
            /*
            // check if request is null
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return null;
            }

            // If the user name and Password matches then generate the token
            // find the user which matches the credentials in userAccounts and set it to result
            var result = userAccounts.Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            */


            // start working on JWT token 

            // set the expiry time of the token
            var tokenExpiryTime = DateTime.Now.AddMinutes(JWT_Token_Validty_Min);
            // set the key to encrypt the token tokenKey is type of byte[]
            var tokenKey = Encoding.ASCII.GetBytes(JWT_Secret_Key);
            // the perpuse of claims is to sent some additional data 
            var claimsIdentity = new ClaimsIdentity(new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Name, request.Username),
                new Claim(ClaimTypes.Role, role)
            });
            // signingCredentials is to set the key and algorithm to encrypt the token
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
            );
            // set the token descriptor
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTime,
                SigningCredentials = signingCredentials
            };

            // create the token
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            // write the token
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            // generate the token for Response 
            return new AuthenticationResponse
            {
                Token = token,
                ExpiresIn = (int)tokenExpiryTime.Subtract(DateTime.Now).TotalSeconds,
                Username = request.Username,
            };
        }

    }
}

