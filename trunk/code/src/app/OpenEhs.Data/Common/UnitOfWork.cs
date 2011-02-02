/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 1-Feb-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using NHibernate;

namespace OpenEhs.Data
{
    public static class UnitOfWork
    {
        #region Fields

        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static IUnitOfWork _innerUnitOfWork;

        #endregion


        #region Properties

        public static IUnitOfWork Current
        {
            get
            {
                if (_innerUnitOfWork == null)
                    throw new InvalidOperationException("You are not in a unit of work.");

                return _innerUnitOfWork;
            }
        }

        public static ISession CurrentSession
        {
            get
            {
                return _unitOfWorkFactory.CurrentSession;
            }
            internal set
            {
                _unitOfWorkFactory.CurrentSession = value;
            }
        }

        public static bool IsStarted
        {
            get
            {
                return _innerUnitOfWork != null;
            }
        }

        #endregion


        #region Methods

        public static IUnitOfWork Start()
        {
            if (_innerUnitOfWork != null)
                throw new InvalidOperationException("You cannot start more than one unit of work at a time.");

            _innerUnitOfWork = _unitOfWorkFactory.Create();
            return _innerUnitOfWork;
        }

        public static void DisposeUnitOfWork(UnitOfWorkImplementor adapter)
        {
            _innerUnitOfWork = null;
        }

        #endregion
    }
}
