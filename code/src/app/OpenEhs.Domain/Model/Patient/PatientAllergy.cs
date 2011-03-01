namespace OpenEhs.Domain
{
    public class PatientAllergy : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual Patient Patient { get; set; }
        public virtual Allergy Allergy { get; set; }

        #endregion
    }
}
