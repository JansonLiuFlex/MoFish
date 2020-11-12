using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoFish.Core.Interfaces
{
    public interface IBaseWindow
    {
        /// <summary>
        /// 弹出窗口
        /// </summary>
        Task<bool> ShowDialog();

        /// <summary>
        /// 注册模块事件
        /// </summary>
        void SubscribeEvent();

        /// <summary>
        /// 訂閱消息
        /// </summary>
        void SubscribeMessenger();

        /// <summary>
        /// 取消订阅消息
        /// </summary>
        void UnsubscribeMessenger();
    }
}
