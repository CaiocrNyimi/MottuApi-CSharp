using Swashbuckle.AspNetCore.Filters;
using MottuApi.API.Dtos;

namespace MottuApi.API.Examples
{
    public class LoginRequestExample : IExamplesProvider<LoginRequestDto>
    {
        public LoginRequestDto GetExamples() => new LoginRequestDto
        {
            Username = "admin",
            Senha = "12345"
        };
    }
}