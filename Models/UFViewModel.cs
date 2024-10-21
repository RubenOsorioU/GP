﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class UFCombinedViewModel

    {
        [Key]
        public int Id_ConbinedUF { get; set; }
            public UF2023 UF2023 { get; set; }
            public UF2024 UF2024 { get; set; }
            public string SelectedMonth { get; set; }
            public string SelectedYear { get; set; }
            public int SelectedDay { get; set; }
    }

    public class UFData
    {
        [Key]
        public int Id_UFData { get; set; }
        public DateTime Date { get; set; }
        public decimal UFValue { get; set; }
    }
}