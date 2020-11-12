using MoFish.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MoFish.ViewCenter
{
    /// <summary>
    /// 用户控件基类 (无业务)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class BaseUserControlCenter<TView,TViewModel> : IBaseModule
        where TView : UserControl,new()
        where TViewModel : class, new()
    {
     
        public readonly TView view = new TView();

        public readonly TViewModel viewModel = new TViewModel();

        public void BindDataGridColumns()
        {
        }

        public void BindDefaultModel()
        {
            view.DataContext = viewModel;
        }

        public object GetView()
        {
            return view;
        }
    }
    /// <summary>
    /// 用户控件基类 (业务)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class BusinessUserControlCenter<TView, TViewModel> : IBaseModule
        where TView : UserControl, new()
        where TViewModel : class, new()
    {

        public readonly TView view = new TView();

        public readonly TViewModel viewModel = new TViewModel();

        public void BindDataGridColumns()
        {
        }

        public void BindDefaultModel()
        {
            view.DataContext = viewModel;
        }

        public object GetView()
        {
            return view;
        }
    }

}
