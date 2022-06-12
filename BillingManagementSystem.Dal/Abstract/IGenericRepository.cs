using BillingManagementSystem.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Dal.Abstract
{
    public interface IGenericRepository<T> where T : IEntityBase
    {


        //Listeleme
        List<T> GetAll();
        //Filtreli listeleme
        List<T> GetAll(Expression<Func<T, bool>> expression);
        //Getirme işlemi (Bulma)
        T Find(int id);
        //Kaydetme
        T Add(T item);
        //Async(Asenkron) Kaydetme
        Task<T> AddAsync(T item);
        //Güncelleme
        T Update(T item);
        //Silme
        bool Delete(int id);
        bool Delete(T item);
        //IQueryable Listele
        IQueryable<T> GetQueryable();
    }
}