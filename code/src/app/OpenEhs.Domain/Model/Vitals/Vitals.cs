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

        public int Id {get; private set;}
        public VitalsType Type {get; set;}
        public float Height {get; set;}
        public float Weight {get; set;}
        public int HeartRate  {get; set;}
        public float Temperature  {get; set;}
        public BloodPressure BloodPressure {get; set;}
        public int RespiratoryRate  {get; set;}

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
