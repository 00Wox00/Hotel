using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelWpf
{
    public class HotelRoom : INotifyPropertyChanged
    {
        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _number = "101";
        public string Number
        {
            get => _number;
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _category = "Стандарт";
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _pricePerDay = 3000;
        public int PricePerDay
        {
            get => _pricePerDay;
            set
            {
                if (_pricePerDay != value)
                {
                    _pricePerDay = value;
                    OnPropertyChanged();
                    OnPropertyChanged("TotalCost");
                }
            }
        }

        private int _days = 1;
        public int Days
        {
            get => _days;
            set
            {
                if (_days != value)
                {
                    _days = value;
                    OnPropertyChanged();
                    OnPropertyChanged("TotalCost");
                }
            }
        }

        public int TotalCost => PricePerDay * Days;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}