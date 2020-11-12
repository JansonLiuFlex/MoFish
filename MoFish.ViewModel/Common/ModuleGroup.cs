using GalaSoft.MvvmLight;
using MoFish.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoFish.ViewModel
{
    public class ModuleGroup : ViewModelBase
    {
        private string groupName;
        private string groupIcon;
        private bool isExpand = false;
        private ObservableCollection<Module> modules;

        public bool IsExpand
        {
            get { return isExpand; }
            set { isExpand = value; RaisePropertyChanged(); }
        }


        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; RaisePropertyChanged(); }
        }

        public string GroupIcon
        {
            get { return groupIcon; }
            set { groupIcon = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 包含的子模块
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(); }
        }
    }
}
