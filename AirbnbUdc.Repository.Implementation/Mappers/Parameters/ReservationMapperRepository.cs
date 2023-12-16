using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Mappers.Parameters
{
    public class ReservationMapperRepository : BaseMapperRepository<Reservation, ReservationDbModel>
    {
        public override ReservationDbModel MapperT1toT2(Reservation input)
        {
            CustomerMapperRepository customerMapper = new CustomerMapperRepository();
            PropertyMapperRepositoty propertyMapper = new PropertyMapperRepositoty();
            
            return new ReservationDbModel
            {
                Id = (int)input.Id,
                 CheckIn = input.EnterDate,
                 CheckOut = input.OutDate,
                Price = (int)input.Price,
                Customer = customerMapper.MapperT1toT2(input.Customer),
                Property = propertyMapper.MapperT1toT2(input.Property)
             
            };
            {
               
            };



        }

        public override IEnumerable<ReservationDbModel> MapperT1toT2(IEnumerable<Reservation> input)
        {
            IList<ReservationDbModel> list = new List<ReservationDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Reservation MapperT2toT1(ReservationDbModel input)
        {
            return new Reservation
            {
                Id = (int)input.Id,
                 EnterDate = input.CheckIn,
                 OutDate = input.CheckOut,
                Price = (int)input.Price
                
                //PropertyId = input.Propertyid,
                //CustomerId = (int)input.CustomerId

            };
        }

        public override IEnumerable<Reservation> MapperT2toT1(IEnumerable<ReservationDbModel> input)
        {
            IList<Reservation> list = new List<Reservation>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
    
    }

