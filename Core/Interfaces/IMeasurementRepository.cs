using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataTransferObjects;
using Database.Entities;

namespace Core.Interfaces
{
    public interface IMeasurementRepository
    {
        Task<MeasurementDto?> GetLatestMeasurementByStationAbilityIdAsync(Guid stationAbilityId);
        Task<MeasurementDto?> GetMeasurementByIdAsync(Guid measurementId);
        Task<MeasurementDto?> GetLatestStationAbilityValueAsync(Guid stationAbilityId);
        Task<MeasurementDto> InsertMeasurementAsync(MeasurementDto measurementDto);
    }
}
