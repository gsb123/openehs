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
    public class Surgery
    {
        #region Fields

        private int _id;
        private string _surgerytype;
        private int _roomnumber;
        private DateTime _starttime;
        private DateTime _endtime;
        private string _comments;
        private InPatient _inpatientid;

        #endregion

        #region Properties

        public virtual int Id { get; private set; }
        public virtual string SurgeryType { get; set; }
        public virtual int RoomNumber { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string Comments { get; set; }
        public virtual InPatient InPatientID { get; set; }

        #endregion

        #region Constructor(s)

        public Surgery(int id, string surgerytype, int roomnumber, DateTime starttime, DateTime endtime, string comments, InPatient inpatientid)
        {
            Id = id;
            SurgeryType = surgerytype;
            RoomNumber = roomnumber;
            StartTime = starttime;
            EndTime = endtime;
            Comments = comments;
            InPatientID = inpatientid;
        }

        #endregion
    }
}
