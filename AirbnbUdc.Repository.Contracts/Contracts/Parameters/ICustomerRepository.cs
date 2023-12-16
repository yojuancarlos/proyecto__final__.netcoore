using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface ICustomerRepository
    {
        CustomerDbModel CreateRecord(CustomerDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CustomerDbModel record);
        CustomerDbModel GetRecord(int recordId);
        IEnumerable<CustomerDbModel> GetAllRecords(string filter);
    }




    
}
