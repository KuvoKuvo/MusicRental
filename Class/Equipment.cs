using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRental.Class
{
    public class Equipment
    {
        [Key]
        public string Article { get; set; }
        public string Name { get; set; }
        public int RentalUnitID { get; set; }
        public decimal RentalCost { get; set; }
        public int SupplierID { get; set; }
        public int MakerID { get; set; }
        public int TypeID { get; set; }
        public decimal Discount { get; set; }
        public int AvailableQuantity { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Maker Maker { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual RentalUnit RentalUnit { get; set; }

        public string ImagePath
        {
            get
            {
                if (string.IsNullOrEmpty(Photo))
                    return null;
                return $"/Images/{Photo}";
            }
        }
    }
}
