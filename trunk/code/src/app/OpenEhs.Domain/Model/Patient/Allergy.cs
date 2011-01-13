using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Allergy
    {
        #region Fields

        private int _id;
        private string _name;
        private string _medication;
        private Patient _patientid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Medication
        {
            get { return _medication; }
            set { _medication = value; }
        }

        public Patient PatientID
        {
            get { return _patientid; }
            set { _patientid = value; }
        }

        #endregion

        #region Constructor(s)

        public Allergy(int id, string name, string medication, Patient patientid)
        {
            Id = id;
            Name = name;
            Medication = medication;
            PatientID = patientid;
        }

        #endregion
    }
}
