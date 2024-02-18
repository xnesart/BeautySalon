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
using System.Reflection.Metadata;

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

        public void UpdateServiceTitle(UpdateServiceTitleDTO dto)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceId = dto.Id,
                    ServiceTitle = dto.Title
                };
                connection.Query(Procedures.UpdateServiceTitle, parameters).ToList();
            }
        }
        
        public List<AllFreeIntervalsOnCurrentServiceDTO> GetAllFreeIntervalsOnCurrentService(int serviceId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameter = new
                {
                    ServiceId = serviceId
                };

                return connection.Query<ServicesDTO, IntеrvalsDTO, AllFreeIntervalsOnCurrentServiceDTO>
                 (
                     Procedures.GetAllFreeIntervalsOnCurrentService,
                     (service, interval) =>
                     {
                         AllFreeIntervalsOnCurrentServiceDTO allFreeIntervals = new AllFreeIntervalsOnCurrentServiceDTO();

                         allFreeIntervals.Services = new ServicesDTO();
                         allFreeIntervals.Services.Id = service.Id;
                         allFreeIntervals.Services.Title = service.Title;

                         allFreeIntervals.Intеrvals = new IntеrvalsDTO();
                         allFreeIntervals.Intеrvals.Id = interval.Id;
                         allFreeIntervals.Intеrvals.Title = interval.Title;
                         allFreeIntervals.Intеrvals.StartTime = interval.StartTime;

                         return allFreeIntervals;
                     },
                     parameter,
                     splitOn: "Id,Id"
                 ).ToList();

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


        public void AddServiceById(AddServiceByIdDTO serviceDTO) 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceTitle = serviceDTO.Title,
                    ServiceType = serviceDTO.Type,
                    ServiceDuration = serviceDTO.Duration,
                    ServicePrice = serviceDTO.Price,
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
        
        public void UpdateServiceDuration(int serviceId, string serviceDuration)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    ServiceId = serviceId,
                    ServiceDuration = serviceDuration
                };
                connection.Query(Procedures.UpdateServiceDuration, parameters).ToList();
            }
        }
        
        public void RemoveServiceById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                var parameters = new
                {
                    Id = id
                };
                connection.Query<ServicesDTO>(Procedures.RemoveServiceById, parameters);
            }
        }
    }
}
