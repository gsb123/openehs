using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using OpenEhs.Data.Common;
using OpenEhs.Domain;
using MySql.Data.MySqlClient;
using System.Data;

namespace OpenEhs.Data.Repositories
{
    class UserReportRepository
    {
        private MySqlConnection _connection;
        private string ConnectionString = "Server=127.0.0.1;Database=openehs_database;Uid=OpenEHS_admin;Pwd=password;";
        
        private string selectStatement = "SELECT  u.LastName, "+
                                            "u.Firstname, "+
                                            "COUNT(c.CheckinTime) "+
                                            "FROM user u, patient p, patientcheckin c "+
                                            "WHERE u.UserID = c.UserID AND c.PatientID = p.PatientID AND c.CheckinTime >= '2011-03-27 00:00:00' AND c.CheckinTime <= '2011-03-27 23:59:59' " +
                                            "GROUP BY u.LastName, u.FirstName;";

        public UserReportRepository()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        public DataView GetReport(DateTime date)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            string select = selectStatement;
            MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("date", date);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable tableReport = new DataTable();
            tableReport.Load(reader);
            connection.Close();
            DataView dv1 = new DataView(tableReport);

            return dv1;
        }
    }
}
