using AirbnbUdc.Application.Implementation.Mappers.Paremeters;
using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
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
    public class CustomerImplementationApplication : ICustomerApplication
    {

        ICustomerRepository _CustomerRepository;

        public CustomerImplementationApplication()
        {
            this._CustomerRepository = new CustomerImplementationRepository();
        }
        public CustomerDTO CreateRecord(CustomerDTO record)
        {
            CustomerMapperAplication mapper = new CustomerMapperAplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            CustomerDbModel created = this._CustomerRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._CustomerRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<CustomerDTO> GetAllRecords(string filter)
        {
            CustomerMapperAplication mapper = new CustomerMapperAplication();
            IEnumerable<CustomerDbModel> records = this._CustomerRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public CustomerDTO GetRecord(int recordId)
        {
            CustomerMapperAplication mapper = new CustomerMapperAplication();
            CustomerDbModel record = this._CustomerRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(CustomerDTO record)
        {
            CustomerMapperAplication mapper = new CustomerMapperAplication();
            CustomerDbModel  mapped = mapper.MapperT2toT1(record);
            int updated = this._CustomerRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
