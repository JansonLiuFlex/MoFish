using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using MoFish.Common.Utils;
using MoFish.Core.AOP;
using MoFish.Core.Interfaces;
using MoFish.Core.IOC;
using MoFish.Template;
using MoFish.ViewModel.Common;
using MoFish.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MoFish.ViewCenter.Impl
{
    /// <summary>
    /// 首页控制类
    /// </summary>
    public class MainCenter : BaseWindowCenter<MainWindow,MainViewModel>
    {
        public override void SubscribeMessenger()
        {
            //非阻塞式窗口提示消息
            Messenger.Default.Register<string>(view, "Snackbar", arg =>
            {
                var messageQueue = view.SnackbarThree.MessageQueue;
                messageQueue.Enqueue(arg);
            });
            //阻塞式窗口提示消息
            Messenger.Default.Register<MsgInfo>(view, "UpdateDialog", m =>
            {
                if (m.IsOpen)
                    _ = DialogHost.Show(new SplashScreenView()
                    {
                        DataContext = new { Msg = m.Msg }
                    }, "Root");
                else
                {
                    DialogHost.Close("Root");
                }
            });
            //菜单执行相关动画及模板切换
            Messenger.Default.Register<string>(view, "ExpandMenu", arg =>
            {
                if (view.Menu.Width < 200)
                    AnimationHelper.CreateWidthChangedAnimation(view.Menu, 60, 200, new TimeSpan(0, 0, 0, 0, 300));
                else
                    AnimationHelper.CreateWidthChangedAnimation(view.Menu, 200, 60, new TimeSpan(0, 0, 0, 0, 300));

                //由于...
                var template = view.IC.ItemTemplateSelector;
                view.IC.ItemTemplateSelector = null;
                view.IC.ItemTemplateSelector = template;
            });
            Messenger.Default.Register<string>(view, "OpenPage", OpenPage);
            Messenger.Default.Register<string>(view, "ClosePage", ClosePage);
            base.SubscribeMessenger();
        }

        /// <summary>
        /// 打开新页面
        /// </summary>
        /// <param name="pageName"></param>
        [GlobalProcess]
        public virtual void OpenPage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName)) return;
            var pageModule = viewModel.ModuleManager.Modules.FirstOrDefault(t => t.Name.Equals(pageName));
            if (pageModule == null) return;

            var module = viewModel.ModuleList.FirstOrDefault(t => t.Name == pageModule.Name);
            if (module == null)
            {
                IBaseModule dialog = ServiceProvider.Get<IBaseModule>(pageModule.TypeName);
                dialog.BindDefaultModel();
                viewModel.ModuleList.Add(new ModuleUIComponent()
                {
                    Code = pageModule.Code,
                    Name = pageModule.Name,
                    TypeName = pageModule.TypeName,
                    Body = dialog.GetView()
                });
                viewModel.CurrentModule = viewModel.ModuleList.Last();
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
            }
            else
                viewModel.CurrentModule = module;
        }


        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="pageName"></param>
        public void ClosePage(string pageName)
        {
            var module = viewModel.ModuleList.FirstOrDefault(t => t.Name.Equals(pageName));
            if (module != null)
            {
                viewModel.ModuleList.Remove(module);
                if (viewModel.ModuleList.Count > 0)
                    viewModel.CurrentModule = viewModel.ModuleList.Last();
                else
                    viewModel.CurrentModule = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
            }
        }

        /// <summary>
        /// 首页重写弹窗
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> ShowDialog()
        {
            viewModel.InitDefaultView();
            return await base.ShowDialog();
        }
    }
}
