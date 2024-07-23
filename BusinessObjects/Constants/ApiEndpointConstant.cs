
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
            /// <summary>"api/v1/badminton-courts/paging"</summary>
            public const string BadmintonCourtsPagingEndpoint = BadmintonCourtsEndpoint + "/paging";
        }
        public static class TypeOfCourt
        {
            /// <summary>"api/v1/types-of-court"</summary>
            public const string TypeOfCourtsEndpoint = ApiEndpoint + "/types-of-court";
            /// <summary>"api/v1/types-of-court/{id}"</summary>
            public const string TypeOfCourtEndpoint = TypeOfCourtsEndpoint + ByIdRoute;
        }
        public static class Court
        {
            /// <summary>"api/v1/courts"</summary>
            public const string CourtsEndpoint = ApiEndpoint + "/courts";
            /// <summary>"api/v1/courts/{id}"</summary>
            public const string CourtEndpoint = CourtsEndpoint + ByIdRoute;
        }
        public static class CourtSlot
        {
            /// <summary>"api/v1/court-slots"</summary>
            public const string CourtSlotsEndpoint = ApiEndpoint + "/court-slots";
            /// <summary>"api/v1/court-slots/{id}"</summary>
            public const string CourtSlotEndpoint = CourtSlotsEndpoint + ByIdRoute;
        }
        public static class BookingReservation
        {
            /// <summary>"api/v1/booking-reservations"</summary>
            public const string BookingReservationsEndpoint = ApiEndpoint + "/booking-reservations";
            /// <summary>"api/v1/booking-reservations/{id}"</summary>
            public const string BookingReservationEndpoint = BookingReservationsEndpoint + ByIdRoute;
        }
        public static class Payment
        {
            /// <summary>"api/v1/payments"</summary>
            public const string PaymentsEndpoint = ApiEndpoint + "/payments";
            /// <summary>"api/v1/payments/{id}"</summary>
            public const string PaymentEndpoint = PaymentsEndpoint + ByIdRoute;
        }

    }
}
