using System;
using System.Threading.Tasks;
using WeGo.Administration.Domain.Interfaces.Context;
using WeGo.Administration.Domain.Interfaces.UoW;

namespace WeGo.Administration.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWeGoContext weGoContext;

        public UnitOfWork(IWeGoContext weGoContext)
        {
            this.weGoContext = weGoContext;
        }

        public async Task<bool> Commit()
        {
            var retorno = await weGoContext.SaveChanges();
            return retorno > 0;
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    weGoContext?.Dispose();
                }
                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
}