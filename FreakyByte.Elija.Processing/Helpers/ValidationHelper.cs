using FreakyByte.Elija.DataAccess.Model;
using FreakyByte.Elija.DataAccess.Repositories.Implementations;

namespace FreakyByte.Elija.Processing.Helpers
{
    public class ValidationHelper
    {
        #region Fields

        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        #endregion

        #region Public Methods and Operators

        public bool ValidateToken(string token)
        {
            Authentication user = unitOfWork.AuthenticationrRepository.FindFirstBy(e => e.Token == token);

            return user != null;
        }

        #endregion
    }
}