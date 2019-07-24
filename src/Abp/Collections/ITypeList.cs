using System;
using System.Collections.Generic;

namespace Abp.Collections
{
    /// <summary>
    /// A shortcut for <see cref="ITypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {

    }

    /// <summary>
    /// 扩展 <see cref="IList{Type}"/> 添加限制特定的基本类型。
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="Type"/>s in this list</typeparam>
    public interface ITypeList<in TBaseType> : IList<Type>
    {
        /// <summary>
        /// Adds a type to list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// Checks if a type exists in the list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// Removes a type from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : TBaseType;
    }
}