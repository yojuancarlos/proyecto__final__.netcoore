using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using DocuSign.eSign.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class PropertyImplementationRepository : IPropertyRepository
    {
        public PropertyDbModel CreateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Property.Any(x => x.PropertyAddress.Equals(record.PropertAddress)))
                    {
                        PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                        Property dbRecord = mapper.MapperT2toT1(record);
                        db.Property.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = (int)dbRecord.Id;
                    }
                }
            }

            catch (System.Exception e)
            {
                throw e;
            }
                return record;
        
        }
    
public int DeleteRecord(int recordid)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    Property record = db.Property.FirstOrDefault(x => x.Id == recordid);
                    if (record != null)
                    {
                        db.Property.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                // porque se tiene como llave foránea en otra tabla
                throw e;
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecord(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.Property
                    where c.PropertyAddress.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.City.Where(x => x.CityName.Contains(filter));

                PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.Property
                               where c.CityId == cityId
                               select c);
                PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int PropertyOwnerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.Property
                               where c.OwnerId == PropertyOwnerId
                               select c);
                PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                return mapper.MapperT1toT2(records);
            }

        }

        public PropertyDbModel GetRecord(int recordid)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Property.Find(recordid);

                PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyMapperRepositoty mapper = new PropertyMapperRepositoty();
                    Property dbRecord = mapper.MapperT2toT1(record);
                    db.Property.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
