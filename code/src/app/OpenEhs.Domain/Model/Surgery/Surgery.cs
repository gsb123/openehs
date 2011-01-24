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

        public int Id {get; private set;}
        public string SurgeryType {get; set;}
        public int RoomNumber {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public string Comments {get; set;}
        public InPatient InPatientID {get; set;}

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
