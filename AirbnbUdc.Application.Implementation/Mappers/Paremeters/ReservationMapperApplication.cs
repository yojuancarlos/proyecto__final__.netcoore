using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Application.Implementation.Mappers.Paremeters
{
    public class ReservationMapperApplication : MapperBaseApplication<ReservationDbModel, ReservationDTO>
    {
        public override ReservationDTO MapperT1toT2(ReservationDbModel input)
        {

            CustomerMapperAplication customerMapper = new CustomerMapperAplication();
            return new ReservationDTO
            {
                Id = input.Id,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
                Price = input.Price,
                Customer = customerMapper.MapperT1toT2(input.Customer),
                
               
                

            };
        }

        public override IEnumerable<ReservationDTO> MapperT1toT2(IEnumerable<ReservationDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override ReservationDbModel MapperT2toT1(ReservationDTO input)
        {
            CustomerMapperAplication customerMapper = new CustomerMapperAplication();
            return new ReservationDbModel
            {
               
                Id = input.Id,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
                Price = input.Price,
                Customer = customerMapper.MapperT2toT1(input.Customer),

            };
        }

        public override IEnumerable<ReservationDbModel> MapperT2toT1(IEnumerable<ReservationDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
