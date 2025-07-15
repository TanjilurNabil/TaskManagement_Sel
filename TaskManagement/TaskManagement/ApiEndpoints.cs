namespace TaskManagement.API
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Users
        {
            public const string Base = $"{ApiBase}/users";
            public const string CreateUser = Base;
            public const string Get = $"{Base}/{{id}}";
            public const string GetALL = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }
    }
}
