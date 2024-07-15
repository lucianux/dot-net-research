using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationandAuthorization.Controllers;

public class AuthenticateController : BaseController
{
    #region Property
    /// <summary>
    /// Property Declaration
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private IConfiguration _config;

    #endregion

    #region Contructor Injector
    /// <summary>
    /// Constructor Injection to access all methods or simply DI(Dependency Injection)
    /// </summary>
    public AuthenticateController(IConfiguration config)
    {
        _config = config;
    }
    #endregion

    #region GenerateJWT
    /// <summary>
    /// Generate Json Web Token Method
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    private string GenerateJSONWebToken(LoginModel userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Le agrego unos Claims
        var myClaims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, "ID 129"),
            new Claim(ClaimTypes.Name, "Chuchu"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "Reader")
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Issuer"],
            claims: myClaims,
            expires: DateTime.Now.AddMinutes(1), // Expires in one minute
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion

    #region AuthenticateUser
    /// <summary>
    /// Hardcoded the User authentication
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    private async Task<LoginModel> AuthenticateUser(LoginModel login)
    {
        LoginModel user = null;

        //Validate the User Credentials    
        //Demo Purpose, I have Passed HardCoded User Information    
        if (login.UserName == "Jesus")
        {
            user = new LoginModel { UserName = "Jesus", Password = "123456" };
        }
        return user;
    }
    #endregion

    #region Login Validation
    /// <summary>
    /// Login Authenticaton using JWT Token Authentication
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login([FromBody] LoginModel data)
    {
        IActionResult response = Unauthorized();
        var user = await AuthenticateUser(data);
        if (data != null)
        {
            var tokenString = GenerateJSONWebToken(user);
            response = Ok(new { Token = tokenString , Message = "Success" });
        }
        return response;
    }
    #endregion

    #region Get
    /// <summary>
    /// Authorize the Method
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet(nameof(Get))]
    public async Task<IList<string>> Get()
    {
        JwtSecurityToken jwt;
        string message = "";
        string accessToken = await HttpContext.GetTokenAsync("access_token");
        bool validation;
        //validation = ValidateToken(accessToken, out jwt, out message);
        validation = true;

        return [ validation ? "Acceso exitoso" : "Acceso fallido",
            "Validando la fecha de expiración del token",
            "Hora actual: " + DateTime.Now.ToString(),
            "Message: " + message];
    }
    #endregion

    private bool ValidateToken(
        string token,
        out JwtSecurityToken jwt,
        out string errorMessage
        )
    {
        var validationParameters = GetValidationParameters();

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            jwt = (JwtSecurityToken)validatedToken;
            errorMessage = "";
            return true;
        } catch (SecurityTokenValidationException ex) {
            // Log the reason why the token is not valid
            jwt = null;
            errorMessage = ex.Message;
            return false;
        }
    }

    private TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = _config["Jwt:Issuer"],
            ValidAudience = _config["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])), // The same key as the one that generate the token
            ClockSkew = TimeSpan.Zero
        };
    }
}

#region JsonProperties
/// <summary>
/// Json Properties
/// </summary>
public class LoginModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
#endregion
