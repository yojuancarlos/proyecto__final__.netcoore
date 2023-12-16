using AirbnbUdc.Application.Implementation.Mappers.Paremeters;
using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Application.Implementation.Implementation.Parameters
{
    public class PropertyImplementationApplication : IPropertyApplication
    {
        IPropertyRepository _PropertyRepository;

        public PropertyImplementationApplication()
        {
            this._PropertyRepository = new PropertyImplementationRepository();
        }

        public PropertyDTO CreateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            PropertyDbModel created = this._PropertyRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._PropertyRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyDTO> GetAllRecords(string filter)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._PropertyRepository.GetAllRecord(filter);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._PropertyRepository.GetAllRecordsByCityId(cityId);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(int PropertyOwnerId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._PropertyRepository.GetAllRecordsByPropertyOwnerId(PropertyOwnerId);
            return mapper.MapperT1toT2(records);
        }

        public PropertyDTO GetRecord(int recordId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel record = this._PropertyRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._PropertyRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
