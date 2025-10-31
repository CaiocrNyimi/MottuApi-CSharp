using Swashbuckle.AspNetCore.Filters;
using MottuApi.API.Dtos;

namespace MottuApi.API.Examples
{
    public class PatioRequestExample : IExamplesProvider<PatioRequestDto>
    {
        public PatioRequestDto GetExamples() => new PatioRequestDto
        {
            Nome = "Pátio Central",
            Localizacao = "Rua das Motos, 123"
        };
    }
}