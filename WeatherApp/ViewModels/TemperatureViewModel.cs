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


       public void SetTemperatureService(ITemperatureService temperature)
        {
            this.TemperatureService = temperature;
        }
      public static double CelsiusInFahrenheit(double c)
        {
            //TODO to change
            return c;
        }
        public static double FahrenheitInCelsiu(double f)
        {
            //TODO to change
            return f;
        }
        public async void GetTemp(string obj)
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }
        public bool CanGetTemp(string obj)
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
