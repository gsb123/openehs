/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class SurgeryTemplate : ITemplate
    {
        public virtual int Id { get; private set; }
        public virtual string Body { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
