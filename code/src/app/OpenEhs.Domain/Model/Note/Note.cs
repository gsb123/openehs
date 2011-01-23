/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Note
    {
        #region Properties

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        private Staff Author { get; set; }

        #endregion


        #region Constructor(s)

        public Note(int id, string title, string body, DateTime datecreated, Staff author)
        {
            Id = id;
            Title = title;
            Body = body;
            DateCreated = datecreated;
            Author = author;
        }

        #endregion
    }
}
