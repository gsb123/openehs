/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 26-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Template
    {
        public virtual int Id { get; private set; }
        public virtual string Body { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual TemplateCategory Category { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
