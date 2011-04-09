using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OpenEhs.Web.Models
{
    public class LocationReportViewModel
    {
        [Required(ErrorMessage = "A date is required for the report")]
        [DataType(DataType.Date)]
        [Display(Name = "Report Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SelectedDate { get; set; }

        public DataView Data { get; set; }

        public LocationReportViewModel(): this(DateTime.Now, null)
        {}

        public LocationReportViewModel(DateTime selectedDate, DataView data)
        {
            SelectedDate = selectedDate;
            Data = data;
        }
    }
}