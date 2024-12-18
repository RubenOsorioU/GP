using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
namespace Gestion_Del_Presupuesto.Models
{
    public class PlanillasModel
    {
        [Key]
        public int Id_Planillas { get; set; }

        // Información del Estudiante
        [Required]
        public string NombresApellidosEstudiante { get; set; }
        [Required]
        public string RunEstudiante { get; set; }

        // Fechas de Práctica
        [Required]
        public DateTime FechaInicioPractica { get; set; }
        [Required]
        public DateTime FechaTerminoPractica { get; set; }

        // Información Institucional
        [Required]
        public string Institucion { get; set; }
        public string Servicio { get; set; }
        public string Area { get; set; }
        public string Nivel { get; set; }

        // Códigos de Clasificación
        public string CodigoNivel { get; set; } // ASD, ASR, ATD, ATR, etc.
        public string TipoPrograma { get; set; } // PSC, TCL, EP, DOC
        public string TipoSeccion { get; set; } // TEO, LAB, EJE, SIN
        public string Seccion { get; set; }
        public int InscritosSeccion { get; set; }

        // Información de Turnos y Horas
        public string TipoTurno { get; set; }
        public int NumeroSemanas { get; set; }
        public double HorasMensuales { get; set; }

        // Valores Económicos
        public double ValorUFMes { get; set; }
        public double ValorUFSemana { get; set; }
        public double ValorTotalUF { get; set; }
        public decimal ValorPesos { get; set; }
        public decimal MontoMensual { get; set; }

        // Información del Docente Clínico
        public string RunDocenteClinico { get; set; }
        public string DVDocenteClinico { get; set; }
        public string NombreDocenteClinico { get; set; }

        // Información Administrativa
        public string CodigoCentroCosto { get; set; }
        public string CodigoAsignatura { get; set; }
        public string ItemPresupuestario { get; set; }
        public string Cohorte { get; set; }
        public string Descripcion { get; set; }

        // Relaciones existentes
        public int CarreraId { get; set; }
        public virtual CarreraModel Carrera { get; set; }
        public bool Eliminado { get; set; }

        // Otras relaciones
        public int FacturacionId { get; set; }
        public virtual FacturacionModel Facturacion { get; set; }
        public virtual Devengado Devengado { get; set; }
        public int Id_IndicadorEco { get; set; }
        public virtual IndicadorEconomico Indicador { get; set; }
        public ICollection<EstudiantePlanillaModel> EstudiantePlanillas { get; set; }
    }
    
}