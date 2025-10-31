using Swashbuckle.AspNetCore.Filters;
using MottuApi.API.Dtos;

namespace MottuApi.API.Examples
{
    public class RegisterRequestExample : IExamplesProvider<RegisterRequestDto>
    {
        public RegisterRequestDto GetExamples() => new RegisterRequestDto
        {
            Username = "admin",
            Senha = "12345"
        };
    }
}