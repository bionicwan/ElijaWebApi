namespace FreakyByte.Elija.Entities.DataContracts
{
    using FreakyByte.Elija.DataAccess.Model;

    public class ModelFactory
    {
        public UserModel Create(User user)
        {
            return new UserModel()
                       {
                           UserId = user.UserId,
                           Address = user.Address,
                           Age = user.Age,
                           Birthday = user.Birthday,
                           City = user.City,
                           Email = user.Email,
                           FacebookId = user.FacebookId,
                           FacebookLink = user.FacebookLink,
                           FirstName = user.FirstName,
                           Gender = user.Gender,
                           LastName = user.LastName,
                           RegistrationDate = user.RegistrationDate,
                           TelephoneHome = user.TelephoneHome,
                           TelephoneMobile = user.TelephoneMobile,
                           TelephoneOffice = user.TelephoneOffice
                       };
        }

        public DeviceModel Create(Device device)
        {
            return new DeviceModel()
                       {
                           DeviceId = device.DeviceId,
                           AndroidId = device.AndroidId,
                           Brand = device.Brand,
                           CodeVersion = device.CodeVersion,
                           Device = device.Device1,
                           Display = device.Display,
                           Imei = device.IMEI,
                           IsPhone = device.IsPhone,
                           Manufacturer = device.Manufacturer,
                           Model = device.Model,
                           Operator = device.Operator,
                           OsVersion = device.OsVersion,
                           Product = device.Product,
                           RegistrationDate = device.RegistrationDate,
                           ReleaseVersion = device.ReleaseVersion
                       };
        }

        public UserDeviceModel Create(User user, Device device)
        {
            return new UserDeviceModel()
                       {
                           Address = user.Address,
                           Age = user.Age,
                           Birthday = user.Birthday,
                           City = user.City,
                           Email = user.Email,
                           FacebookId = user.FacebookId,
                           FacebookLink = user.FacebookLink,
                           FirstName = user.FirstName,
                           Gender = user.Gender,
                           LastName = user.LastName,
                           UserRegistrationDate = user.RegistrationDate,
                           TelephoneHome = user.TelephoneHome,
                           TelephoneMobile = user.TelephoneMobile,
                           TelephoneOffice = user.TelephoneOffice,
                           AndroidId = device.AndroidId,
                           Brand = device.Brand,
                           CodeVersion = device.CodeVersion,
                           Device = device.Device1,
                           Display = device.Display,
                           Imei = device.IMEI,
                           IsPhone = device.IsPhone,
                           Manufacturer = device.Manufacturer,
                           Model = device.Model,
                           Operator = device.Operator,
                           OsVersion = device.OsVersion,
                           Product = device.Product,
                           ReleaseVersion = device.ReleaseVersion,
                           DeviceRegistrationDate = device.RegistrationDate
                       };
        }
    }
}
