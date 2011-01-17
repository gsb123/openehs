/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Vitals
    {
        #region Fields

        private int _id;
        private VitalsType _type;
        private float _height;
        private float _weight;
        private int _heartRate;
        private float _temperature;
        private BloodPressure _bloodPressure;
        private int _respiratoryRate;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public VitalsType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int HeartRate
        {
            get { return _heartRate; }
            set { _heartRate = value; }
        }

        public float Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public BloodPressure BloodPressure
        {
            get
            {
                return _bloodPressure;
            }
            set 
            {
                _bloodPressure = value;
            }
        }

        public int RespiratoryRate
        {
            get { return _respiratoryRate; }
            set { _respiratoryRate = value; }
        }

        #endregion

        #region Constructor(s)

        public Vitals(int id, VitalsType type, float height, float weight, int heartRate, float temperature, int bpSystolic, int bpDiastolic, int respiratoryRate)
            : this(id, type, height, weight, heartRate, temperature, new BloodPressure(bpSystolic, bpDiastolic), respiratoryRate )
        {}

        public Vitals(int id, VitalsType type, float height, float weight, int heartRate, float temperature, BloodPressure bloodPressure, int respiratoryRate)
        {
            Id = id;
            Type = type;
            Height = height;
            Weight = weight;
            HeartRate = heartRate;
            Temperature = temperature;
            BloodPressure = bloodPressure;
            RespiratoryRate = respiratoryRate;
        }

        #endregion
    }
}
