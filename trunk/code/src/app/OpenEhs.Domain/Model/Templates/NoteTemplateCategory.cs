using System.Collections.Generic;
namespace OpenEhs.Domain
{
    public class NoteTemplateCategory
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Template> Templates { get; set; }
        public virtual IList<Note> Notes { get; set; }
    }
}
