using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IReservationRepository
    {
        ReservationDbModel CreateRecord(ReservationDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(ReservationDbModel record);
        ReservationDbModel GetRecord(int recordId);
        IEnumerable<ReservationDbModel> GetAllRecords(string filter);
        IEnumerable<ReservationDbModel> GetAllRecordsByCustomerId(int CustomerId);
    }
    


}
