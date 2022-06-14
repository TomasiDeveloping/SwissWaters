using Core.DataTransferObjects;

namespace Core.Interfaces;

public interface ICantonRepository
{
    Task<List<CantonDto>> GetCantonsAsync();
}