namespace OpenEhs.Domain
{
    public class SurgeryStaff : IEntity
    {
        public virtual int Id { get; private set; }
        public virtual User Staff { get; set; }
        public virtual Surgery Surgery { get; set; }
        public virtual StaffRole Role { get; set; }
    }
}
