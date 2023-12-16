using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IReservationApplication
    {
        ReservationDTO CreateRecord(ReservationDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(ReservationDTO record);
        ReservationDTO GetRecord(int recordId);
        IEnumerable<ReservationDTO> GetAllRecords(string filter);
        IEnumerable<ReservationDTO> GetAllRecordsByCustomerId(int CustomerId);
        IEnumerable<ReservationDTO> GetAllRecordsByPropertyId(int PropertyId);

    }
}

