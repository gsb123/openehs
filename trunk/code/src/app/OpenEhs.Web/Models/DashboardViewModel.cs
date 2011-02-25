using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class DashboardViewModel
    {
        private Patient _patient;
        private Staff _staff;

        [DisplayName("CheckIns")]
        public IList<PatientCheckIn> PatientCheckIns
        {
            get
            {
                return _patient.PatientCheckIns;
            }
            set
            {
                _patient.PatientCheckIns = value;
            }
        }

        public PatientCheckIn GetOpenCheckin
        {
            get
            {
                try
                {
                    var query = from checkin in PatientCheckIns
                                where checkin.CheckOutTime == DateTime.MinValue
                                select checkin;

                    return query.First<PatientCheckIn>();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public IList<Location> GetLocations
        {
            get
            {
                LocationRepository locations = new LocationRepository();
                return locations.GetAll();
            }
        }
    }
}