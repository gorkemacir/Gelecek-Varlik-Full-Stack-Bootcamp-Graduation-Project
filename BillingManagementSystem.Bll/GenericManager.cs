using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BillingManagementSystem.Interface;
using BillingManagementSystem.Entity.Base;
using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.IBase;

namespace BillingManagementSystem.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        #region Variables
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor
        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
        }
        #endregion

        #region Methods
        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {

                var model = ObjectMapper.Mapper.Map<T>(item);

                var result = repository.Add(model);

                if (saveChanges)
                {
                    Save(); //kaydetme işleminde transaction'ı onaylıyoruz
                }

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };//dönüş tipini ayarlıyoruz
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri setini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            try
            {
                //ekleme işlemini asenkron oluşturmak için yapıyoruz bu işlemi
                var model = ObjectMapper.Mapper.Map<T>(item);
                var result = await repository.AddAsync(model);

                if (saveChanges)
                {
                    Save();
                }
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }



        public IResponse<TDto> Find(int id)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id));
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll()
        {
            try
            {//listeleme işlemini yapıyoruz
                var list = repository.GetAll();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {//filtreli listeleme işlemini yapıyoruz
                var list = repository.GetAll(expression);
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);

                if (saveChanges)
                    Save();

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
            }
            catch (Exception ex)
            {

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = false
                };
            }
        }

        public Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            try
            {
                // dto tipi model(T) tipine dönüştürülüyor
                // sebebi : Dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                //var resolvesResult = "";
                var result = repository.Update(model);
                if (saveChanges)
                    Save(); // Kaydetme işlemi olduğundan transaction'ı commitliyoruz

                //dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };

            }
            catch (Exception ex)
            {
                // hata olma durumunda dönecek veri seti 
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<IResponse<TDto>> UpdateASync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }


        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        #endregion
    }
}