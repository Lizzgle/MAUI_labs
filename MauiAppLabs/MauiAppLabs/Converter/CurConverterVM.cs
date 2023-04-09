﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NbrbAPI.Models;

namespace MauiAppLabs.Converter
{
    public class CurConverterVM : INotifyPropertyChanged
    {
        private static List<string> requiredCur = new List<string>() {
        "USD", "RUB", "CHF", "EUR", "CNY", "GBP" };

        private IRateService rateService;

        private List<Rate> rates; //привязываем к Picker (в Picker указываем свойство Cur_Name)

        //public ObservableCollection<Rate> Rates { get; set; }
        public List<Rate> Rates
        {
            get => rates;
            set
            {
                if (value != rates)
                {
                    rates = value;
                    OnPropertyChanged();
                }
            }
        }

        private Rate curRate;

        public Rate CurRate
        {
            get => curRate;
            set
            {
                if (value != curRate)
                {
                    curRate = value;
                    OnPropertyChanged();
                }
            }
        }

        private System.DateTime date;

        private decimal? belValue;

        public decimal? BelValue
        {
            get => belValue;
            set
            {
                if (value != belValue && value is not null)
                {
                    belValue = value < 0 ? decimal.Negate((decimal)value) : value;
                    OnPropertyChanged();
                }

                if (value is null)
                    belValue = value;
            }
        }

        private decimal? foreignValue;

        public decimal? ForeignValue
        {
            get => foreignValue;
            set
            {
                if (value != foreignValue && value is not null)
                {
                    foreignValue = value < 0 ? decimal.Negate((decimal)value) : value;
                    OnPropertyChanged();
                }

                if (value is null)
                    foreignValue = value;
            }
        }

        public CurConverterVM(IRateService rateService)
        {
            this.rateService = rateService;
            date = DateTime.Now;
        }

        public async Task GetNBRBRates(DateTime selectedDate)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var allRates = await rateService.GetRates(selectedDate);
                date = selectedDate;

                //Rates = new ObservableCollection<Rate>(allRates.Where(r => requiredCur.Contains(r.Cur_Abbreviation)));
                Rates = allRates.Where(r => requiredCur.Contains(r.Cur_Abbreviation)).ToList<Rate>();
            }
            else
            {
                throw new Exception("Internet access has been lost.");
            }
        }

        public void InputBel()
        {
            if (CurRate is not null && CurRate.Cur_OfficialRate is not null
                        && belValue is not null)
            {
                ForeignValue = Math.Round((decimal)belValue * CurRate.Cur_Scale
                                                / (decimal)CurRate.Cur_OfficialRate, 2);
            }
            else
            {
                BelValue = Decimal.Zero;
                ForeignValue = Decimal.Zero;
            }
        }

        public void InputForeign()
        {
            if (CurRate is not null && CurRate.Cur_OfficialRate is not null
                        && foreignValue is not null)
            {
                BelValue = Math.Round((decimal)foreignValue * (decimal)CurRate.Cur_OfficialRate
                                                    / CurRate.Cur_Scale, 2);
            }
            else
            {
                BelValue = Decimal.Zero;
                ForeignValue = Decimal.Zero;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
