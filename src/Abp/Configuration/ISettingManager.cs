using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Configuration
{
    /// <summary>
    /// 管理setting的接口
    /// </summary>
    public interface ISettingManager
    {
        /// <summary>
        /// 获取当前setting.
        /// 获取设置值
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueAsync(string name);

        /// <summary>
        /// 获取应用程序级别的当前设置值。
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForApplicationAsync(string name);

        /// <summary>
        /// 获取应用程序级别的当前设置值
        /// 如果fallbackToDefault为false，它只是从应用程序获取值，如果应用程序尚未为该设置定义值，则返回null。
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="fallbackToDefault"></param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForApplicationAsync(string name, bool fallbackToDefault);

        /// <summary>
        /// 获取租户级别当前的设置的值。
        /// 由给定的租户重写。
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="tenantId">Tenant id</param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForTenantAsync(string name, int tenantId);

        /// <summary>
        /// 获取租户级别当前的设置的值
        /// 如果fallbackToDefault为false，它只是从租户获取值，如果应用程序尚未为该设置定义值，则返回null。
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="tenantId">Tenant id</param>
        /// <param name="fallbackToDefault"></param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForTenantAsync(string name, int tenantId, bool fallbackToDefault);

        /// <summary>
        /// 获取用户级别当前的设置的值
        /// 由给定的租户、用户重写
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="tenantId">Tenant id</param>
        /// <param name="userId">User id</param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForUserAsync(string name, int? tenantId, long userId);

        /// <summary>
        /// 获取用户级别当前的设置的值.
        /// 如果fallbackToDefault为真 由给定的租户、用户重写.
        /// 如果fallbackToDefault为假, 它只是从用户获取值，如果用户没有为该设置定义值，则返回null.
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="tenantId">Tenant id</param>
        /// <param name="userId">User id</param>
        /// <param name="fallbackToDefault"></param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForUserAsync(string name, int? tenantId, long userId, bool fallbackToDefault);

        /// <summary>
        /// 获取用户级别当前的设置的值
        /// 由给定的租户、用户重写
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="user">用户</param>
        /// <returns>当前setting值</returns>
        Task<string> GetSettingValueForUserAsync(string name, UserIdentifier user);

        /// <summary>
        /// 获取所有设置的当前值。
        /// 设置值，由应用程序，当前租户（如果存在）和当前用户（如果存在）重写。
        /// </summary>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync();

        /// <summary>
        /// 获取所有设置的当前值。
        /// 设置值，由应用程序，当前租户（如果存在）和当前用户（如果存在）重写。
        /// </summary>
        /// <param name="scopes">One or more scope to overwrite</param>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(SettingScopes scopes);

        /// <summary>
        /// Gets a list of all setting values specified for the application.
        /// It returns only settings those are explicitly set for the application.
        /// If a setting's default value is used, it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForApplicationAsync();

        /// <summary>
        /// Gets a list of all setting values specified for a tenant.
        /// It returns only settings those are explicitly set for the tenant.
        /// If a setting's default value is used, it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <param name="tenantId">Tenant to get settings</param>
        /// <returns>List of setting values</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForTenantAsync(int tenantId);

        /// <summary>
        /// Gets a list of all setting values specified for a user.
        /// It returns only settings those are explicitly set for the user.
        /// If a setting's value is not set for the user (for example if user uses the default value), it's not included the result list.
        /// If you want to get current values of all settings, use <see cref="GetAllSettingValuesAsync()"/> method.
        /// </summary>
        /// <param name="user">User to get settings</param>
        /// <returns>All settings of the user</returns>
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForUserAsync(UserIdentifier user);

        /// <summary>
        /// Changes setting for the application level.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForApplicationAsync(string name, string value);

        /// <summary>
        /// Changes setting for a Tenant.
        /// </summary>
        /// <param name="tenantId">TenantId</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForTenantAsync(int tenantId, string name, string value);

        /// <summary>
        /// Changes setting for a user.
        /// </summary>
        /// <param name="user">UserId</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task ChangeSettingForUserAsync(UserIdentifier user, string name, string value);
    }
}
