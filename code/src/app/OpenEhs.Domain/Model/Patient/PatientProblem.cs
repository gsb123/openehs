namespace OpenEhs.Domain
{
    public class PatientProblem : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual int Problem { get; set; }
        public virtual int Patient { get; set; }

        #endregion
    }
}
