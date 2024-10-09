using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class DetalleGeneralModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contratos Instituciones")]
        public string ContratosInstituciones { get; set; }

        [Required]
        [Display(Name = "Tipo de Institución")]
        public string TipoInstitucion { get; set; }

        [Display(Name = "Nº Estudiantes")]
        public int? NumeroEstudiantes { get; set; }

        [Display(Name = "Pago por Uso de CC $$")]
        public decimal? PagoUsoCC { get; set; }
        public bool PagoUsoCCSelected { get; set; }

        [Display(Name = "Pago Apoyo a la Docencia")]
        public decimal? PagoApoyoDocencia { get; set; }
        public bool PagoApoyoDocenciaSelected { get; set; }

        [Display(Name = "Pago en RRHH")]
        public decimal? PagoRRHH { get; set; }
        public bool PagoRRHHSelected { get; set; }

        [Display(Name = "Capacitación")]
        public decimal? Capacitacion { get; set; }
        public bool CapacitacionSelected { get; set; }

        [Display(Name = "Obras Menores")]
        public decimal? ObrasMenores { get; set; }
        public bool ObrasMenoresSelected { get; set; }

        [Display(Name = "Obras Mayores")]
        public decimal? ObrasMayores { get; set; }
        public bool ObrasMayoresSelected { get; set; }

        [Display(Name = "Otros Gastos x retribución")]
        public decimal? OtrosGastosRetribucion { get; set; }
        public bool OtrosGastosRetribucionSelected { get; set; }

        [Display(Name = "Total Gasto estimado 2025")]
        public decimal? TotalGastoEstimado { get; set; }

        [Display(Name = "Deuda 2020, 2021, 2022, 2023")]
        public decimal? DeudaAnteriores { get; set; }

        [Display(Name = "Deuda 2024")]
        public decimal? Deuda2024 { get; set; }

        [Display(Name = "TOTAL DEUDA")]
        public decimal? TotalDeuda { get; set; }

        [Display(Name = "Facturado 2025 corresp 2020,2021,2022, 2023")]
        public decimal? FacturadoAnteriores { get; set; }

        [Display(Name = "Facturado 2025 corresp 2024")]
        public decimal? Facturado2024 { get; set; }

        [Display(Name = "Facturado 2025 corresp 2025")]
        public decimal? Facturado2025 { get; set; }

        [Display(Name = "TOTAL FACTURADO Y ENVIADO A PAGO")]
        public decimal? TotalFacturado { get; set; }

        [Display(Name = "Saldo Estimado x pagar 2025")]
        public decimal? SaldoEstimadoPagar { get; set; }
    }
}