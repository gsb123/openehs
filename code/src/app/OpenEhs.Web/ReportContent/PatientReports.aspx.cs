using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace OpenEhs.Web
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calendarStart_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = calendarStart.SelectedDate.Year.ToString() + "-" + calendarStart.SelectedDate.Month.ToString() + "-" + calendarStart.SelectedDate.Day.ToString();
        }

        protected void calendarEnd_SelectionChanged(object sender, EventArgs e)
        {
            txtEndState.Text = calendarEnd.SelectedDate.Year.ToString() + "-" + calendarEnd.SelectedDate.Month.ToString() + "-" + calendarEnd.SelectedDate.Day.ToString();
        }

        private string connectionString = "Server=127.0.0.1;Database=openehs_database;Uid=OpenEHS_admin;Pwd=password;";

        public string inpatientAdmissionsSelect = "SELECT COUNT(*) " +
                                    "FROM patient p, patientcheckin c " +
                                    "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1 " +
                                    "AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                    "AND p.Gender = @gender " +
                                    "AND p.PatientID = c.PatientID " +
                                    "AND c.PatientType = 1 " +
                                    "AND c.CheckinTime >= @startDate AND c.CheckinTime <= @endDate;";

        public string inpatientDischargesSelect = "SELECT COUNT(*) " +
                                    "FROM patient p, patientcheckin c " +
                                    "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1 " +
                                    "AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                    "AND p.Gender = @gender " +
                                    "AND p.PatientID = c.PatientID " +
                                    "AND c.CheckOutTime IS NOT NULL " +
                                    "AND c.PatientType = 1 " +
                                    "AND p.DateOfDeath = '0001-01-01 00:00:00' " +
                                    "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                    "AND c.CheckOutTime >= c.CheckinTime;";

        public string inpatientDeathSelect = "SELECT COUNT(*) " +
                                    "FROM patient p, patientcheckin c " +
                                    "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1 " +
                                    "AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                    "AND p.Gender = @gender " +
                                    "AND p.PatientID = c.PatientID " +
                                    "AND c.CheckOutTime IS NOT NULL " +
                                    "AND c.PatientType = 1 " +
                                    "AND p.DateOfDeath != '0001-01-01 00:00:00' " +
                                    "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                    "AND c.CheckOutTime >= c.CheckinTime;";

        public string inpatientAdmissionsTotals = "SELECT COUNT(*) "+
                                                    "FROM patient p, patientcheckin c "+
                                                    "WHERE p.Gender = @gender "+
                                                        "AND p.PatientID = c.PatientID "+
                                                        "AND c.PatientType = 1 "+
                                                        "AND c.CheckinTime >= @startDate AND c.CheckinTime <= @endDate";

        public string inpatientDischargeTotals = "SELECT COUNT(*) " +
                                                    "FROM patient p, patientcheckin c " +
                                                    "WHERE p.Gender = @gender " +
                                                        "AND p.PatientID = c.PatientID " +
                                                        "AND c.PatientType = 1 " +
                                                        "AND p.DateOfDeath = '0001-01-01 00:00:00' " +
                                                        "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                        "AND c.CheckOutTime >= c.CheckinTime;";

        public string inpatientDeathTotals = "SELECT COUNT(*) " +
                                                    "FROM patient p, patientcheckin c " +
                                                    "WHERE p.Gender = @gender " +
                                                        "AND p.PatientID = c.PatientID " +
                                                        "AND c.PatientType = 1 " +
                                                        "AND p.DateOfDeath != '0001-01-01 00:00:00' " +
                                                        "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate "+
                                                        "AND c.CheckOutTime >= c.CheckinTime;";

        public string outPatientOld = "SELECT c.PatientID, COUNT(c.PatientID) " +
                                        "FROM patient p, patientcheckin c " +
                                        "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1  " +
                                               " AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                                "AND p.Gender = @gender "+
                                                "AND c.PatientType = 0 " +
                                                "AND p.PatientID = c.PatientID " +
                                                "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                "AND CheckOutTime >= CheckinTime " +
                                                "GROUP BY c.PatientID " +
                                                "HAVING COUNT(c.PatientID) >= 2;";

        public string outPatientONew = "SELECT c.PatientID, COUNT(c.PatientID) " +
                                        "FROM patient p, patientcheckin c " +
                                        "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1  " +
                                               " AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                                "AND p.Gender = @gender " +
                                                "AND c.PatientType = 0 " +
                                                "AND p.PatientID = c.PatientID " +
                                                "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                "AND CheckOutTime >= CheckinTime " +
                                                "GROUP BY c.PatientID " +
                                                "HAVING COUNT(c.PatientID) < 2;";

        public string outPatientORowTotal = "SELECT c.PatientID, COUNT(c.PatientID) " +
                                            "FROM patient p, patientcheckin c " +
                                            "WHERE (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) >= @age1  " +
                                                   " AND (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) <= @age2 " +
                                                    "AND p.Gender = @gender " +
                                                    "AND c.PatientType = 0 " +
                                                    "AND p.PatientID = c.PatientID " +
                                                    "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                    "AND CheckOutTime >= CheckinTime " +
                                                    "GROUP BY c.PatientID;";

        //These three are for the totals row at the bottom of the Outpatient table
        public string outPatientNewTotal = "SELECT COUNT(*) " +
                                            "FROM ( " +
                                            "SELECT c.PatientID, COUNT(c.PatientID) " +
                                            "FROM patient p, patientcheckin c " +
                                            "WHERE c.PatientType = 0 " +
                                                    "AND p.Gender = @gender " +
                                                    "AND p.PatientID = c.PatientID " +
                                                    "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                    "AND CheckOutTime >= CheckinTime " +
                                                    "GROUP BY c.PatientID " +
                                                    "HAVING COUNT(c.PatientID) < 2) as t;";

        public string outPatientOldTotal = "SELECT COUNT(*) " +
                                            "FROM ( " +
                                            "SELECT c.PatientID, COUNT(c.PatientID) " +
                                            "FROM patient p, patientcheckin c " +
                                            "WHERE c.PatientType = 0 " +
                                                    "AND p.Gender = @gender " +
                                                    "AND p.PatientID = c.PatientID " +
                                                    "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                    "AND CheckOutTime >= CheckinTime " +
                                                    "GROUP BY c.PatientID " +
                                                    "HAVING COUNT(c.PatientID) >= 2) as t;";

        public string outPatientTotalTotal = "SELECT COUNT(c.PatientID) " +
                                                "FROM patient p, patientcheckin c " +
                                                "WHERE c.PatientType = 0 " +
                                                        "AND p.Gender = @gender " +
                                                        "AND p.PatientID = c.PatientID " +
                                                        "AND c.CheckOutTime >= @startDate AND c.CheckOutTime <= @endDate " +
                                                        "AND CheckOutTime >= CheckinTime;";



        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //INPATIENT REPORT
                inpatientLbl1.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                inpatientLbl8.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                inpatientLbl2.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                inpatientLbl9.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                inpatientLbl3.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                inpatientLbl10.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                inpatientLbl4.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                inpatientLbl11.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                inpatientLbl5.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                inpatientLbl12.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                inpatientLbl6.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                inpatientLbl13.Text = inpatientAdmissions(inpatientAdmissionsSelect, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                inpatientLbl15.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                inpatientLbl22.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                inpatientLbl16.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                inpatientLbl23.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                inpatientLbl17.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                inpatientLbl24.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                inpatientLbl18.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                inpatientLbl25.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                inpatientLbl19.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                inpatientLbl26.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                inpatientLbl20.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                inpatientLbl27.Text = inpatientAdmissions(inpatientDischargesSelect, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                inpatientLbl29.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                inpatientLbl36.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                inpatientLbl30.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                inpatientLbl37.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                inpatientLbl31.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                inpatientLbl38.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                inpatientLbl32.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                inpatientLbl39.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                inpatientLbl33.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                inpatientLbl40.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                inpatientLbl34.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                inpatientLbl41.Text = inpatientAdmissions(inpatientDeathSelect, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                inpatientLbl7.Text = inpatientAdmissions(inpatientAdmissionsTotals, txtStartDate.Text, txtEndState.Text, "Male");
                inpatientLbl14.Text = inpatientAdmissions(inpatientAdmissionsTotals, txtStartDate.Text, txtEndState.Text, "Female");

                inpatientLbl21.Text = inpatientAdmissions(inpatientDischargeTotals, txtStartDate.Text, txtEndState.Text, "Male");
                inpatientLbl28.Text = inpatientAdmissions(inpatientDischargeTotals, txtStartDate.Text, txtEndState.Text, "Female");

                inpatientLbl35.Text = inpatientAdmissions(inpatientDeathTotals, txtStartDate.Text, txtEndState.Text, "Male");
                inpatientLbl42.Text = inpatientAdmissions(inpatientDeathTotals, txtStartDate.Text, txtEndState.Text, "Female");

                //OUTPATIENT REPORT
                outpatientLbl1.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                outpatientLbl8.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                outpatientLbl2.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                outpatientLbl9.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                outpatientLbl3.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                outpatientLbl10.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                outpatientLbl4.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                outpatientLbl11.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                outpatientLbl5.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                outpatientLbl12.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                outpatientLbl6.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                outpatientLbl13.Text = outpatientAdmissions(outPatientONew, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                outpatientLbl15.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                outpatientLbl22.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                outpatientLbl16.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                outpatientLbl23.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                outpatientLbl17.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                outpatientLbl24.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                outpatientLbl18.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                outpatientLbl25.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                outpatientLbl19.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                outpatientLbl26.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                outpatientLbl20.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                outpatientLbl27.Text = outpatientAdmissions(outPatientOld, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                outpatientLbl29.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "0", "0.9999999");
                outpatientLbl36.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "0", "0.9999999");
                outpatientLbl30.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "1", "4");
                outpatientLbl37.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "1", "4");
                outpatientLbl31.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "5", "14");
                outpatientLbl38.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "5", "14");
                outpatientLbl32.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "15", "44");
                outpatientLbl39.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "15", "44");
                outpatientLbl33.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "45", "59");
                outpatientLbl40.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "45", "59");
                outpatientLbl34.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Male", "60", "1000");
                outpatientLbl41.Text = outpatientAdmissions(outPatientORowTotal, txtStartDate.Text, txtEndState.Text, "Female", "60", "1000");

                outpatientLbl7.Text = outpatientAdmissions(outPatientNewTotal, txtStartDate.Text, txtEndState.Text, "Male");
                outpatientLbl14.Text = outpatientAdmissions(outPatientNewTotal, txtStartDate.Text, txtEndState.Text, "Female");

                outpatientLbl21.Text = outpatientAdmissions(outPatientOldTotal, txtStartDate.Text, txtEndState.Text, "Male");
                outpatientLbl28.Text = outpatientAdmissions(outPatientOldTotal, txtStartDate.Text, txtEndState.Text, "Female");

                outpatientLbl35.Text = outpatientAdmissions(outPatientTotalTotal, txtStartDate.Text, txtEndState.Text, "Male");
                outpatientLbl42.Text = outpatientAdmissions(outPatientTotalTotal, txtStartDate.Text, txtEndState.Text, "Female");
            }
            catch (Exception message)
            {
                lblError.Text = message.ToString();
            }
        }

        private string inpatientAdmissions(string selectStatement ,string startDate, string endDate, string gender, string age1, string age2)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
            command.Parameters.AddWithValue("gender", gender);
            command.Parameters.AddWithValue("age1", age1);
            command.Parameters.AddWithValue("age2", age2);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable tableReport = new DataTable();
            tableReport.Load(reader);
            connection.Close();
            DataView dv1 = new DataView(tableReport);

            if (dv1.Count > 0)
                return dv1[0][0].ToString();
            else
                return "0";
        }

        private string inpatientAdmissions(string selectStatement, string startDate, string endDate, string gender)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
            command.Parameters.AddWithValue("gender", gender);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable tableReport = new DataTable();
            tableReport.Load(reader);
            connection.Close();
            DataView dv1 = new DataView(tableReport);

            if (dv1.Count > 0)
                return dv1[0][0].ToString();
            else
                return "0";
        }

        private string outpatientAdmissions(string selectStatement, string startDate, string endDate, string gender, string age1, string age2)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
            command.Parameters.AddWithValue("gender", gender);
            command.Parameters.AddWithValue("age1", age1);
            command.Parameters.AddWithValue("age2", age2);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable tableReport = new DataTable();
            tableReport.Load(reader);
            connection.Close();
            DataView dv1 = new DataView(tableReport);

            return dv1.Count.ToString();
        }

        private string outpatientAdmissions(string selectStatement, string startDate, string endDate, string gender)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
            command.Parameters.AddWithValue("gender", gender);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable tableReport = new DataTable();
            tableReport.Load(reader);
            connection.Close();
            DataView dv1 = new DataView(tableReport);

            if (dv1.Count > 0)
                return dv1[0][0].ToString();
            else
                return "0";
        }
    }
}