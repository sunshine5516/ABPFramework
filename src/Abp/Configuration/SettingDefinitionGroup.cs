using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Localization;

namespace Abp.Configuration
{
    /// <summary>
    /// 用于给SettingDefinition分组
    /// A group can be child of another group and can have child groups.
    /// </summary>
    public class SettingDefinitionGroup
    {
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 显示名称
        /// 用于展示给用户
        /// </summary>
        public ILocalizableString DisplayName { get; private set; }

        /// <summary>
        /// 父级组
        /// </summary>
        public SettingDefinitionGroup Parent { get; private set; }

        /// <summary>
        /// 获取这个组的所有子列表。
        /// </summary>
        public IReadOnlyList<SettingDefinitionGroup> Children
        {
            get { return _children.ToImmutableList(); }
        }
        private readonly List<SettingDefinitionGroup> _children;

        /// <summary>
        /// 创建<see cref="SettingDefinitionGroup"/> 对象.
        /// </summary>
        /// <param name="name">组的唯一名称</param>
        /// <param name="displayName">显示名称</param>
        public SettingDefinitionGroup(string name, ILocalizableString displayName)
        {
           Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            DisplayName = displayName;
            _children = new List<SettingDefinitionGroup>();
        }

        /// <summary>
        /// 添加子分组
        /// </summary>
        /// <param name="child">Child to be added</param>
        /// <returns>This child group to be able to add more child</returns>
        public SettingDefinitionGroup AddChild(SettingDefinitionGroup child)
        {
            if (child.Parent != null)
            {
                throw new AbpException("Setting group " + child.Name + " has already a Parent (" + child.Parent.Name + ").");
            }

            _children.Add(child);
            child.Parent = this;
            return this;
        }
    }
}