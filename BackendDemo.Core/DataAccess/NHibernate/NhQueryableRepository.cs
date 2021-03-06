using BackendDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDemo.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()

    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => this.Entities;

        public IQueryable<T> Entities => _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>());
    }
}
