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

namespace OpenEhs.Web.ReportContent
{
    public partial class DailyReports : System.Web.UI.Page
    {
        private string connectionString = "Server=127.0.0.1;Database=openehs_database;Uid=OpenEHS_admin;Pwd=password;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                generateAdmissionsReport();
                generateRemainPreviousDay();
                generateTotalAdmissions();
                generateTotalDischarges();
                generateTotalDeaths();
                genereateRemainedAtMidnight();
                generateDischargesList();
                generateDeathsList();
                lblError.Text = "";
            }
            catch(Exception message)
            {
                lblError.Text = message.ToString();
            }
        }

        protected void calendarDate_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = calendarDate.SelectedDate.Year.ToString() + "-" + calendarDate.SelectedDate.Month.ToString() + "-" + calendarDate.SelectedDate.Day.ToString();
        }

        private void generateAdmissionsReport()
        {
            string selectAdmissions = "SELECT l.Department AS 'Department', p.LastName AS 'Last Name', p.FirstName AS 'First Name', (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) AS Age, IF(p.Gender = 0, \"Male\", \"Female\") AS 'Gender' "+
                                        "FROM patient p, patientcheckin c, location l "+
                                        "WHERE p.PatientID = c.PatientID "+
                                            "AND c.LocationID = l.LocationID "+
                                            "AND DATE(c.CheckinTime) = @date;";


            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectAdmissions;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", txtDate.Text);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            gvAdmissions.DataSource = reader;
            gvAdmissions.DataBind();
            
            connection.Close();
        }

        private void generateRemainPreviousDay()
        {
            string select = "SELECT COUNT(*) "+
                                "FROM patientcheckin "+
                                "WHERE CheckOutTime IS NULL "+
                                    "AND DATE(CheckInTime) < @date";
            lblPrevDay.Text = summaryQuery(select, txtDate.Text);
        }

        private void generateTotalAdmissions()
        {
            string select = "SELECT COUNT(*) "+
                                "FROM patientcheckin "+
                                "WHERE DATE(CheckinTime) = @date";
            lblTotalAdmission.Text = summaryQuery(select, txtDate.Text);
        }

        private void generateTotalDischarges()
        {
            string select = "SELECT COUNT(*) "+
                                "FROM patientcheckin "+
                                "WHERE DATE(CheckOutTime) = @date";
            lblTotalDischarges.Text = summaryQuery(select, txtDate.Text);
        }

        private void generateTotalDeaths()
        {
            string select = "SELECT COUNT(*) " +
                                "FROM patientcheckin c, patient p "+
                                "WHERE p.PatientID = c.PatientID " +
                                "AND DATE(p.DateOfDeath) = @date";
            lblTotalDeaths.Text = summaryQuery(select, txtDate.Text);
        }

        private void genereateRemainedAtMidnight()
        {
            string select = "SELECT COUNT(*) "+
                                "FROM patientcheckin "+
                                "WHERE CheckOutTime IS NULL " +
                                    "AND DATE(CheckInTime) < DATE(@date)";
            string date = txtDate.Text + " 23:59:59";
            lblTotalAtMidnight.Text = summaryQuery(select, date);
        }



        private void generateDischargesList()
        {
            string selectDischarges = "SELECT l.Department AS 'Department', p.LastName AS 'Last Name', p.FirstName AS 'First Name', (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) AS Age, IF(p.Gender = 0, \"Male\", \"Female\") AS 'Gender' "+
                                    "FROM patient p, patientcheckin c, location l "+
                                    "WHERE p.PatientID = c.PatientID "+
                                        "AND c.LocationID = l.LocationID "+
                                        "AND DATE(c.CheckOutTime) = @date;";


            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectDischarges;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", txtDate.Text);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            gvDischarge.DataSource = reader;
            gvDischarge.DataBind();

            connection.Close();
        }

        private void generateDeathsList()
        {
            string selectDeaths = "SELECT l.Department AS 'Department', p.LastName AS 'Last Name', p.FirstName AS 'First Name', (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) AS Age, IF(p.Gender = 0, \"Male\", \"Female\") AS 'Gender' "+
                                    "FROM patient p, patientcheckin c, location l "+
                                    "WHERE p.PatientID = c.PatientID "+
                                        "AND c.LocationID = l.LocationID "+
                                        "AND DATE(p.DateOfDeath) = @date;";


            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectDeaths;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", txtDate.Text);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            gvDeaths.DataSource = reader;
            gvDeaths.DataBind();

            connection.Close();
        }

        private string summaryQuery(string selectStatement, string date)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", date);
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