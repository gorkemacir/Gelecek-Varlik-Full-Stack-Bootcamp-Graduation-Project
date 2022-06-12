using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Dal.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;
        bool BeginTransaction();
        //transaction başlatır
        bool RollBackTransaction();
        //hata durumunda sürecin geri alınmasını sağlayan işlemdir
        int SaveChanges();
        //transaction onaylar
    }
}