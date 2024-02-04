﻿using BeautySalon.DAL.DTO;
using BeautySalon.DAL.StoredProcedures;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.DAL.IRepositories;
using Dapper;

namespace BeautySalon.DAL.Repositories
{
    public class ServicesRepository:IServicesRepository
    {
        public List<ServicesDTO> GetServicesWithPriceAndDurationByTypeId(int typeId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ServicesDTO>(Procedures.GetServicesWithPriceAndDurationByTypeId).ToList();
            }
        }

        public List<GetAllServicesByIdFromCurrentTypeDTO> GetAllServicesByIdFromCurrentType(int id)
        {
            using (IDbConnection connection =new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    Id = id
                };
                return connection
                    .Query<GetAllServicesByIdFromCurrentTypeDTO, TypesDTO, GetAllServicesByIdFromCurrentTypeDTO>(
                        Procedures.GetAllServicesByIdFromCurrentType,
                        (services, types) =>
                        {
                            if (services.Types == null)
                            {
                                services.Types = new List<TypesDTO>();
                            }

                            services.Types.Add(types);
                            return services;
                        }, parameters, splitOn: "Id,Id").ToList();
            }
        }
    }
}
