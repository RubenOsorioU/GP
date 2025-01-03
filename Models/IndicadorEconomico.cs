﻿namespace Gestion_Del_Presupuesto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IndicadorEconomico
    {
        [Key]
        public int Id_IndicadorEco { get; set; }
        public int Codigo { get; set; }
        public DateTime? SelectedDate { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }

        // Cambiar a un solo objeto (no una lista)
        public SeriesData Series { get; set; } // Cambio aquí
    }

    public class SeriesData
    {
        [Key]
        public int Id_SeriesData { get; set; }
        public string DescripEsp { get; set; }
        public string DescripIng { get; set; }
        public string SeriesId { get; set; }
        public List<ObsData> Obs { get; set; } = new List<ObsData>();
    }

    public class ObsData
    {
        [Key]
        public string IndexDateString { get; set; }
        public string Value { get; set; }
        public string StatusCode { get; set; }
    }
}
