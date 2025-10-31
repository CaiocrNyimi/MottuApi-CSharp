using MottuApi.API.Dtos;

namespace MottuApi.API.Services.Interfaces
{
    public interface IEntregaMlService
    {
        float PreverTempoEntrega(EntregaRequestDto request);
        EntregaResponseDto PreverTempoEntregaDto(EntregaRequestDto request);
    }
}