using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class PropertyOwnerImplementationRepository : IPropertyOwnerRepository
    {
        public PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.PropertyOwner.Any(x => x.FamilyName.Equals(record.FirstName)))
                    {
                        PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                        PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                        db.PropertyOwner.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = (int)dbRecord.Id;

                    }

                }

            }
            catch (Exception e)
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
                    PropertyOwner record = db.PropertyOwner.FirstOrDefault(x => x.Id == recordid);
                    if (record != null)
                    {
                        db.PropertyOwner.Remove(record);
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

        public IEnumerable<PropertyOwnerDbModel> GetAllRecord(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.PropertyOwner
                    where c.FirstName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));

                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyOwnerDbModel GetRecord(int recordid)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyOwner.Find(recordid);

                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                    PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                    db.PropertyOwner.Attach(dbRecord);
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
        