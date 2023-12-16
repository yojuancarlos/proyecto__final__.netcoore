using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class PropertyMapperGUI : MapperBaseGUI<PropertyDTO, PropertyModel>
    {
        public override PropertyModel MapperT1toT2(PropertyDTO input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI PropertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new PropertyModel
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
                City = cityMapper.MapperT1toT2(input.City),
                PropertyOwner = PropertyOwnerMapper.MapperT1toT2(input.PropertyOwner)
            };
        }

        public override IEnumerable<PropertyModel> MapperT1toT2(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyDTO MapperT2toT1(PropertyModel input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI PropertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new PropertyDTO
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
                City = cityMapper.MapperT2toT1(input.City),
                PropertyOwner = PropertyOwnerMapper.MapperT2toT1(input.PropertyOwner)
            };
        }

        CountryMapperGUI countryMapper = new CountryMapperGUI();

           

    public override IEnumerable<PropertyDTO> MapperT2toT1(IEnumerable<PropertyModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}