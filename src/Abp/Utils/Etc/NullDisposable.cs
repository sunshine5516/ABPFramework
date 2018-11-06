using System;

namespace Abp.Utils.Etc
{
    /// <summary>
    /// ����ģ�ⲻִ���κβ�����Disposable��
    /// </summary>
    internal sealed class NullDisposable : IDisposable
    {
        public static NullDisposable Instance { get; } = new NullDisposable();

        private NullDisposable()
        {
            
        }

        public void Dispose()
        {

        }
    }
}