using AspectInjector.Broker;
using GalaSoft.MvvmLight.Messaging;
using MoFish.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoFish.Core.AOP
{
    [Aspect(Scope.Global)]
    [Injection(typeof(GlobalProcess))]
    public class GlobalProcess : Attribute
    {
        [Advice(Kind.Before, Targets = Target.Method)]
        public void Start([Argument(Source.Name)] string name)
        {

            UpdateLoading(true);
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public async void End([Argument(Source.Name)] string name)
        {
            await Task.Delay(300);
            UpdateLoading(false);
        }

        void UpdateLoading(bool isOpen,string msg = "Loading...")
        {
            Messenger.Default.Send(new MsgInfo()
            {
                IsOpen = isOpen,
                Msg = msg
            },"UpdateDialog");
        }
    }
}
