using BillingManagementSystem.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BillingManagementSystem.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        //Ortak olan işlemleri burda yapıyoruz. Sınıfa ait özellikleri o sınıfın içerisinde yapıyoruz
        //Listeleme
        IResponse<List<TDto>> GetAll();
        //Filtreli Listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        //Getirme
        IResponse<TDto> Find(int id);
        //Kaydetme
        IResponse<TDto> Add(TDto item, bool saveChanges = true);
        //Async Kaydetme
        Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true);
        //Queryable Listeleme
        IResponse<IQueryable<TDto>> GetQueryable();
        IResponse<TDto> Update(TDto item, bool saveChanges = true);
        //Async Güncelleme
        Task<IResponse<TDto>> UpdateASync(TDto item, bool saveChanges = true);
        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        //Async Silme
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);
        void Save();
    }
}