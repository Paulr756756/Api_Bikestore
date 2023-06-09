using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class DatabaseModel
    {
        public string? ProcedureName { get; set; }
        public CommandType CommandType { get; set; }
        public List<SqlParameter>? SqlParameters { get; set; }
    }
}
