using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class Property
    {
        public int Id { get; set; }
        public bool ForLease { get; set; }
        public bool ForSale { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RentalPrice { get; set; }
        public int BuildingSize { get; set; }
        public int OfficeSize { get; set; }
        public int MinUnits { get; set; }
        public int MaxUnits { get; set; }
        public int Floors { get; set; }
        public int YearBuilt { get; set; }
        public decimal LotSize { get; set; }
        public int ParkingSpaces { get; set; }
        public string ApnParcelId { get; set; }
        public int DockHighDoors { get; set; }
        public int GroundLevelDoors { get; set; }
        public DateTime ForSaleSince { get; set; }
        public DateTime AvailForLease { get; set; }
        public DateTime LeaseEnd { get; set; }
        public int LeaseAreaSize { get; set; }
        public int LeaseFloor { get; set; }
        public string LeaseUnitNumber { get; set; }
        public string BrochureFileName { get; set; }
        public int PropertyTypeId { get; set; }
        public int PropertySubTypeId { get; set; }
        public int SaleTypeId { get; set; }

        public PropertyType PropertyType { get; set; }
        public PropertySubType PropertySubType { get; set; }
        public SaleType SaleType { get; set; }
        public List<PropertyAndUserLink> UserLinks { get; set; }
        public List<PropertyPicture> PropertyPictures { get; set; }
    }
}
