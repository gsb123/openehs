using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class TemplateCategory
    {
        public virtual int Id { get; set; }
        public virtual string TemplateCategoryName { get; set; }
        public virtual string TemplateCategoryDescription { get; set; }
    }
}
