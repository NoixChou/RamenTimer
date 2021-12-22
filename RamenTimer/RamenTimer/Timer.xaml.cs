using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RamenTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer : ContentPage
    {
        private TimerViewModel timerViewModel;

        public Timer(uint millisecond)
        {
            InitializeComponent();

            timerViewModel = new TimerViewModel(millisecond);
            BindingContext = timerViewModel;
        }

        ~Timer()
        {
            timerViewModel = null;
        }

        private void DecreaseTimerRemain(uint amountSecond)
        {
            timerViewModel.DecreaseRemain(amountSecond * 1000);
        }

        private void IncreaseTimerRemain(uint amountSecond)
        {
            timerViewModel.IncreaseRemain(amountSecond * 1000);
        }

        private void StopButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void DecreaseOneMinute_OnClicked(object sender, EventArgs e)
        {
            DecreaseTimerRemain(60);
        }

        private void IncreaseOneMinute_OnClicked(object sender, EventArgs e)
        {
            IncreaseTimerRemain(60);
        }

        private void DecreaseHalfMinute_OnClicked(object sender, EventArgs e)
        {
            DecreaseTimerRemain(30);
        }

        private void IncreaseHalfMinute_OnClicked(object sender, EventArgs e)
        {
            IncreaseTimerRemain(30);
        }
    }
}