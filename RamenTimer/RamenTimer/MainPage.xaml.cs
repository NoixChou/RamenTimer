using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RamenTimer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void StartTimer(uint second)
        {
            Navigation.PushAsync(new Timer(second * 1000));
        }

        private void ThreeMinButton_OnClicked(object sender, EventArgs e)
        {
            StartTimer(180);
        }

        private void FiveMinButton_OnClicked(object sender, EventArgs e)
        {
            StartTimer(300);
        }

        private void OneMinButton_OnClicked(object sender, EventArgs e)
        {
            StartTimer(60);
        }

        private void FourMinButton_OnClicked(object sender, EventArgs e)
        {
            StartTimer(240);
        }
    }
}
