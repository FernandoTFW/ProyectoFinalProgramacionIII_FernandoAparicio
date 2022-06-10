using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOProgra.Modelo
{
    public class BaseModel
    {
        #region Properties
        public byte Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructor
        public BaseModel(byte status, DateTime registrationDate, DateTime lastUpdate)
        {
            Status = status;
            RegistrationDate = registrationDate;
            LastUpdate = lastUpdate;
        }

        public BaseModel()
        {
        }


        #endregion
    }
}
