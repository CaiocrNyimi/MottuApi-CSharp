using Xunit;
using Microsoft.EntityFrameworkCore;
using MottuApi.API.Data;
using MottuApi.API.Services.Implementations;
using MottuApi.API.Dtos;

namespace MottuApi.Tests.Services
{
    public class PatioServiceTests
    {
        [Fact]
        public async Task CreateAsync_DeveCriarPatio()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("PatioDb")
                .Options;

            using var context = new AppDbContext(options);
            var service = new PatioService(context);

            var dto = new PatioRequestDto { Nome = "Central", Localizacao = "Rua A" };
            var result = await service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("Central", result.Nome);
        }
    }
}