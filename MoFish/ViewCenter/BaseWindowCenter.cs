using GalaSoft.MvvmLight.Messaging;
using MoFish.Core.Interfaces;
using MoFish.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MoFish.ViewCenter
{
    /// <summary>
    /// Window基类
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class BaseWindowCenter<TView, TViewModel> : IBaseWindow
        where TView : Window, new()
        where TViewModel : class, new()
    {
        public readonly TView view = new TView();
        public readonly TViewModel viewModel = new TViewModel();

        /// <summary>
        /// 绑定默认ViewModel
        /// </summary>
        protected void BindDefaultViewModel()
        {
            view.DataContext = viewModel;
        }

        public virtual async Task<bool> ShowDialog()
        {
            this.SubscribeMessenger();
            this.SubscribeEvent();
            this.BindDefaultViewModel();
            var result = view.ShowDialog();
            return await Task.FromResult((bool)result);
        }

        public void SubscribeEvent()
        {
            view.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    view.DragMove();
            };
        }

        public virtual void SubscribeMessenger()
        {
            //最小化
            Messenger.Default.Register<string>(view, "WindowMinimize", arg =>
            {
                view.WindowState = System.Windows.WindowState.Minimized;
            });
            //最大化
            Messenger.Default.Register<string>(view, "WindowMaximize", arg =>
            {
                if (view.WindowState == System.Windows.WindowState.Maximized)
                    view.WindowState = System.Windows.WindowState.Normal;
                else
                    view.WindowState = System.Windows.WindowState.Maximized;
            });
            //关闭系统
            Messenger.Default.Register<bool>(view, "Exit", async r =>
            {
                if (r)
                    if (!await Msg.Question("确认退出系统?")) return;
                Environment.Exit(0);
            });
        }

        public void UnsubscribeMessenger()
        {
            Messenger.Default.Unregister(view);
        }
    }
}
