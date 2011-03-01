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
            generateAdmissionsReport();
        }

        private void generateAdmissionsReport()
        {
            string selectAdmissions = "SELECT l.Department AS 'Department', p.LastName AS 'Last Name', p.FirstName AS 'First Name', (YEAR(CURDATE())-YEAR(p.DateOfBirth))-(RIGHT(CURDATE(),5)<RIGHT(p.DateOfBirth,5)) AS Age, IF(p.Gender = 0, \"Male\", \"Female\") AS 'Gender' "+
                                        "FROM patient p, patientcheckin c, location l "+
                                        "WHERE p.PatientID = c.PatientID "+
                                            "AND c.LocationID = l.LocationID "+
                                            "AND DATE(c.CheckinTime) = @date";


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
    }
}