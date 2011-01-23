namespace OpenEhs.Domain
{
    public class DiagnosisTemplate : ITemplate
    {
        public int Id { get; private set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
    }
}
