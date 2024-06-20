
namespace BusinessObjects.Constants
{
    public static class ApiEndPointConstant
    {
        static ApiEndPointConstant()
        {
        }

        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public const string ByIdRoute = "/{id}";

        public static class Authentication
        {
            /// <summary>"api/v1/login"</summary>
            public const string LoginEndPoint = ApiEndpoint + "/login";
            // <summary>"api/v1/google/login"</summary>
            public const string RegisterEndPoint = ApiEndpoint + "/register";
        }
        public static class PlayerAuth
        {
            /// <summary>"api/v1/login"</summary>
            public const string LoginEndPoint = ApiEndpoint + "/player-login";
            // <summary>"api/v1/google/login"</summary>
            public const string RegisterEndPoint = ApiEndpoint + "/player-register";
        }
        public static class User
        {
            /// <summary>"api/v1/users"</summary>
            public const string UsersEndpoint = ApiEndpoint + "/users";
            /// <summary>"api/v1/users/{id}"</summary>
            public const string UserEndpoint = UsersEndpoint + ByIdRoute;
        }
        public static class BadmintonCourt
        {
            /// <summary>"api/v1/badminton-courts"</summary>
            public const string BadmintonCourtsEndpoint = ApiEndpoint + "/badminton-courts";
            /// <summary>"api/v1/badminton-courts/{id}"</summary>
            public const string BadmintonCourtEndpoint = BadmintonCourtsEndpoint + ByIdRoute;
        }
    }
}
