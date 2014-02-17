using System;
using System.Collections.Generic;
using System.Linq;
using FreakyByte.Elija.DataAccess.Model;
using FreakyByte.Elija.DataAccess.Repositories.Implementations;
using FreakyByte.Elija.Entities.DataContracts;
using FreakyByte.Elija.Processing.Helpers;
using log4net;

namespace FreakyByte.Elija.Processing.Services
{
    public class ElijaServiceManager
    {
        #region Fields

        private static readonly ILog Logger = LogManager.GetLogger(typeof (ElijaServiceManager));
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();
        private const int PAGE_SIZE = 2;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Handles the process of resizing an image.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Result<string> ImageResize(string url)
        {
            var result = new Result<string>();
            try
            {
                var image = ImageProcessingHelper.ResizeImage(url);
                result.Data = image;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        /// <summary>
        ///     Finds a specific user by their Facebook id
        /// </summary>
        /// <param name="facebookId">User's Facebook id</param>
        /// <returns></returns>
        private static User GetUserByFacebookId(int facebookId)
        {
            var user = UnitOfWork.UserRepository.FindFirstBy(e => e.FacebookId == facebookId);
            return user;
        }

        /// <summary>
        ///     Searches for a device that belongs to a specific user.
        /// </summary>
        /// <param name="userId">The registered user id.</param>
        /// <param name="androidId">The android id of this device.</param>
        /// <returns></returns>
        private static UserDevice GetDeviceByAndroidId(int userId, string androidId)
        {
            var userDevice =
                UnitOfWork.UserDeviceRepository.FindFirstBy(e => e.UserId == userId && e.Device.AndroidId == androidId);

            return userDevice;
        }

        /// <summary>
        ///     Sets a new token and expiration date for a new user.
        /// </summary>
        /// <param name="userDevice"></param>
        /// <returns></returns>
        private static Authentication CreateAuthenticationInfo()
        {
            var token = Guid.NewGuid().ToString();
            var expirationDate = DateTime.Now.AddDays(7);

            var authentication = new Authentication {Token = token, Expiration = expirationDate};
            return authentication;
        }


        /// <summary>
        ///     Registers a new user into the platform. If it's a returning user, it logs them in and returns the user token.
        /// </summary>
        /// <param name="userDevice">
        ///     Contains the necessary information about the user and their device to register them
        ///     into the platform.
        /// </param>
        /// <returns>If the process is successful, it returns the user's token inside the Content field.</returns>
        public Result<string> RegisterUser(UserDeviceModel userDevice)
        {
            var result = new Result<string> {Success = true};

            if (userDevice == null)
            {
                result.Success = false;
                //result.Message = ErrorMessages.NullUserError;
                return result;
            }

            try
            {
                // Check whether the user is registered in the Data Base.
                var userDb = GetUserByFacebookId((int) userDevice.FacebookId);
                if (userDb == null)
                {
                    result.Data = InsertNewUser(userDevice);
                }

                // If it's a registered user who made the request but from a non registered device, create a new record for
                // the new device.
                var device = GetDeviceByAndroidId(userDb.UserId, userDevice.AndroidId);

                if (device == null)
                {
                    result.Data = InsertNewDevice(userDb, userDevice);
                }

                //if the user and device are already registered, return the user's token.
                result.Data = "success";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                //result.Message = ErrorMessages.ErrorMessage;
                Logger.Error(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     If the registration request comes from a registered user but with a new device, it registers it into the platform.
        /// </summary>
        /// <param name="userDb">The user's information that is already registered.</param>
        /// <param name="userDevice">Information about the device from which the request was made.</param>
        /// <returns>If the process is successful, it return the user's token inside the Content field.</returns>
        private static string InsertNewDevice(User userDb, UserDeviceModel userDevice)
        {
            var device = new Device
            {
                IMEI = userDevice.Imei,
                AndroidId = userDevice.AndroidId,
                Brand = userDevice.Brand,
                CodeVersion = userDevice.CodeVersion,
                Device1 = userDevice.Device,
                Display = userDevice.Display,
                IsPhone = userDevice.IsPhone,
                Manufacturer = userDevice.Manufacturer,
                Model = userDevice.Model,
                Operator = userDevice.Operator,
                OsVersion = userDevice.OsVersion,
                Product = userDevice.Product,
                ReleaseVersion = userDevice.ReleaseVersion,
                RegistrationDate = userDevice.DeviceRegistrationDate
            };

            var userDeviceDb = new UserDevice
            {
                UserId = userDb.UserId,
                DeviceId = device.DeviceId,
                CreatedAt = DateTime.Now,
                LastActivityDate = DateTime.Now
            };

            var authentication = CreateAuthenticationInfo();

            userDeviceDb.Authentication = authentication;

            UnitOfWork.DeviceRepository.Add(device);
            UnitOfWork.UserDeviceRepository.Add(userDeviceDb);
            UnitOfWork.Save();

            return authentication.Token;
        }

        /// <summary>
        ///     Registers a new user into the platform.
        /// </summary>
        /// <param name="user">The new user's information.</param>
        /// <returns>If the process is successful, it return the user's token inside the Content field.</returns>
        private static string InsertNewUser(UserDeviceModel user)
        {
            var userDevice = new UserDevice
            {
                User =
                    new User
                    {
                        FacebookId = user.FacebookId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = user.Age,
                        City = user.City,
                        Email = user.Email,
                        Gender = user.Gender,
                        FacebookLink = user.FacebookLink,
                        Address = user.Address,
                        Birthday = user.Birthday,
                        RegistrationDate = user.UserRegistrationDate,
                    },
                Device =
                    new Device
                    {
                        IMEI = user.Imei,
                        AndroidId = user.AndroidId,
                        Brand = user.Brand,
                        CodeVersion = user.CodeVersion,
                        Device1 = user.Device,
                        Display = user.Display,
                        IsPhone = user.IsPhone,
                        Manufacturer = user.Manufacturer,
                        Model = user.Model,
                        Operator = user.Operator,
                        OsVersion = user.OsVersion,
                        Product = user.Product,
                        ReleaseVersion = user.ReleaseVersion,
                        RegistrationDate = user.DeviceRegistrationDate
                    },
                CreatedAt = DateTime.Now,
                LastActivityDate = DateTime.Now
            };

            var authentication = CreateAuthenticationInfo();

            userDevice.Authentication = authentication;

            UnitOfWork.UserDeviceRepository.Add(userDevice);
            UnitOfWork.Save();

            return authentication.Token;
        }

        #endregion

        public static Result<SectionModel> GetSectionArticles(int sectionId, int page, int screenDensity, bool isWifi)
        {
            var result = new Result<SectionModel> {Success = true};
            List<ArticleModel> articleList;

            var section = UnitOfWork.SectionRepository.FindFirstBy(e => e.SectionId == sectionId);
            var sectionArticles = section.Article.Skip(PAGE_SIZE*page).Take(PAGE_SIZE).ToList();

            if (isWifi)
            {
                articleList = GetHighQualityArticle(sectionArticles, screenDensity);
            }
            else
            {
                articleList = GetLowQualityArticle(sectionArticles, screenDensity);
            }

            var sectionModel = ModelFactory.CreateSectionModel(section);
            sectionModel.Article = articleList;

            result.Data = sectionModel;

            return result;
        }

        private static List<ArticleModel> GetHighQualityArticle(IEnumerable<Article> articles , int screenDensity)
        {
            var articleList = new List<ArticleModel>();
            foreach (var item in articles)
            {
                var thumbnail = (from thumb in item.Image
                    where thumb.ArticleId == item.ArticleId && thumb.ImageTypeId == (int) ImageTypeEnum.Thumbnail
                    select thumb).FirstOrDefault();

                Image normalImage;

                switch (screenDensity)
                {
                    case 1:
                    case 2:
                        normalImage = (from image in item.Image
                            where image.ArticleId == item.ArticleId && image.ImageTypeId == (int) ImageTypeEnum.Small
                            select image).FirstOrDefault();
                        break;
                    case 3:
                    case 4:
                        normalImage = (from image in item.Image
                            where image.ArticleId == item.ArticleId && image.ImageTypeId == (int) ImageTypeEnum.Medium
                            select image).FirstOrDefault();
                        break;
                    default:
                        normalImage = (from image in item.Image
                            where image.ArticleId == item.ArticleId && image.ImageTypeId == (int) ImageTypeEnum.Large
                            select image).FirstOrDefault();
                        break;
                }

                var articleModel = ModelFactory.CreateArticleMOdel(item, thumbnail, normalImage);
                articleList.Add(articleModel);
            }

            return articleList;
        }

        private static List<ArticleModel> GetLowQualityArticle(IEnumerable<Article> articles, int screenDensity)
        {
            var articleList = new List<ArticleModel>();
            foreach (var item in articles)
            {
                var thumbnail = (from thumb in item.Image
                    where
                        thumb.ArticleId == item.ArticleId && thumb.ImageTypeId == (int) ImageTypeEnum.Thumbnail
                    select thumb).FirstOrDefault();

                Image normalImage;

                switch (screenDensity)
                {
                    case 1:
                    case 2:
                        normalImage = (from image in item.Image
                            where
                                image.ArticleId == item.ArticleId &&
                                image.ImageTypeId == (int) ImageTypeEnum.SmallLowQuality
                            select image).FirstOrDefault();
                        break;
                    case 3:
                    case 4:
                        normalImage = (from image in item.Image
                            where
                                image.ArticleId == item.ArticleId &&
                                image.ImageTypeId == (int) ImageTypeEnum.MediumLowQuality
                            select image).FirstOrDefault();
                        break;
                    default:
                        normalImage = (from image in item.Image
                            where
                                image.ArticleId == item.ArticleId &&
                                image.ImageTypeId == (int) ImageTypeEnum.LargeLowQuality
                            select image).FirstOrDefault();
                        break;
                }

                var articleModel = ModelFactory.CreateArticleMOdel(item, thumbnail, normalImage);
                articleList.Add(articleModel);
            }

            return articleList;
        }
    }
}