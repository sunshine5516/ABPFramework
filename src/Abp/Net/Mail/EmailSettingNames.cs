namespace Abp.Net.Mail
{
    /// <summary>
    /// 静态常量类，主要定义了发送邮件需要的相关参数：Port、Host、
    /// UserName、Password、Domain、EnableSsl、UseDefaultCredentials。
    /// </summary>
    public static class EmailSettingNames
    {
        /// <summary>
        /// 默认地址
        /// </summary>
        public const string DefaultFromAddress = "Abp.Net.Mail.DefaultFromAddress";

        /// <summary>
        /// 默认名称
        /// </summary>
        public const string DefaultFromDisplayName = "Abp.Net.Mail.DefaultFromDisplayName";

        /// <summary>
        /// SMTP相关电子邮件设置。
        /// </summary>
        public static class Smtp
        {
            /// <summary>
            /// Abp.Net.Mail.Smtp.Host
            /// </summary>
            public const string Host = "Abp.Net.Mail.Smtp.Host";

            /// <summary>
            /// Abp.Net.Mail.Smtp.Port
            /// </summary>
            public const string Port = "Abp.Net.Mail.Smtp.Port";

            /// <summary>
            /// 用户名
            /// </summary>
            public const string UserName = "Abp.Net.Mail.Smtp.UserName";

            /// <summary>
            /// 密码
            /// </summary>
            public const string Password = "Abp.Net.Mail.Smtp.Password";

            /// <summary>
            /// Abp.Net.Mail.Smtp.Domain
            /// </summary>
            public const string Domain = "Abp.Net.Mail.Smtp.Domain";

            /// <summary>
            /// EnableSsl
            /// </summary>
            public const string EnableSsl = "Abp.Net.Mail.Smtp.EnableSsl";

            /// <summary>
            /// 默认凭证
            /// </summary>
            public const string UseDefaultCredentials = "Abp.Net.Mail.Smtp.UseDefaultCredentials";
        }
    }
}