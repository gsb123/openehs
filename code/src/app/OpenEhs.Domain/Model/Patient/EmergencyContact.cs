/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class EmergencyContact // NOTE: Should we just call this class "Contact"?
    {
        #region Fields

        private int _id;
        private string _firstname;
        private string _lastname;
        private string _phonenumber;
        private Relationship _relationship;
        private Address _addressid;
        private Patient _patientid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }

        public Relationship Relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }

        public Address AddressID
        {
            get { return _addressid; }
            set { _addressid = value; }
        }

        public Patient PatientID
        {
            get { return _patientid; }
            set { _patientid = value; }
        }

        #endregion

        #region Constructor(s)

        public EmergencyContact(int id, string firstname, string lastname, string phonenumber, Relationship relationship, Address addressid, Patient patientid)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Relationship = relationship;
            AddressID = addressid;
            PatientID = patientid;
        }

        #endregion
    }
}
