namespace Abp
{
    /// <summary>
    /// 用于定义ABP的一些常量。
    /// </summary>
    public static class AbpConsts
    {
        /// <summary>
        ///     Localization source name of ASP.NET Boilerplate framework.
        /// </summary>
        public const string LocalizationSourceName = "Abp";

        internal static class Orms
        {
            public const string Dapper = "Dapper";
            public const string EntityFramework = "EntityFramework";
            public const string EntityFrameworkCore = "EntityFrameworkCore";
            public const string NHibernate = "NHibernate";
        }
    }
}
