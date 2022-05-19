using SmartTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartTracker.ViewModel
{
    class WeatherViewModel
    {
        private IList<OneCallAPI> _weatherList;
        public IList<OneCallAPI> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<OneCallAPI>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
            var weather = await WeatherAPI.GetOneCallAPIAsync(14.0940, 120.6890, "metric");
            WeatherList.Add(weather);
        }

        public WeatherViewModel()
        {
            Task.Run(APIAsync);
        }
    }
}
