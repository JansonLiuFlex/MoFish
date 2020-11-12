using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using MoFish.Core.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoFish.ViewModel.ViewModels
{
    /// <summary>
    /// 首页模块
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            Bills = new ObservableCollection<Bill>();
            for (int i = 0; i < 13; i++)
            {
                Bills.Add(new Bill()
                {
                    Remark = "公益活动",
                    Name = "参与社区活动",
                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    Amount = 3000
                });
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "收入",
                    Values = new ChartValues<double> { 5674, 7842, 4648, 8574 ,7973 },
                },
                new LineSeries
                {
                    Title = "支出",
                    Values = new ChartValues<double> { 7346, 5757, 9213, 11435 ,16708 },
                }
            };
            Labels = new[] { "2020-01", "2020-02", "2020-03", "2020-04", "2020-05" };
            YFormatter = value => value.ToString("C");
        }

        public string SelectPageTitle { get; } = "首页";

        private ObservableCollection<Bill> bills;

        public ObservableCollection<Bill> Bills
        {
            get { return bills; }
            set { bills = value; RaisePropertyChanged(); }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
