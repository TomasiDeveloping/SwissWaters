using Core.Models;

namespace Core.Interfaces;

public interface ICantonStationRepository
{
    Task<bool> InsertCantonStationAsync(CantonStationRequest cantonStationRequest);
}