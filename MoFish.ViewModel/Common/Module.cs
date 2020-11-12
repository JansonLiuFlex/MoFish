using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoFish.ViewModel.Common
{
    public class Module : ViewModelBase
    {
        private string code;
        private string name;
        private string typeName;

        /// <summary>
        /// 模块图标代码 ttf
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 模块命名空间
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; RaisePropertyChanged(); }
        }
    }


    /// <summary>
    /// 模块UI组件
    /// </summary>
    public class ModuleUIComponent : Module
    {
        private object body;

        /// <summary>
        /// 页面内容
        /// </summary>
        public object Body
        {
            get { return body; }
            set { body = value; RaisePropertyChanged(); }
        }
    }
}
