using BeautySalon.DAL.DTO;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.DAL;
using BeautySalon.DAL.IRepositories;
using Dapper;

namespace BeautySalon.DAL.Repositories
{
    public class TypesRepository:ITypesRepository
    {
        public List<TypesDTO> GetServiceType()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<TypesDTO>(Procedures.GetAllWorkersByRoleId).ToList();
            }
        }

        public List<TypesDTO> GetAllServiceTypes()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<TypesDTO>(Procedures.GetAllServiceTypes).ToList();
            } 
        }
    }
}

