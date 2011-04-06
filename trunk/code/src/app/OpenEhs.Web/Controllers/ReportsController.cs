using System.Web.Mvc;
using System;
using OpenEhs.Web.Models;
using System.Configuration;
using System.Data;

namespace OpenEhs.Web.Controllers
{
    [Authorize(Roles="Administrators, OPDAdministrators")]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserReport()
        {
            return View(new DataView());
        }

        public ActionResult UserReport(FormCollection collection)
        {
            string selectStatement = "SELECT  u.LastName, " +
                        "u.Firstname, " +
                        "COUNT(c.CheckinTime) " +
                        "FROM user u, patient p, patientcheckin c " +
                        "WHERE u.UserID = c.UserID AND c.PatientID = p.PatientID AND c.CheckinTime >= @date AND c.CheckinTime <= @date " +
                        "GROUP BY u.LastName, u.FirstName;";

            string ConnectionString = ConfigurationManager.ConnectionStrings["OpenEhs.ConnectionString"].ConnectionString;
            DateTime date = Convert.ToDateTime(collection["selectedDate"]);

            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
            string select = selectStatement;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", date);

            connection.Open();
            MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader();
            System.Data.DataTable tableReport = new System.Data.DataTable();
            tableReport.Load(reader);
            connection.Close();

            System.Data.DataView dv1 = new System.Data.DataView(tableReport);

            return View();
        }

        public ActionResult LocationReport()
        {
            return View();
        }
    }
}
