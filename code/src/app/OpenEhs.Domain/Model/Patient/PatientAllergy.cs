namespace OpenEhs.Domain
{
    public class PatientAllergy : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual int Patient { get; set; }
        public virtual int Allergy { get; set; }

        #endregion
    }
}
