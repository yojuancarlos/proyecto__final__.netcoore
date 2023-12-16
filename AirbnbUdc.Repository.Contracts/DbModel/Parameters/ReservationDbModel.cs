using System;

namespace AirbnbUdc.Repository.Contracts.DbModel.Parameters
{
    public class ReservationDbModel
    {

        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }


        public PropertyDbModel Property { get; set; }
        public CustomerDbModel Customer { get; set; }

    }
}



