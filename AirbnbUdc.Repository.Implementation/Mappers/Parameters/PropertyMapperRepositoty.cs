using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Mappers.Parameters
{
    public class PropertyMapperRepositoty : BaseMapperRepository<Property, PropertyDbModel>
    {
        public override PropertyDbModel MapperT1toT2(Property input)
        {
            CityMapperRepository cityMapper = new CityMapperRepository();
            PropertyOwnerMapperRepository propertyOwnerMapper = new PropertyOwnerMapperRepository();
            return new PropertyDbModel
            {
                Id = (int)input.Id,
                PropertAddress = input.PropertyAddress,
                Price = (int)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService,
                City = cityMapper.MapperT1toT2(input.City),
                PropertyOwner = propertyOwnerMapper.MapperT1toT2(input.PropertyOwner)



            };


        }

        public override IEnumerable<PropertyDbModel> MapperT1toT2(IEnumerable<Property> input)
        {
            IList<PropertyDbModel> list = new List<PropertyDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Property MapperT2toT1(PropertyDbModel input)
        {
            return new Property
            {
                Id = (int)input.Id,
                PropertyAddress = input.PropertAddress,
                Price = (int)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService,
                CityId = input.City.Id,
                OwnerId = input.PropertyOwner.Id
               
            };
           
        }

        public override IEnumerable<Property> MapperT2toT1(IEnumerable<PropertyDbModel> input)
        {
            IList<Property> list = new List<Property>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
