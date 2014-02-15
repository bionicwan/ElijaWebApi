namespace FreakyByte.Elija.Entities.DataContracts
{
    using System;

    public class UserDeviceModel
    {
        #region Public Properties

        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public string Address { get; set; }

        public int? Age { get; set; }

        public string AndroidId { get; set; }

        public DateTime? Birthday { get; set; }

        public string Brand { get; set; }

        public string City { get; set; }

        public string CodeVersion { get; set; }

        public string Device { get; set; }

        public int Display { get; set; }

        public string Email { get; set; }

        public int? FacebookId { get; set; }

        public string FacebookLink { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public string TelephoneHome { get; set; }

        public string TelephoneMobile { get; set; }

        public string TelephoneOffice { get; set; }

        public int? Imei { get; set; }

        public bool IsPhone { get; set; }

        public string LastName { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Operator { get; set; }

        public string OsVersion { get; set; }

        public string Product { get; set; }

        public DateTime? UserRegistrationDate { get; set; }

        public DateTime DeviceRegistrationDate { get; set; }

        public string ReleaseVersion { get; set; }

        public string Url { get; set; }

        #endregion
    }
}