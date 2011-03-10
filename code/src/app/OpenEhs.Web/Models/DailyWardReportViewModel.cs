using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class DailyWardReportViewModel
    {
        public DailyWardReportViewModel()
        {
            Date = DateTime.Now;
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public IList<Location> Locations
        {
            get
            {
                var locations = new LocationRepository();
                return locations.GetAll();
            }
        }

    }
}
