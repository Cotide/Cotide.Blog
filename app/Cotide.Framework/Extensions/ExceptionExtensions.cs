using System;

namespace Cotide.Framework.Extensions
{
    /// <summary>
    ///  �ַ���������
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// ��ȡ�ڲ��쳣
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetInnerException<T>(this Exception ex) where T : Exception
        {
            if(ex is T)
            {
                return ex;
            }
            var rsult = ex;
            var find = false;
            while (rsult.InnerException != null)
            {
                rsult = rsult.InnerException;
                if (!(rsult is T)) continue;
                find = true;
                break;
            }
            return find ? rsult : null;
        }
    }
}