using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoFish.Core.Interfaces
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// 询问
        /// </summary>
        /// <param name="msg">内容</param>
        Task<bool> Show(object obj);
    }
}
