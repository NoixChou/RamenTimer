using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace RamenTimer
{
    internal class TimerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TimerViewModel(uint initialTimeMillisecond = 10000)
        {
            RemainTimeMillisecond = initialTimeMillisecond;

            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 0, 0, 100), () =>
            {
                int elapsed = (DateTime.Now - _latestDateTime).Milliseconds;
                _latestDateTime = DateTime.Now;

                if (RemainTimeMillisecond < elapsed)
                {
                    RemainTimeMillisecond = 0;
                    return false;
                }

                RemainTimeMillisecond -= (uint)elapsed;
                return true;
            });
        }

        private uint _remainTimeMillisecond;
        private uint RemainTimeMillisecond
        {
            get => _remainTimeMillisecond;
            set
            {
                _remainTimeMillisecond = value;

                var format = @"mm\:ss";

                if (_remainTimeMillisecond >= 3600000)
                {
                    format = @"hh\:mm\:ss";
                }

                RemainTimeLabel = TimeSpan.FromMilliseconds(RemainTimeMillisecond).ToString(format);
            }
        }
        private DateTime _latestDateTime = DateTime.Now;

        private string _remainTimeLabel;
        public string RemainTimeLabel
        {
            get => _remainTimeLabel;
            set
            {
                if (_remainTimeLabel == value) return;

                _remainTimeLabel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RemainTimeLabel"));
            }
        }

        public void DecreaseRemain(uint amountMillisecond)
        {
            if (RemainTimeMillisecond < amountMillisecond) return;

            RemainTimeMillisecond -= amountMillisecond;
        }

        public void IncreaseRemain(uint amountMillisecond)
        {
            RemainTimeMillisecond += amountMillisecond;
        }
    }
}