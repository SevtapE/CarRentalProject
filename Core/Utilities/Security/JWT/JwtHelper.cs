using Core.Entities.Concrete;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;
       

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions= Configuration.GetSection("TokenOptions").Get<TokenOptions>();
           
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey( _tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            
           
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwt);
            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token

            };
        }


        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            
            var jwt = new JwtSecurityToken(issuer: tokenOptions.Issuer, audience: tokenOptions.Audience, notBefore: DateTime.Now, expires: _accessTokenExpiration, claims: GetClaims(user,operationClaims), signingCredentials: signingCredentials);

            return jwt;
        }

        private IEnumerable<Claim> GetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name,$"{ user.FirstName} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var operationClaim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, operationClaim.Name));
            }
            

            return claims;
        }
    }
}
