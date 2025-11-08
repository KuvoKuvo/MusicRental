using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRental
{
    public class Equipment : INotifyPropertyChanged
    {
        private string _name;
        private string _equipmentType;
        private string _manufacturer;
        private string _supplier;
        private string _rentalUnit;
        private string _description;
        private decimal _rentalPrice;
        private int _discount;
        private string _imagePath;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string EquipmentType
        {
            get => _equipmentType;
            set { _equipmentType = value; OnPropertyChanged(nameof(EquipmentType)); }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set { _manufacturer = value; OnPropertyChanged(nameof(Manufacturer)); }
        }

        public string Supplier
        {
            get => _supplier;
            set { _supplier = value; OnPropertyChanged(nameof(Supplier)); }
        }

        public string RentalUnit
        {
            get => _rentalUnit;
            set { _rentalUnit = value; OnPropertyChanged(nameof(RentalUnit)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public decimal RentalPrice
        {
            get => _rentalPrice;
            set { _rentalPrice = value; OnPropertyChanged(nameof(RentalPrice)); }
        }

        public int Discount
        {
            get => _discount;
            set { _discount = value; OnPropertyChanged(nameof(Discount)); }
        }

        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel
    {
        public ObservableCollection<Equipment> Products { get; set; }
        public MainViewModel()
        {
            Products = new ObservableCollection<Equipment>
            {
                new Equipment
                {
                    Name = "Экскаватор-погрузчик JCB 3CX",
                    EquipmentType = "Строительная техника",
                    Manufacturer = "JCB",
                    Supplier = "ООО 'СтройТех'",
                    RentalUnit = "смена (8 часов)",
                    Description = "Многофункциональная строительная машина для земляных работ и погрузки материалов. Оснащен ковшом и обратной лопатой.",
                    RentalPrice = 15000,
                    Discount = 15,
                    ImagePath = "images/excavator.jpg"
                },
                new Equipment
                {
                    Name = "Бетономешалка SBM 125L",
                    EquipmentType = "Бетоносмесительное оборудование",
                    Manufacturer = "SBM",
                    Supplier = "ЗАО 'Строительные решения'",
                    RentalUnit = "сутки",
                    Description = "Профессиональная бетономешалка объемом 125 литров. Идеально подходит для строительных площадок.",
                    RentalPrice = 2500,
                    Discount = 10,
                    ImagePath = "images/concrete_mixer.jpg"
                }
            };
        }
    }
}
