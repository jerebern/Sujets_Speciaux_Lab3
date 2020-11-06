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

            return Math.Round(((c * 9) / 5 + 32), 1);
        }
        public static double FahrenheitInCelsiu(double f)
        {

            return Math.Round(((f - 32) * 5 / 9), 1); ;
        }
        public async void GetTemp(string obj)
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }
        public bool CanGetTemp(string obj)
        {
            if(TemperatureService == null)
                return false;
            else
                return true;
        }
    }
}
