using AbstractedORMLibrary.ORMCatalog;
using NPoco;
using NPoco.FluentMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractedORMLibrary
{
    
    public enum EDataAccessType
    {
        NPoco
        //Future properties like nhibernate, entityframework
    }

    public abstract class BaseResultEntity
    {


    }

    public class DBColumn<T> where T : BaseResultEntity
    {
        public string ColumnName { get; set; }
        public Expression<Func<T, object>> Column { get; set; }
    }

    public class DBMapping<T> where T : BaseResultEntity
    {
        public string TableName { get; set; }
        public string PrimaryColumn { get; set; }
        public List<DBColumn<T>> GenericColumns { get; set; }
    }

    public abstract class DataAccessProvider
    {
        public abstract IList<T> Select<T>(Expression<Func<T, bool>> whereExpression = null) where T : BaseResultEntity;
        public abstract bool DeleteByQuery<T>(Expression<Func<T, bool>> whereExpression) where T : BaseResultEntity;
        public abstract bool Delete(BaseResultEntity data);
        public abstract bool SaveOrUpdate(BaseResultEntity data);
        public abstract void BeginTransaction();
        public abstract void CompleteTransaction();
        public abstract void SetMapping<T>(DBMapping<T> mapping) where T : BaseResultEntity;
        public abstract void RegisterMappings();

    }
}
