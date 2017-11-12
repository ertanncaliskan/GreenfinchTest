using NPoco;
using NPoco.FluentMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractedORMLibrary.ORMCatalog
{
    public class NPocoDataAccessProvider : DataAccessProvider
    {
        private Mappings _map { get; set; }
        public Database db { get; set; }

        public NPocoDataAccessProvider(Database db)
        {
            db.CommandTimeout = int.MaxValue;
            this.db = db;
        }


        public override void BeginTransaction()
        {
            db.BeginTransaction();
        }
        public override void CompleteTransaction()
        {
            db.CompleteTransaction();
        }

        public override IList<T> Select<T>(Expression<Func<T, bool>> whereExpression = null)
        {
            if (whereExpression != null)
                return db.Query<T>().Where(whereExpression).ToList();
            return db.Query<T>().ToList();
        }

        public override bool DeleteByQuery<T>(Expression<Func<T, bool>> whereExpression)
        {
            try
            {
                var dataset = db.Query<T>().Where(whereExpression).ToList();
                foreach (var data in dataset)
                {
                    db.Delete(data);
                }
            }
            catch (Exception ex)
            {
                //todo: logging for exception
                return false;
            }
            return true;
        }

        public override bool Delete(BaseResultEntity data)
        {

            try
            {
                db.Delete(data);
            }
            catch (Exception ex)
            {
                //todo: logging for exception
                return false;
            }
            return true;
        }

        public override bool SaveOrUpdate(BaseResultEntity data)
        {
            try
            {
                db.Save(data);
            }
            catch (Exception ex)
            {
                //todo: logging for exception
                return false;
            }
            return true;
        }

        public override void SetMapping<T>(DBMapping<T> mapping)
        {
            if (_map == null) _map = new Mappings();
            _map.For<T>().PrimaryKey(mapping.PrimaryColumn).TableName(mapping.TableName).Columns(
                x => {
                    foreach (var column in mapping.GenericColumns)
                    {
                        x.Column(column.Column).WithName(column.ColumnName);
                    }
                });
        }

        public override void RegisterMappings()
        {
            FluentMappingConfiguration.Scan(scanner => scanner.OverrideMappingsWith(_map));
        }
    }
}
