using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Models
{

    public class CargoResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Cargo> Cargos { get; set; } = new();
    }

    /// <summary>
    /// Represents a cargo entity.
    /// </summary>
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage ="CargoName is Required.")]
        public string CargoName { get; set; } = string.Empty;
        public string cargoCompanyId { get; set; } = "1";
        public string cargoAddByUserId { get; set; } = "1";
        public string cargoUpdatedByUserId { get; set; } = "1";


        public string CargoType { get; set; } = string.Empty;
        public string CargoRemarks { get; set; } = string.Empty;
        public string CargoHsn { get; set; } = string.Empty;
        public int CargoStatus { get; set; }
    }
}
