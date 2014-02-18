using FreakyByte.Elija.DataAccess.Model;

namespace FreakyByte.Elija.Entities.DataContracts
{
    public static class ModelFactory
    {
        public static UserModel CreateUserModel(User user)
        {
            return new UserModel
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

        public static DeviceModel CreateDeviceModel(Device device)
        {
            return new DeviceModel
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

        public static UserDeviceModel CreateUserDeviceModel(User user, Device device)
        {
            return new UserDeviceModel
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

        public static SectionModel CreateSectionModel(Node node)
        {
            return new SectionModel
            {
                Section = node.Name
            };
        }

        public static ArticleImageModel CreateArticleImageModel(Image thumbnail, Image normalImage)
        {
            return new ArticleImageModel
            {
                Thumbnail = CreatemageModel(thumbnail),
                NormalImage = CreatemageModel(normalImage)
            };
        }

        public static ImageModel CreatemageModel(Image image)
        {
            return new ImageModel
            {
                Url = image.Url,
                Height = image.Height,
                Width = image.Width
            };
        }

        public static ArticleModel CreateArticleMOdel(Node article, Image thumbnail, Image normalImage)
        {
            return new ArticleModel
            {
                Id = article.NodeId,
                Title = article.Name,
                Descrition = article.Text,
                Images = CreateArticleImageModel(thumbnail, normalImage)
            };
        }
    }
}