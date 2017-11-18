using System;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data;
using System.Data.SqlClient;
using DAL.ManageDocument.DatabaseSpecific;
using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.HelperClasses;

namespace DocumentManage
{
    public class DataAccessAdapterManagerBase
    {
        private static string _customConnectString;
        public static string ConnectString
        {
            get
            {
                return _customConnectString;
            }
        }
        public static void SetCustomConnectString(string connectString)
        {
            _customConnectString = connectString;
        }
        public static DataAccessAdapter CreateAdapter()
        {
            if (string.IsNullOrEmpty(_customConnectString)) return new DataAccessAdapter();
            return new DataAccessAdapter(_customConnectString);
        }
        public static int InsUpdates(EntityCollection cols)
        {
            using (DataAccessAdapter adapter = CreateAdapter())
            {
                return adapter.SaveEntityCollection(cols, true, false);
            }
        }
    }

    public class GenericEntityManagerBase<TEntity> where TEntity : CommonEntityBase
    {
        public static TEntity SelectOne(int id)
        {
            TEntity result = null;
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                TEntity _resultEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { id });
                if (adapter.FetchEntity(_resultEntity))
                {
                    result = _resultEntity;
                }
            }
            return result;
        }
        public static TEntity SelectOne(Guid id)
        {
            TEntity result = null;
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                TEntity _resultEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { id });
                if (adapter.FetchEntity(_resultEntity))
                {
                    result = _resultEntity;
                }
            }
            return result;
        }
        public static bool DeleteById(int id)
        {
            TEntity _entity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { id });
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.DeleteEntity(_entity);
            }
        }
        public static bool DeleteById(Guid id)
        {
            TEntity _entity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { id });
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.DeleteEntity(_entity);
            }
        }
        public static int DeleteByCondition(IRelationPredicateBucket filter)
        {
            int toReturn = 0;
            TEntity _entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            IEntityCore _entityCore = (IEntityCore)_entity;
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                toReturn = adapter.DeleteEntitiesDirectly(_entityCore.LLBLGenProEntityName, filter);
            }
            return toReturn;
        }
        public static bool InsUpdate(TEntity entity2Update)
        {
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.SaveEntity(entity2Update, true);
            }
        }
        public static int InsUpdateCollection(EntityCollection ecEntity)
        {
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.SaveEntityCollection(ecEntity, false, false);
            }
        }
        public static bool InsUpdate(TEntity entity2Update, bool refetch, bool recurse)
        {
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.SaveEntity(entity2Update, refetch, recurse);
            }
        }
        public static int Update(IEntity2 entity, IRelationPredicateBucket filter)
        {
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.UpdateEntitiesDirectly(entity, filter);
            }
        }
    }

    public class GenericEntityColManagerBase<TEntityFactory> where TEntityFactory : IEntityFactory2, new()
    {
        public static EntityCollection SelectAll(int iTop, ISortExpression sorter, IRelationPredicateBucket filter)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, iTop, sorter);
            }
            return ec;
        }

        public static EntityCollection SelectAll(int iTop, ISortExpression sorter, IRelationPredicateBucket filter, IncludeFieldsList includeFields)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, null, includeFields);
            }
            return ec;
        }

        public static EntityCollection SelectAll(int iTop, ISortExpression sorter, EntityField2 fieldStatus, IRelationPredicateBucket filter)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                adapter.FetchEntityCollection(ec, filter, iTop, sorter);
            }
            return ec;
        }
        public static EntityCollection SelectAllWFK(int iTop, ISortExpression sorter, IRelationPredicateBucket filter, IPrefetchPath2 paths)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, paths);
            }
            return ec;
        }
        public static EntityCollection SelectAllWFK(int iTop, ISortExpression sorter, EntityField2 fieldStatus, IRelationPredicateBucket filter, IPrefetchPath2 paths)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, paths);
            }
            return ec;
        }

        public static EntityCollection SelectAllWPaging(int iTop, ISortExpression sorter, IRelationPredicateBucket filter, int pageNumber, int pageSize)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, null, pageNumber, pageSize);
            }
            return ec;
        }
        public static EntityCollection SelectAllWPaging(int iTop, ISortExpression sorter, EntityField2 fieldStatus, IRelationPredicateBucket filter, int pageNumber, int pageSize)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, null, pageNumber, pageSize);
            }
            return ec;
        }

        public static EntityCollection SelectAllWFKAPaging(int iTop, ISortExpression sorter, IRelationPredicateBucket filter, IPrefetchPath2 paths, int pageNumber, int pageSize)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, paths, pageNumber, pageSize);
            }
            return ec;
        }
        public static EntityCollection SelectAllWFKAPaging(int iTop, ISortExpression sorter, EntityField2 fieldStatus, IRelationPredicateBucket filter, IPrefetchPath2 paths, int pageNumber, int pageSize)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                adapter.FetchEntityCollection(ec, filter, iTop, sorter, paths, pageNumber, pageSize);
            }
            return ec;
        }

        public static EntityCollection SelectByField(EntityField2 fieldColumn, object fkValue, EntityField2 fieldStatus)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(fieldColumn == fkValue);
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                adapter.FetchEntityCollection(ec, filter, 0, null);
            }
            return ec;
        }
        public static EntityCollection SelectByField(EntityField2 fieldColumn, object fkValue)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(fieldColumn == fkValue);
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchEntityCollection(ec, filter, 0, null);
            }
            return ec;
        }

        public static DataTable SelectAllRDT(int iTop, ISortExpression sorter, IRelationPredicateBucket filter)
        {
            DataTable toReturn = new DataTable();
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                adapter.FetchTypedList(ec.EntityFactoryToUse.CreateFields(), toReturn, filter, iTop, sorter, false);
            }
            return toReturn;
        }

        public static int GetDbCount(IRelationPredicateBucket filter, EntityField2 fieldStatus)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                filter.PredicateExpression.Add(fieldStatus == true);
                return adapter.GetDbCount(ec, filter);
            }
        }

        public static int GetDbCount(IRelationPredicateBucket filter)
        {
            EntityCollection ec = new EntityCollection(new TEntityFactory());
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.GetDbCount(ec, filter);
            }
        }

        public static object GetSum(IEntityField2 field, IRelationPredicateBucket filter)
        {
            using (DataAccessAdapter adapter = DataAccessAdapterManagerBase.CreateAdapter())
            {
                return adapter.GetScalar(field, null, AggregateFunction.Sum, filter.PredicateExpression, null, filter.Relations);
            }
        }
    }

    public class DataAccessAdapterFactory
    {
        public static DataTable ExcuteSelect(string SelectCommand)
        {
            try
            {
                SqlConnection con = new SqlConnection(DataAccessAdapterManagerBase.ConnectString);
                con.Open();
                SqlCommand command = new SqlCommand(SelectCommand, con);
                command.CommandTimeout = 6000000;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable toReturn = new DataTable();
                adapter.Fill(toReturn);
                con.Close();
                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
