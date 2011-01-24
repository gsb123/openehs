using NHibernate;
using NHibernate.Cfg;

namespace OpenEhs.Data
{
    public class SessionProvider
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        public static Configuration Configuration
        {
            get
            {
                return null;
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                return null;
            }
        }
    }
}
