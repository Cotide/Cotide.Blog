#region using

using System;
using System.Reflection;

#endregion

namespace Cotide.Framework.Extensions
{
    /// <summary>
    /// ������չ������
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// ��ȡĳ������
        /// </summary>
        /// <typeparam name="TAttribute">��������</typeparam>
        /// <param name="member">����</param>
        /// <returns>��������(�����ڼ�����null)</returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
        {
            var attributes = member.GetCustomAttributes(typeof (TAttribute), true);
            if (attributes != null && attributes.Length > 0)
                return (TAttribute) attributes[0];
            return null;
        }

        /// <summary>
        /// �ж��Ƿ����ĳ������
        /// </summary>
        /// <typeparam name="TAttribute">��������</typeparam>
        /// <param name="member">����</param>
        /// <returns>�Ƿ����</returns>
        public static bool HasAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
        {
            return member.GetAttribute<TAttribute>() != null;
        }
    }
}