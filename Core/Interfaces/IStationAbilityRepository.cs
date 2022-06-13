using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataTransferObjects;
using Database.Entities;

namespace Core.Interfaces
{
    public interface IStationAbilityRepository
    {
        Task<StationAbility?> GetStationAbilityByStationIdAsync(Guid stationsId);
        Task<StationAbilityDto?> GetStationAbilityByNameAndStationIdAsync(string stationAbilityName, Guid stationId); 
        Task<StationAbilityDto> InsertStationAbilityAsync(StationAbilityDto stationAbilityDto);
    }
}
