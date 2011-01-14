using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Note
    {
        #region Fields

        private int _id;
        private string _title;
        private string _body;
        private DateTime _datecreated;
        private Staff _staffid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public DateTime DateCreated
        {
            get { return _datecreated; }
            set { _datecreated = value; }
        }

        private Staff StaffID
        {
            get { return _staffid; }
            set { _staffid = value; }
        }

        #endregion

        #region Constructor(s)

        public Note(int id, string title, string body, DateTime datecreated, Staff staffid)
        {
            Id = id;
            Title = title;
            Body = body;
            DateCreated = datecreated;
            StaffID = staffid;
        }

        #endregion
    }
}
