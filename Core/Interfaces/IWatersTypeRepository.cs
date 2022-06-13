namespace Core.Interfaces;

public interface IWatersTypeRepository
{
    Task<Guid?> GetWatersTypeIdByIdentifierAsync(string identifier);
}