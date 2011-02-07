using System.ComponentModel.DataAnnotations;

namespace OpenEhs.Web.Models
{
    #region Models

    public class CreatePatientModel {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }

    #endregion
}
