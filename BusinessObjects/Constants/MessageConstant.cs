﻿
namespace BusinessObjects.Constants
{
    public static class MessageConstant
    {
        public static class Vi
        {
            #region Template, Suffix, Prefix
            private const string CreateSuccessTemplate = "Tạo mới {0} thành công !!!";
            private const string UpdateSuccessTemplate = "Cập nhật {0} thành công !!!";
            private const string DeleteSuccessTemplate = "Xóa {0} thành công !!!";
            private const string CreateFailTemplate = "Tạo mới {0} thất bại @.@";
            private const string UpdateFailTemplate = "Cập nhật {0} thất bại @.@";
            private const string DeleteFailTemplate = "Xóa {0} thất bại @.@";
            private const string NotFoundTemplate = "{0} không có trong hệ thống";
            private const string InvalidRoleTemplate = "{0} không phải là {1} !!!";

            private const string RequiredSuffix = " không được bỏ trống !!!";
            #endregion
            public static class Auth
            {
                public const string PasswordNotMatched = "Mật khẩu không khớp! Thử lại";
            }
            public static class User
            {
                #region User Field
                private const string UserMessage = "User";
                private const string FullName = "Full name";
                private const string Email = "Email";
                private const string Gender = "Gender";
                private const string DateOfBirth = "Date of birth";
                private const string Address = "Address";
                private const string Password = "Password";
                private const string ProfileImage = "Profile image";
                private const string PhoneNumber = "Phone number";
                #endregion
                public static class Require
                {
                    public const string FullNameRequired = FullName + RequiredSuffix;
                    public const string EmailRequired = Email + RequiredSuffix;
                    public const string GenderRequired = Gender + RequiredSuffix;
                    public const string DateOfBirthRequired = DateOfBirth + RequiredSuffix;
                    public const string AddressRequired = Address + RequiredSuffix;
                    public const string PasswordRequired = Password + RequiredSuffix;
                    public const string PhoneNumberRequired = PhoneNumber + RequiredSuffix;
                    public const string ProfileImageRequired = ProfileImage + RequiredSuffix;
                }
                public static class Success
                {
                    public static string CreateUser = String.Format(CreateSuccessTemplate, UserMessage);
                    public static string UpdateUser = String.Format(UpdateSuccessTemplate, UserMessage);
                    public static string DeleteUser = String.Format(DeleteSuccessTemplate, UserMessage);
                }
                public static class Fail
                {
                    public static string CreateUser = String.Format(CreateFailTemplate, UserMessage);
                    public static string UpdateUser = String.Format(UpdateFailTemplate, UserMessage);
                    public static string DeleteUser = String.Format(DeleteFailTemplate, UserMessage);
                    public static string NotFoundUser = String.Format(NotFoundTemplate, UserMessage);
                    public static string EmailExisted = Email + " đã tồn tại !!!";
                }
            }
            public static class BadmintonCourt
            {
                #region User Field
                private const string BadmintonCourtMessage = "Badminton Court";
                private const string CourtName = "Court name";
                private const string CourtNumber = "Court number";
                private const string StartTime = "Start time";
                private const string EndTime = "End time";
                private const string NumberOfCourt = "Number of court";
                private const string Address = "Address";
                private const string Description = "Description";
                private const string CourtOwner = "Court owner";
                #endregion
                public static class Require
                {
                    public const string CourtNameRequired = CourtName + RequiredSuffix;
                    public const string CourtNumberRequired = CourtNumber + RequiredSuffix;
                    public const string StartTimeRequired = StartTime + RequiredSuffix;
                    public const string EndTimeRequired = EndTime + RequiredSuffix;
                    public const string NumberOfCourtRequired = NumberOfCourt + RequiredSuffix;
                    public const string AddressRequired = Address + RequiredSuffix;
                    public const string DescriptionRequired = Description + RequiredSuffix;
                    public const string CourtOwnerRequired = CourtOwner + RequiredSuffix;
                }
                public static class Success
                {
                    public static string CreateBadmintonCourt = String.Format(CreateSuccessTemplate, BadmintonCourtMessage);
                    public static string UpdateBadmintonCourt = String.Format(UpdateSuccessTemplate, BadmintonCourtMessage);
                    public static string DeleteBadmintonCourt = String.Format(DeleteSuccessTemplate, BadmintonCourtMessage);
                }
                public static class Fail
                {
                    public static string CreateBadmintonCourt = String.Format(CreateFailTemplate, BadmintonCourtMessage);
                    public static string UpdateBadmintonCourt = String.Format(UpdateFailTemplate, BadmintonCourtMessage);
                    public static string DeleteBadmintonCourt = String.Format(DeleteFailTemplate, BadmintonCourtMessage);
                    public static string NotFoundBadmintonCourt = String.Format(NotFoundTemplate, BadmintonCourtMessage);
                }
            }
        }
    }
}