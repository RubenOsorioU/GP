namespace Gestion_Del_Presupuesto.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IndicadorEconomico
    {
       
        public int Codigo { get; set; }

        public DateTime? SelectedDate {get; set; }
        public string Descripcion { get; set; }
        public SeriesData Series { get; set; }
        public List<object> SeriesInfos { get; set; }
    }

    public class SeriesData
    {
        public string DescripEsp { get; set; }
        public string DescripIng { get; set; }
        public string SeriesId { get; set; }
        public List<ObsData> Obs { get; set; }
    }

    public class ObsData
    {
        [Key]
        public string IndexDateString { get; set; }
        public string Value { get; set; }
        public string StatusCode { get; set; }
    }

}
