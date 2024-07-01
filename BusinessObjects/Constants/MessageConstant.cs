
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
                private const string Role = "Role";
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
                    public const string RoleRequired = Role + RequiredSuffix;
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
                #region BadmintonCourt Field
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
            public static class TypeOfCourt
            {
                #region TypeOfCourt Field
                private const string TypeOfCourtMessage = "Type of court";
                private const string TypeName = "Type name";
                private const string TypeDescription = "Type description";
                #endregion
                public static class Require
                {
                    public const string TypeNameRequired = TypeName + RequiredSuffix;
                    public const string TypeDescriptionRequired = TypeDescription + RequiredSuffix;
                }
                public static class Success
                {
                    public static string CreateTypeOfCourt = String.Format(CreateSuccessTemplate, TypeOfCourtMessage);
                    public static string UpdateTypeOfCourt = String.Format(UpdateSuccessTemplate, TypeOfCourtMessage);
                    public static string DeleteTypeOfCourt = String.Format(DeleteSuccessTemplate, TypeOfCourtMessage);
                }
                public static class Fail
                {
                    public static string CreateTypeOfCourt = String.Format(CreateFailTemplate, TypeOfCourtMessage);
                    public static string UpdateTypeOfCourt = String.Format(UpdateFailTemplate, TypeOfCourtMessage);
                    public static string DeleteTypeOfCourt = String.Format(DeleteFailTemplate, TypeOfCourtMessage);
                    public static string NotFoundTypeOfCourt = String.Format(NotFoundTemplate, TypeOfCourtMessage);
                }
            }
            public static class Court
            {
                #region Court Field
                private const string CourtMessage = "Court";
                private const string CourtCode = "Court code";
                private const string TypeOfCourt = "Type of court";
                private const string BadmintonCourt = "Badminton court";
                #endregion
                public static class Require
                {
                    public const string CourtCodeRequired = CourtCode + RequiredSuffix;
                    public const string TypeOfCourtRequired = TypeOfCourt + RequiredSuffix;
                    public const string BadmintonCourtRequired = BadmintonCourt + RequiredSuffix;
                }
                public static class Success
                {
                    public static string CreateCourt = String.Format(CreateSuccessTemplate, CourtMessage);
                    public static string UpdateCourt = String.Format(UpdateSuccessTemplate, CourtMessage);
                    public static string DeleteCourt = String.Format(DeleteSuccessTemplate, CourtMessage);
                }
                public static class Fail
                {
                    public static string CreateCourt = String.Format(CreateFailTemplate, CourtMessage);
                    public static string UpdateCourt = String.Format(UpdateFailTemplate, CourtMessage);
                    public static string DeleteCourt = String.Format(DeleteFailTemplate, CourtMessage);
                    public static string NotFoundCourt = String.Format(NotFoundTemplate, CourtMessage);
                }
            }
            public static class CourtSlot
            {
                #region Court Field
                private const string CourtSlotMessage = "Court slot";
                private const string CourtNumber = "Court code";
                private const string StartTime = "Start time";
                private const string EndTime = "End time";
                private const string Price = "Price";
                #endregion
                public static class Require
                {
                    public const string CourtNumberRequired = CourtNumber + RequiredSuffix;
                    public const string StartTimeRequired = StartTime + RequiredSuffix;
                    public const string EndTimeRequired = EndTime + RequiredSuffix;
                    public const string PriceRequired = Price + RequiredSuffix;
                }
                public static class Success
                {
                    public static string CreateCourtSlot = String.Format(CreateSuccessTemplate, CourtSlotMessage);
                    public static string UpdateCourtSlot = String.Format(UpdateSuccessTemplate, CourtSlotMessage);
                    public static string DeleteCourtSlot = String.Format(DeleteSuccessTemplate, CourtSlotMessage);
                }
                public static class Fail
                {
                    public static string CreateCourtSlot = String.Format(CreateFailTemplate, CourtSlotMessage);
                    public static string UpdateCourtSlot = String.Format(UpdateFailTemplate, CourtSlotMessage);
                    public static string DeleteCourtSlot = String.Format(DeleteFailTemplate, CourtSlotMessage);
                    public static string NotFoundCourtSlot = String.Format(NotFoundTemplate, CourtSlotMessage);
                }
            }
        }
    }
}
