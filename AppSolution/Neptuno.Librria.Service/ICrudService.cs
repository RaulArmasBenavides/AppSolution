using System.Collections.Generic;
using System.Data.SqlClient;

namespace Neptuno.Libreria.Service
{
    public interface ICrudService <T>
    {
        #region Interface
        //definir las firmas
        void create(SqlConnection cn,T t);
        void update(SqlConnection cn,T t);
        void delete(SqlConnection cn,T t);
        List<T> readAll(SqlConnection cn);
        T findForId(SqlConnection cn,T t);
        #endregion
    }
}
