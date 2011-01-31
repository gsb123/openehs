using System;
using System.IO;
using System.Xml;
using NHibernate;
using NHibernate.Cfg;

namespace OpenEhs.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private const string DefaultHibernateConfig = "hibernate.cfg.xml";
        private static ISession _currentSession;
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new Configuration();
                    string hibernateConfig = DefaultHibernateConfig;

                    // If not rooted, assume path from base directory.
                    if (Path.IsPathRooted(hibernateConfig) == false)
                    {
                        hibernateConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hibernateConfig);
                    }

                    if (File.Exists(hibernateConfig))
                    {
                        _configuration.Configure(new XmlTextReader(hibernateConfig));
                    }
                }

                return _configuration;
            }
        }

        public ISession CurrentSession
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ISessionFactory SessionFactory
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        internal UnitOfWorkFactory()
        {
            
        }

        public IUnitOfWork Create()
        {
            ISession session = CreateSession();
            session.FlushMode = FlushMode.Commit;
            _currentSession = session;

            return new UnitOfWorkImplementor(this, session);
        }

        private ISession CreateSession()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}
