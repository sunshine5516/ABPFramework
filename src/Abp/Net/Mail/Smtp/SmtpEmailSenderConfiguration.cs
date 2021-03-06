﻿using Abp.Configuration;
using Abp.Dependency;

namespace Abp.Net.Mail.Smtp
{
    /// <summary>
    /// 用来读取设置的支持Smtp协议邮件相关参数项。
    /// from <see cref="ISettingManager"/>.
    /// </summary>
    public class SmtpEmailSenderConfiguration : EmailSenderConfiguration, ISmtpEmailSenderConfiguration, ITransientDependency
    {
        /// <summary>
        /// SMTP主机
        /// </summary>
        public virtual string Host
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.Host); }
        }

        /// <summary>
        /// SMTP端口号
        /// </summary>
        public virtual int Port
        {
            get { return SettingManager.GetSettingValue<int>(EmailSettingNames.Smtp.Port); }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.UserName); }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password
        {
            get { return GetNotEmptySettingValue(EmailSettingNames.Smtp.Password); }
        }

        /// <summary>
        /// 登录到SMTP服务器的域名
        /// </summary>
        public virtual string Domain
        {
            get { return SettingManager.GetSettingValue(EmailSettingNames.Smtp.Domain); }
        }

        /// <summary>
        /// 是否启用SSL?
        /// </summary>
        public virtual bool EnableSsl
        {
            get { return SettingManager.GetSettingValue<bool>(EmailSettingNames.Smtp.EnableSsl); }
        }

        /// <summary>
        /// 使用默认凭据?
        /// </summary>
        public virtual bool UseDefaultCredentials
        {
            get { return SettingManager.GetSettingValue<bool>(EmailSettingNames.Smtp.UseDefaultCredentials); }
        }

        /// <summary>
        /// Creates a new <see cref="SmtpEmailSenderConfiguration"/>.
        /// </summary>
        /// <param name="settingManager">Setting manager</param>
        public SmtpEmailSenderConfiguration(ISettingManager settingManager)
            : base(settingManager)
        {

        }
    }
}