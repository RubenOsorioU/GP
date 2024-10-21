using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class ConveniosModel
    {
        [Key]
        public int Id_Convenio { get; set; }  // Clave primaria del convenio

        [Required]
        [Display(Name = "Contratos Instituciones")]
        public string ContratosInstituciones { get; set; }  // Nombre de la institución (Hospital Barros Luco, etc.)

        [Required]
        [Display(Name = "Tipo de Institución")]
        public string Categoria { get; set; }  // Categoría a la que pertenece (Hospitales_Clinicas, Atencion_primaria, etc.)

        [Display(Name = "Nº Estudiantes")]
        public int? NumeroEstudiantes { get; set; }  // Número de estudiantes vinculados al convenio

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
        public decimal? TotalGastoEstimado { get; set; }  // Suma de todos los pagos esperados

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

        [Display(Name = "Estado del Convenio")]
        public string Estado { get; set; }
        [Display(Name = "Retribuciones")]
        public ICollection<Retribucion> Retribuciones { get; set; }
        public virtual ICollection<PlanillasModel> Planillas { get; set; }
    }
}
