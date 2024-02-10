using BeautySalon.DAL.DTO;
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

        public void UpdateServiceTitle(int serviceId, string serviceTitle)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceId = serviceId,
                    ServiceTitle = serviceTitle
                };
                connection.Query(Procedures.UpdateServiceTitle, parameters).ToList();
            }
        }

        public List<GetAllServicesDTO> GetAllServices()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<GetAllServicesDTO, TypesDTO, GetAllServicesDTO>(
                    Procedures.GetAllServices,
                    (services, types) =>
                    {
                        services.Types = types;
                        return services;
                    }, splitOn: "Title").ToList();
            }
        }

        public void AddServiceById(string title, int type, string duration, decimal price)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceTitle = title,
                    ServiceType = type,
                    ServiceDuration = duration,
                    ServicePrice = price
                }; connection.Query<ServicesDTO>(Procedures.AddServiceById, parameters).ToList();
            }
        }

        public void UpdateServicePrice(int serviceId, decimal servicePrice)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceId = serviceId,
                    ServicePrice = servicePrice
                };
                connection.Query(Procedures.UpdateServicePrice, parameters).ToList();
            }
        }
    }
}
