namespace FreakyByte.Elija.Entities.DataContracts
{
    using System;

    public class DeviceModel
    {
        #region Public Properties
        
        public int DeviceId { get; set; }

        public string AndroidId { get; set; }

        public string Brand { get; set; }

        public string CodeVersion { get; set; }

        public string Device { get; set; }

        public int Display { get; set; }

        public int? Imei { get; set; }

        public bool IsPhone { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Operator { get; set; }

        public string OsVersion { get; set; }

        public string Product { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string ReleaseVersion { get; set; }

        public string Url { get; set; }

        #endregion
    }
}