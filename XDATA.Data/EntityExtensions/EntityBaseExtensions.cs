using System;
using System.Collections.Generic;
using System.Linq;
using XDATA.Data;

namespace XDATA
{
    public static class EntityBaseExtensions
    {
        public static T Get<T>(this IQueryable<T> query, Guid id) where T : EntityBase
        {
            return query.FirstOrDefault(x => x.UID == id);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, IEnumerable<Guid> ids) where T : EntityBase
        {
            return query.Where(x => ids.Contains(x.UID));
        }


        public static IQueryable<SimpleEntity> ToSimpleEntities<T>(this IQueryable<T> query)
            where T : EntityBase, ISimpleEntity
        {
            return from a in query
                   select new SimpleEntity()
                   {
                       UID = a.UID,
                       Name = a.Name
                   };
        }
    }
}
