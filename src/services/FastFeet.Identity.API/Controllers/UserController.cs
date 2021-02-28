using FastFeet.Identity.API.Models;
using FastFeet.Identity.API.Services;
using FastFeet.WebApi.Core.Controller;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastFeet.Identity.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : MainController
    {
        private readonly AuthenticationService _authenticationService;

        public UserController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Registrar(UsuarioRegistroVM viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = new IdentityUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, viewModel.Senha);
            if (result.Succeeded)
            {  
                var token = await _authenticationService.GerarJwt(viewModel.Email);
                return CustomResponse(token);
            }

            foreach (var item in result.Errors)
            {
                AdicionarErroProcessamento(item.Description);
            }

            return CustomResponse();
        }
    }
}
