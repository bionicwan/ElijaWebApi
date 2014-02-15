namespace FreakyByte.Elija.Entities.DataContracts
{
    using System;

    public class UserModel
    {
        #region Public Properties

        public int UserId { get; set; }

        public string Address { get; set; }

        public int? Age { get; set; }

        public DateTime? Birthday { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public int? FacebookId { get; set; }

        public string FacebookLink { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public string LastName { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string TelephoneHome { get; set; }

        public string TelephoneMobile { get; set; }

        public string TelephoneOffice { get; set; }

        public string Url { get; set; }

        #endregion
    }
}