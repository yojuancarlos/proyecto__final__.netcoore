using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class ReservationImplementationRepository : IReservationRepository
    {
        public ReservationDbModel CreateRecord(ReservationDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Reservation.Any(x => x.EnterDate.Equals(record.CheckIn)))
                    {
                        ReservationMapperRepository mapper = new ReservationMapperRepository();
                        Reservation dbRecord = mapper.MapperT2toT1(record);
                        db.Reservation.Add(dbRecord);
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

        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    Reservation record = db.Reservation.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Reservation.Remove(record);
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

        public IEnumerable<ReservationDbModel> GetAllRecords(string filter)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<ReservationDbModel> GetAllRecordsByCustomerId(int CustomerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.Reservation
                               where c.CustomerId == CustomerId
                               select c);
                ReservationMapperRepository mapper = new ReservationMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public ReservationDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Reservation.Find(recordId);

                ReservationMapperRepository mapper = new ReservationMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(ReservationDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    ReservationMapperRepository mapper = new ReservationMapperRepository();
                    Reservation dbRecord = mapper.MapperT2toT1(record);
                    db.Reservation.Attach(dbRecord);
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
