using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyRepository
    {
        PropertyDbModel CreateRecord(PropertyDbModel record);
        int DeleteRecord(int recordid);
        int UpdateRecord(PropertyDbModel record);
        PropertyDbModel GetRecord(int recordid);
        IEnumerable<PropertyDbModel> GetAllRecord(String filter);
        IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int PropertyOwnerId);
        




    }
}


