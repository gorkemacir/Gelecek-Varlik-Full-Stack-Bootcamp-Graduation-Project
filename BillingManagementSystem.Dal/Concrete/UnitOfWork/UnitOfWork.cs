using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Dal.Concrete.Repository;
using BillingManagementSystem.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Dal.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables
        DbContext context;
        IDbContextTransaction transaction;
        bool dispose;
        #endregion

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);// çöp toplama işini yaptırıyoruz
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            using (_transaction)
                //context oluşturuyoruz
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }
                    int result = context.SaveChanges();

                    _transaction.Commit();//transaction onaylandığı yerdir

                    return result;
                }
                catch (Exception ex)
                {//işlemi geri alır

                    transaction.Rollback();
                    throw new Exception("Error on save changes", ex);
                }
        }
    }
}