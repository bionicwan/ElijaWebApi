using System;
using FreakyByte.Elija.DataAccess.Model;

namespace FreakyByte.Elija.DataAccess.Repositories.Interfaces
{
    public interface IDbContextFactory : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The database context.
        /// </summary>
        /// <returns>
        ///     The database context instance.
        /// </returns>
        ElijaEntities GetDbContext();

        #endregion
    }
}