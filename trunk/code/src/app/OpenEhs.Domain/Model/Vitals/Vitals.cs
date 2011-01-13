using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Vitals
    {
        #region Fields

        private int _id;
        private VitalsType _type;
        private float _height;
        private float _weight;
        private int _heartrate;
        private float _temperature;
        private int _bpsystolic;
        private int _bpdiastolic;
        private int _respiratoryrate;

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
            get { return _heartrate; }
            set { _heartrate = value; }
        }

        public float Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public int BPSystolic
        {
            get { return _bpsystolic; }
            set { _bpsystolic = value; }
        }

        public int BPDiastolic
        {
            get { return _bpdiastolic; }
            set { _bpdiastolic = value; }
        }

        public int RespiratoryRate
        {
            get { return _respiratoryrate; }
            set { _respiratoryrate = value; }
        }

        #endregion

        #region Constructor(s)

        public Vitals(int id, VitalsType type, float height, float weight, int heartrate, float temperature, int bpsystolic, int bpdiastolic, int respiratoryrate)
        {
            Id = id;
            Type = type;
            Height = height;
            Weight = weight;
            HeartRate = heartrate;
            Temperature = temperature;
            BPSystolic = bpsystolic;
            BPDiastolic = bpdiastolic;
            RespiratoryRate = respiratoryrate;
        }

        #endregion
    }
}
