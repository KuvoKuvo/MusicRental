using Microsoft.EntityFrameworkCore;
using MusicRental.Class;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicRental;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Equipment> Products { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        LoadData();
        DataContext = this;
    }

    private void LoadData()
    {
        using (var context = new AppDbContext())
        {
            // Загружаем оборудование с связанными данными
            var equipment = context.Equipment
                .Include(e => e.EquipmentType)
                .Include(e => e.Maker)
                .Include(e => e.Supplier)
                .Include(e => e.RentalUnit)
                .ToList();

            foreach (var item in equipment)
            {
                Console.WriteLine($"Photo: {item.Photo}");
                Console.WriteLine($"ImagePath: {item.ImagePath}");
            }

            Products = new ObservableCollection<Equipment>(equipment);
        }
    }
}