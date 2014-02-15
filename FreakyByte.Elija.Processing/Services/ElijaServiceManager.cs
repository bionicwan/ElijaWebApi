namespace FreakyByte.Elija.Processing.Services
{
    using System;

    using FreakyByte.Elija.DataAccess.Model;
    using FreakyByte.Elija.DataAccess.Repositories.Implementations;
    using FreakyByte.Elija.Entities.DataContracts;
    using FreakyByte.Elija.Processing.Helpers;

    using log4net;

    public class ElijaServiceManager
    {
        #region Fields

        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ElijaServiceManager));

        #endregion


        #region Public Methods and Operators

        /// <summary>
        /// Handles the process of resizing an image.
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
        /// Finds a specific user by their Facebook id
        /// </summary>
        /// <param name="facebookId">User's Facebook id</param>
        /// <returns></returns>
        private User GetUserByFacebookId(int facebookId)
        {
            var user = this.unitOfWork.UserRepository.FindFirstBy(e => e.FacebookId == facebookId);
            return user;
        }

        /// <summary>
        /// Searches for a device that belongs to a specific user.
        /// </summary>
        /// <param name="userId">The registered user id.</param>
        /// <param name="androidId">The android id of this device.</param>
        /// <returns></returns>
        private UserDevice GetDeviceByAndroidId(int userId, string androidId)
        {
            var userDevice =
                this.unitOfWork.UserDeviceRepository.FindFirstBy(e => e.UserId == userId && e.Device.AndroidId == androidId);

            return userDevice;
        }

        /// <summary>
        /// Sets a new token and expiration date for a new user.
        /// </summary>
        /// <param name="userDevice"></param>
        /// <returns></returns>
        private static Authentication CreateAuthenticationInfo()
        {
            var token = Guid.NewGuid().ToString();
            var expirationDate = DateTime.Now.AddDays(7);

            var authentication = new Authentication() { Token = token, Expiration = expirationDate };
            return authentication;
        }



        /// <summary>
        /// Registers a new user into the platform. If it's a returning user, it logs them in and returns the user token.
        /// </summary>
        /// <param name="userDevice">
        /// Contains the necessary information about the user and their device to register them
        /// into the platform.
        /// </param>
        /// <returns>If the process is successful, it returns the user's token inside the Content field.</returns>
        public Result<string> RegisterUser(UserDeviceModel userDevice)
        {
            var result = new Result<string> { Success = true };

            if (userDevice == null)
            {
                result.Success = false;
                //result.Message = ErrorMessages.NullUserError;
                return result;
            }

            try
            {
                // Check whether the user is registered in the Data Base.
                var userDb = this.GetUserByFacebookId((int)userDevice.FacebookId);
                if (userDb == null)
                {
                    result.Data = InsertNewUser(userDevice);
                }

                // If it's a registered user who made the request but from a non registered device, create a new record for
                // the new device.
                var device = this.GetDeviceByAndroidId(userDb.UserId, userDevice.AndroidId);
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
        /// If the registration request comes from a registered user but with a new device, it registers it into the platform.
        /// </summary>
        /// <param name="userDb">The user's information that is already registered.</param>
        /// <param name="userDevice">Information about the device from which the request was made.</param>
        /// <returns>If the process is successful, it return the user's token inside the Content field.</returns>
        private string InsertNewDevice(User userDb, UserDeviceModel userDevice)
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

            this.unitOfWork.DeviceRepository.Add(device);
            this.unitOfWork.UserDeviceRepository.Add(userDeviceDb);
            this.unitOfWork.Save();

            return authentication.Token;
        }

        /// <summary>
        /// Registers a new user into the platform.
        /// </summary>
        /// <param name="user">The new user's information.</param>
        /// <returns>If the process is successful, it return the user's token inside the Content field.</returns>
        private string InsertNewUser(UserDeviceModel user)
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

            this.unitOfWork.UserDeviceRepository.Add(userDevice);
            this.unitOfWork.Save();

            return authentication.Token;
        }

        #endregion
    }
}