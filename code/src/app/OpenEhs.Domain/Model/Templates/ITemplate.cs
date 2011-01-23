namespace OpenEhs.Domain
{
    public interface ITemplate
    {
        int Id { get; }
        string Body { get; set; }
        bool IsActive { get; set; }
    }
}
