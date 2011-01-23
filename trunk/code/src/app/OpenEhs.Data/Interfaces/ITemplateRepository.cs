﻿/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System.Collections.Generic;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public interface ITemplateRepository : IRepository<ITemplate>
    {
        IList<ITemplate> GetAllSurgeryTemplates();
        IList<ITemplate> GetAllDiagnosisTemplates();
        IList<ITemplate> GetAllNoteTemplates();
        IList<ITemplate> GetAllReasonTemplates();
    }
}