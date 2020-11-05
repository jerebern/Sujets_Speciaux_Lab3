using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
        /// 
        public ITemperatureService TemperatureService;

        public DelegateCommand<string> GetTempCommand { get; set; }

        public TemperatureModel CurrentTemp { get; set; }

        public TemperatureViewModel()
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp,CanGetTemp);
        }


       private void SetTemperatureService(ITemperatureService temperature)
        {
            this.TemperatureService = temperature;
        }
      private double CelsiusInFahrenheit(double c)
        {
            //TODO to change
            return c;
        }
        private double FahrenheitInCelsiu(double f)
        {
            //TODO to change
            return f;
        }
        private async void GetTemp(string obj)
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }
        private bool CanGetTemp(string obj)
        {
            if(TemperatureService != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
