﻿using System.Collections.Generic;
using System.Linq;

namespace NzbDrone.Core.Datastore
{
    public interface IBasicRepository<TModel>
    {
        List<TModel> All();
        TModel Get(int rootFolderId);
        TModel Add(TModel rootFolder);
        void Delete(int rootFolderId);
    }

    public class BasicRepository<TModel> : IBasicRepository<TModel> where TModel : BaseRepositoryModel, new()
    {
        public BasicRepository(EloqueraDb eloqueraDb)
        {
            EloqueraDb = eloqueraDb;
        }

        protected EloqueraDb EloqueraDb { get; private set; }

        public List<TModel> All()
        {
            return EloqueraDb.AsQueryable<TModel>().ToList();
        }

        public TModel Get(int id)
        {
            return EloqueraDb.AsQueryable<TModel>().Single(c => c.Id == id);
        }

        public TModel Add(TModel model)
        {
            return EloqueraDb.Insert(model);
        }

        public void Delete(int id)
        {
            var itemToDelete = Get(id);
            EloqueraDb.Delete(itemToDelete);
        }
    }
}