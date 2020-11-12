using MaterialDesignThemes.Wpf;
using MoFish.Core.Interfaces;
using MoFish.Views;
using System.Threading.Tasks;

namespace MoFish.ViewCenter.Impl
{
    public class MsgCenter : IMsg
    {
        public async Task<bool> Show(object obj)
        {
            object result = await DialogHost.Show(new MsgView()
            {
                DataContext = new { obj }
            }, "Root");
            return (bool)result;
        }
    }
}
