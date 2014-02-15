namespace FreakyByte.Elija.Processing.Helpers
{
    using FreakyByte.Elija.DataAccess.Repositories.Implementations;

    public class ValidationHelper
    {
        #region Fields

        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        #endregion

        #region Public Methods and Operators

        public bool ValidateToken(string token)
        {
            var user = this.unitOfWork.AuthenticationrRepository.FindFirstBy(e => e.Token == token);

            return user != null;
        }

        #endregion
    }
}
