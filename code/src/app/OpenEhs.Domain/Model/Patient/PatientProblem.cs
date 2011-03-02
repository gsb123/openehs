namespace OpenEhs.Domain
{
    public class PatientProblem : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual Problem Problem { get; set; }
        public virtual Patient Patient { get; set; }

        #endregion
    }
}
