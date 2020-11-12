using GalaSoft.MvvmLight;
using MoFish.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoFish.ViewModel
{
    public class ModuleManager : ViewModelBase
    {
        public ModuleManager()
        {
            InitModules();
        }


        private ObservableCollection<Module> modules;
        /// <summary>
        /// 已加载模块
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ModuleGroup> moduleGroups;

        /// <summary>
        /// 已加载模块-分组
        /// </summary>
        public ObservableCollection<ModuleGroup> ModuleGroups
        {
            get { return moduleGroups; }
            set { moduleGroups = value; RaisePropertyChanged(); }
        }

        private readonly string[] IconList = new string[] { "StorefrontOutline", "Tags", "Spa" , "ElectronFramework", "React" };

        public void InitModules()
        {
            Modules = new ObservableCollection<Module> {
                    new Module
                    {
                        Name = "系统管理1",
                        Code = "\ue6a4",
                        TypeName = "DashBoardCenter"

                    },
                    new Module
                    {
                        Name = "系统管理2",
                        Code = "\ue66a",
                        TypeName = "DashBoardCenter"

                    },
                    new Module
                    {
                        Name = "文件导入",
                        Code = "\ue69f",
                        TypeName = "DashBoardCenter"
                    },
                    new Module
                    {
                        Name = "文件导出",
                        Code = "\ue6a0",
                        TypeName = "DashBoardCenter"
                    }
            };
            ModuleGroups = new ObservableCollection<ModuleGroup>();

            ModuleGroups.Add(new ModuleGroup()
            {
                GroupName = "首页菜单",
                GroupIcon = IconList[0],
                Modules = new ObservableCollection<Module>
                {
                   new Module
                    {
                        Name = "首页",
                        Code = "\ue69d"
                    }
                }
            });

            ModuleGroups.Add(new ModuleGroup()
            {
                GroupName = "系统管理",
                GroupIcon = IconList[1],
                Modules = new ObservableCollection<Module>
                {
                    new Module
                    {
                        Name = "系统管理1",
                        Code = "\ue6a4",

                    },
                    new Module
                    {
                        Name = "系统管理2",
                        Code = "\ue66a",

                    }
                }
            });

            ModuleGroups.Add(new ModuleGroup()
            {
                GroupName = "设置",
                GroupIcon = IconList[2],
                Modules = new ObservableCollection<Module>
                {
                   new Module
                    {
                        Name = "文件导入",
                        Code = "\ue69f",

                    },
                    new Module
                    {
                        Name = "文件导出",
                        Code = "\ue6a0",

                    }
                }
            });

        }

    }
}
