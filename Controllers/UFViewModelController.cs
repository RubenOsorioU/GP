using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class UFViewModelController : Controller
    {
        public IActionResult Index(string selectedMonth, int? selectedYear)
        {
            var model = new UFViewModel
            {
                SelectedYear = selectedYear ?? DateTime.Now.Year,
                SelectedMonth = selectedMonth ?? "Todos los meses",
                UFValues = ObtenerValoresUF().Where(uf => FiltrarPorMesYAnio(uf, selectedMonth, selectedYear)).ToList()
            };

            return View(model);
        }

        private List<UFData> ObtenerValoresUF()
        {
            return new List<UFData>
    {
            // Enero 2024
            new UFData { Date = new DateTime(2024, 01, 01), UFValue = 36797.64M },
            new UFData { Date = new DateTime(2024, 01, 02), UFValue = 36805.92M },
            new UFData { Date = new DateTime(2024, 01, 03), UFValue = 36814.21M },
            new UFData { Date = new DateTime(2024, 01, 04), UFValue = 36822.49M },
            new UFData { Date = new DateTime(2024, 01, 05), UFValue = 36830.78M },
            new UFData { Date = new DateTime(2024, 01, 06), UFValue = 36839.07M },
            new UFData { Date = new DateTime(2024, 01, 07), UFValue = 36847.36M },
            new UFData { Date = new DateTime(2024, 01, 08), UFValue = 36855.65M },
            new UFData { Date = new DateTime(2024, 01, 09), UFValue = 36863.94M },
            new UFData { Date = new DateTime(2024, 01, 10), UFValue = 36857.98M },
            new UFData { Date = new DateTime(2024, 01, 11), UFValue = 36852.02M },
            new UFData { Date = new DateTime(2024, 01, 12), UFValue = 36846.06M },
            new UFData { Date = new DateTime(2024, 01, 13), UFValue = 36840.10M },
            new UFData { Date = new DateTime(2024, 01, 14), UFValue = 36834.15M },
            new UFData { Date = new DateTime(2024, 01, 15), UFValue = 36828.19M },
            new UFData { Date = new DateTime(2024, 01, 16), UFValue = 36822.24M },
            new UFData { Date = new DateTime(2024, 01, 17), UFValue = 36816.29M },
            new UFData { Date = new DateTime(2024, 01, 18), UFValue = 36810.33M },
            new UFData { Date = new DateTime(2024, 01, 19), UFValue = 36804.38M },
            new UFData { Date = new DateTime(2024, 01, 20), UFValue = 36798.43M },
            new UFData { Date = new DateTime(2024, 01, 21), UFValue = 36792.48M },
            new UFData { Date = new DateTime(2024, 01, 22), UFValue = 36786.53M },
            new UFData { Date = new DateTime(2024, 01, 23), UFValue = 36780.58M },
            new UFData { Date = new DateTime(2024, 01, 24), UFValue = 36774.64M },
            new UFData { Date = new DateTime(2024, 01, 25), UFValue = 36768.69M },
            new UFData { Date = new DateTime(2024, 01, 26), UFValue = 36762.75M },
            new UFData { Date = new DateTime(2024, 01, 27), UFValue = 36756.80M },
            new UFData { Date = new DateTime(2024, 01, 28), UFValue = 36750.86M },
            new UFData { Date = new DateTime(2024, 01, 29), UFValue = 36744.92M },
            new UFData { Date = new DateTime(2024, 01, 30), UFValue = 36738.98M },
            new UFData { Date = new DateTime(2024, 01, 31), UFValue = 36733.04M },

                // 31 días de enero...

                // Febrero 2024 (año bisiesto, 29 días)
            new UFData { Date = new DateTime(2024, 02, 01), UFValue = 36727.10M },
            new UFData { Date = new DateTime(2024, 02, 02), UFValue = 36721.16M },
            new UFData { Date = new DateTime(2024, 02, 03), UFValue = 36715.22M },
            new UFData { Date = new DateTime(2024, 02, 04), UFValue = 36709.29M },
            new UFData { Date = new DateTime(2024, 02, 05), UFValue = 36703.35M },
            new UFData { Date = new DateTime(2024, 02, 06), UFValue = 36697.42M },
            new UFData { Date = new DateTime(2024, 02, 07), UFValue = 36691.48M },
            new UFData { Date = new DateTime(2024, 02, 08), UFValue = 36685.55M },
            new UFData { Date = new DateTime(2024, 02, 09), UFValue = 36679.62M },
            new UFData { Date = new DateTime(2024, 02, 10), UFValue = 36688.44M },
            new UFData { Date = new DateTime(2024, 02, 11), UFValue = 36697.27M },
            new UFData { Date = new DateTime(2024, 02, 12), UFValue = 36706.10M },
            new UFData { Date = new DateTime(2024, 02, 13), UFValue = 36714.93M },
            new UFData { Date = new DateTime(2024, 02, 14), UFValue = 36723.76M },
            new UFData { Date = new DateTime(2024, 02, 15), UFValue = 36732.60M },
            new UFData { Date = new DateTime(2024, 02, 16), UFValue = 36741.43M },
            new UFData { Date = new DateTime(2024, 02, 17), UFValue = 36750.27M },
            new UFData { Date = new DateTime(2024, 02, 18), UFValue = 36759.11M },
            new UFData { Date = new DateTime(2024, 02, 19), UFValue = 36767.95M },
            new UFData { Date = new DateTime(2024, 02, 20), UFValue = 36776.80M },
            new UFData { Date = new DateTime(2024, 02, 21), UFValue = 36785.65M },
            new UFData { Date = new DateTime(2024, 02, 22), UFValue = 36794.50M },
            new UFData { Date = new DateTime(2024, 02, 23), UFValue = 36803.35M },
            new UFData { Date = new DateTime(2024, 02, 24), UFValue = 36812.20M },
            new UFData { Date = new DateTime(2024, 02, 25), UFValue = 36821.06M },
            new UFData { Date = new DateTime(2024, 02, 26), UFValue = 36829.92M },
            new UFData { Date = new DateTime(2024, 02, 27), UFValue = 36838.78M },
            new UFData { Date = new DateTime(2024, 02, 28), UFValue = 36847.64M },
            new UFData { Date = new DateTime(2024, 02, 29), UFValue = 36856.50M },
        
            // 29 de febrero...

            // Marzo 2024
            new UFData { Date = new DateTime(2024, 03, 01), UFValue = 36865.37M },
            new UFData { Date = new DateTime(2024, 03, 02), UFValue = 36874.24M },
            new UFData { Date = new DateTime(2024, 03, 03), UFValue = 36883.11M },
            new UFData { Date = new DateTime(2024, 03, 04), UFValue = 36891.98M },
            new UFData { Date = new DateTime(2024, 03, 05), UFValue = 36900.86M },
            new UFData { Date = new DateTime(2024, 03, 06), UFValue = 36909.72M },
            new UFData { Date = new DateTime(2024, 03, 07), UFValue = 36918.61M },
            new UFData { Date = new DateTime(2024, 03, 08), UFValue = 36927.49M },
            new UFData { Date = new DateTime(2024, 03, 09), UFValue = 36936.38M },
            new UFData { Date = new DateTime(2024, 03, 10), UFValue = 36943.51M },
            new UFData { Date = new DateTime(2024, 03, 11), UFValue = 36950.68M },
            new UFData { Date = new DateTime(2024, 03, 12), UFValue = 36957.77M },
            new UFData { Date = new DateTime(2024, 03, 13), UFValue = 36964.98M },
            new UFData { Date = new DateTime(2024, 03, 14), UFValue = 36972.23M },
            new UFData { Date = new DateTime(2024, 03, 15), UFValue = 36979.11M },
            new UFData { Date = new DateTime(2024, 03, 16), UFValue = 36986.31M },
            new UFData { Date = new DateTime(2024, 03, 17), UFValue = 36993.44M },
            new UFData { Date = new DateTime(2024, 03, 18), UFValue = 37000.67M },
            new UFData { Date = new DateTime(2024, 03, 19), UFValue = 37007.72M },
            new UFData { Date = new DateTime(2024, 03, 20), UFValue = 37014.87M },
            new UFData { Date = new DateTime(2024, 03, 21), UFValue = 37022.13M },
            new UFData { Date = new DateTime(2024, 03, 22), UFValue = 37029.16M },
            new UFData { Date = new DateTime(2024, 03, 23), UFValue = 37036.41M },
            new UFData { Date = new DateTime(2024, 03, 24), UFValue = 37043.43M },
            new UFData { Date = new DateTime(2024, 03, 25), UFValue = 37050.56M },
            new UFData { Date = new DateTime(2024, 03, 26), UFValue = 37057.88M },
            new UFData { Date = new DateTime(2024, 03, 27), UFValue = 37064.93M },
            new UFData { Date = new DateTime(2024, 03, 28), UFValue = 37072.12M },
            new UFData { Date = new DateTime(2024, 03, 29), UFValue = 37079.25M },
            new UFData { Date = new DateTime(2024, 03, 30), UFValue = 37086.56M },
            new UFData { Date = new DateTime(2024, 03, 31), UFValue = 37093.52M },

        // Abril 2024
            new UFData { Date = new DateTime(2024, 04, 01), UFValue = 37100.68M },
            new UFData { Date = new DateTime(2024, 04, 02), UFValue = 37107.84M },
            new UFData { Date = new DateTime(2024, 04, 03), UFValue = 37115.00M },
            new UFData { Date = new DateTime(2024, 04, 04), UFValue = 37122.16M },
            new UFData { Date = new DateTime(2024, 04, 05), UFValue = 37129.33M },
            new UFData { Date = new DateTime(2024, 04, 06), UFValue = 37136.49M },
            new UFData { Date = new DateTime(2024, 04, 07), UFValue = 37143.66M },
            new UFData { Date = new DateTime(2024, 04, 08), UFValue = 37150.83M },
            new UFData { Date = new DateTime(2024, 04, 09), UFValue = 37158.00M },
            new UFData { Date = new DateTime(2024, 04, 10), UFValue = 37162.94M },
            new UFData { Date = new DateTime(2024, 04, 11), UFValue = 37167.89M },
            new UFData { Date = new DateTime(2024, 04, 12), UFValue = 37172.84M },
            new UFData { Date = new DateTime(2024, 04, 13), UFValue = 37177.78M },
            new UFData { Date = new DateTime(2024, 04, 14), UFValue = 37182.73M },
            new UFData { Date = new DateTime(2024, 04, 15), UFValue = 37187.68M },
            new UFData { Date = new DateTime(2024, 04, 16), UFValue = 37192.63M },
            new UFData { Date = new DateTime(2024, 04, 17), UFValue = 37197.58M },
            new UFData { Date = new DateTime(2024, 04, 18), UFValue = 37202.53M },
            new UFData { Date = new DateTime(2024, 04, 19), UFValue = 37207.48M },
            new UFData { Date = new DateTime(2024, 04, 20), UFValue = 37212.43M },
            new UFData { Date = new DateTime(2024, 04, 21), UFValue = 37217.38M },
            new UFData { Date = new DateTime(2024, 04, 22), UFValue = 37222.33M },
            new UFData { Date = new DateTime(2024, 04, 23), UFValue = 37227.29M },
            new UFData { Date = new DateTime(2024, 04, 24), UFValue = 37232.24M },
            new UFData { Date = new DateTime(2024, 04, 25), UFValue = 37237.20M },
            new UFData { Date = new DateTime(2024, 04, 26), UFValue = 37242.15M },
            new UFData { Date = new DateTime(2024, 04, 27), UFValue = 37247.11M },
            new UFData { Date = new DateTime(2024, 04, 28), UFValue = 37252.06M },
            new UFData { Date = new DateTime(2024, 04, 29), UFValue = 37257.02M },
            new UFData { Date = new DateTime(2024, 04, 30), UFValue = 37261.98M },
        // 30 días de abril...

       // Mayo 2024
            new UFData { Date = new DateTime(2024, 05, 01), UFValue = 37266.94M },
            new UFData { Date = new DateTime(2024, 05, 02), UFValue = 37271.90M },
            new UFData { Date = new DateTime(2024, 05, 03), UFValue = 37276.86M },
            new UFData { Date = new DateTime(2024, 05, 04), UFValue = 37281.82M },
            new UFData { Date = new DateTime(2024, 05, 05), UFValue = 37286.78M },
            new UFData { Date = new DateTime(2024, 05, 06), UFValue = 37291.74M },
            new UFData { Date = new DateTime(2024, 05, 07), UFValue = 37296.70M },
            new UFData { Date = new DateTime(2024, 05, 08), UFValue = 37301.67M },
            new UFData { Date = new DateTime(2024, 05, 09), UFValue = 37306.63M },
            new UFData { Date = new DateTime(2024, 05, 10), UFValue = 37312.63M },
            new UFData { Date = new DateTime(2024, 05, 11), UFValue = 37318.64M },
            new UFData { Date = new DateTime(2024, 05, 12), UFValue = 37324.64M },
            new UFData { Date = new DateTime(2024, 05, 13), UFValue = 37330.65M },
            new UFData { Date = new DateTime(2024, 05, 14), UFValue = 37336.65M },
            new UFData { Date = new DateTime(2024, 05, 15), UFValue = 37342.66M },
            new UFData { Date = new DateTime(2024, 05, 16), UFValue = 37348.67M },
            new UFData { Date = new DateTime(2024, 05, 17), UFValue = 37354.68M },
            new UFData { Date = new DateTime(2024, 05, 18), UFValue = 37360.69M },
            new UFData { Date = new DateTime(2024, 05, 19), UFValue = 37366.70M },
            new UFData { Date = new DateTime(2024, 05, 20), UFValue = 37372.71M },
            new UFData { Date = new DateTime(2024, 05, 21), UFValue = 37378.73M },
            new UFData { Date = new DateTime(2024, 05, 22), UFValue = 37384.74M },
            new UFData { Date = new DateTime(2024, 05, 23), UFValue = 37390.76M },
            new UFData { Date = new DateTime(2024, 05, 24), UFValue = 37396.77M },
            new UFData { Date = new DateTime(2024, 05, 25), UFValue = 37402.79M },
            new UFData { Date = new DateTime(2024, 05, 26), UFValue = 37408.81M },
            new UFData { Date = new DateTime(2024, 05, 27), UFValue = 37414.83M },
            new UFData { Date = new DateTime(2024, 05, 28), UFValue = 37420.85M },
            new UFData { Date = new DateTime(2024, 05, 29), UFValue = 37426.87M },
            new UFData { Date = new DateTime(2024, 05, 30), UFValue = 37432.89M },
            new UFData { Date = new DateTime(2024, 05, 31), UFValue = 37438.91M },


       // Junio 2024
            new UFData { Date = new DateTime(2024, 06, 01), UFValue = 37444.94M },
            new UFData { Date = new DateTime(2024, 06, 02), UFValue = 37450.96M },
            new UFData { Date = new DateTime(2024, 06, 03), UFValue = 37456.99M },
            new UFData { Date = new DateTime(2024, 06, 04), UFValue = 37463.01M },
            new UFData { Date = new DateTime(2024, 06, 05), UFValue = 37469.04M },
            new UFData { Date = new DateTime(2024, 06, 06), UFValue = 37475.07M },
            new UFData { Date = new DateTime(2024, 06, 07), UFValue = 37481.10M },
            new UFData { Date = new DateTime(2024, 06, 08), UFValue = 37487.13M },
            new UFData { Date = new DateTime(2024, 06, 09), UFValue = 37493.16M },
            new UFData { Date = new DateTime(2024, 06, 10), UFValue = 37496.90M },
            new UFData { Date = new DateTime(2024, 06, 11), UFValue = 37500.65M },
            new UFData { Date = new DateTime(2024, 06, 12), UFValue = 37504.39M },
            new UFData { Date = new DateTime(2024, 06, 13), UFValue = 37508.14M },
            new UFData { Date = new DateTime(2024, 06, 14), UFValue = 37511.88M },
            new UFData { Date = new DateTime(2024, 06, 15), UFValue = 37515.63M },
            new UFData { Date = new DateTime(2024, 06, 16), UFValue = 37519.38M },
            new UFData { Date = new DateTime(2024, 06, 17), UFValue = 37523.12M },
            new UFData { Date = new DateTime(2024, 06, 18), UFValue = 37526.87M },
            new UFData { Date = new DateTime(2024, 06, 19), UFValue = 37530.62M },
            new UFData { Date = new DateTime(2024, 06, 20), UFValue = 37534.36M },
            new UFData { Date = new DateTime(2024, 06, 21), UFValue = 37538.11M },
            new UFData { Date = new DateTime(2024, 06, 22), UFValue = 37541.86M },
            new UFData { Date = new DateTime(2024, 06, 23), UFValue = 37545.61M },
            new UFData { Date = new DateTime(2024, 06, 24), UFValue = 37549.36M },
            new UFData { Date = new DateTime(2024, 06, 25), UFValue = 37553.11M },
            new UFData { Date = new DateTime(2024, 06, 26), UFValue = 37556.86M },
            new UFData { Date = new DateTime(2024, 06, 27), UFValue = 37560.61M },
            new UFData { Date = new DateTime(2024, 06, 28), UFValue = 37564.36M },
            new UFData { Date = new DateTime(2024, 06, 29), UFValue = 37568.11M },
            new UFData { Date = new DateTime(2024, 06, 30), UFValue = 37571.86M },


        // 30 días de junio...

        // Julio 2024

            new UFData { Date = new DateTime(2024, 07, 01), UFValue = 37575.61M },
            new UFData { Date = new DateTime(2024, 07, 02), UFValue = 37579.36M },
            new UFData { Date = new DateTime(2024, 07, 03), UFValue = 37583.12M },
            new UFData { Date = new DateTime(2024, 07, 04), UFValue = 37586.87M },
            new UFData { Date = new DateTime(2024, 07, 05), UFValue = 37590.62M },
            new UFData { Date = new DateTime(2024, 07, 06), UFValue = 37594.38M },
            new UFData { Date = new DateTime(2024, 07, 07), UFValue = 37598.13M },
            new UFData { Date = new DateTime(2024, 07, 08), UFValue = 37601.88M },
            new UFData { Date = new DateTime(2024, 07, 09), UFValue = 37605.64M },
            new UFData { Date = new DateTime(2024, 07, 10), UFValue = 37604.43M },
            new UFData { Date = new DateTime(2024, 07, 11), UFValue = 37603.21M },
            new UFData { Date = new DateTime(2024, 07, 12), UFValue = 37602.00M },
            new UFData { Date = new DateTime(2024, 07, 13), UFValue = 37600.79M },
            new UFData { Date = new DateTime(2024, 07, 14), UFValue = 37599.57M },
            new UFData { Date = new DateTime(2024, 07, 15), UFValue = 37598.36M },
            new UFData { Date = new DateTime(2024, 07, 16), UFValue = 37597.15M },
            new UFData { Date = new DateTime(2024, 07, 17), UFValue = 37595.93M },
            new UFData { Date = new DateTime(2024, 07, 18), UFValue = 37594.72M },
            new UFData { Date = new DateTime(2024, 07, 19), UFValue = 37593.51M },
            new UFData { Date = new DateTime(2024, 07, 20), UFValue = 37592.29M },
            new UFData { Date = new DateTime(2024, 07, 21), UFValue = 37591.08M },
            new UFData { Date = new DateTime(2024, 07, 22), UFValue = 37589.87M },
            new UFData { Date = new DateTime(2024, 07, 23), UFValue = 37588.65M },
            new UFData { Date = new DateTime(2024, 07, 24), UFValue = 37587.44M },
            new UFData { Date = new DateTime(2024, 07, 25), UFValue = 37586.23M },
            new UFData { Date = new DateTime(2024, 07, 26), UFValue = 37585.01M },
            new UFData { Date = new DateTime(2024, 07, 27), UFValue = 37583.80M },
            new UFData { Date = new DateTime(2024, 07, 28), UFValue = 37582.59M },
            new UFData { Date = new DateTime(2024, 07, 29), UFValue = 37581.37M },
            new UFData { Date = new DateTime(2024, 07, 30), UFValue = 37580.16M },
            new UFData { Date = new DateTime(2024, 07, 31), UFValue = 37578.95M },



        // Agosto 2024
            new UFData { Date = new DateTime(2024, 08, 01), UFValue = 37577.74M },
            new UFData { Date = new DateTime(2024, 08, 02), UFValue = 37576.52M },
            new UFData { Date = new DateTime(2024, 08, 03), UFValue = 37575.31M },
            new UFData { Date = new DateTime(2024, 08, 04), UFValue = 37574.10M },
            new UFData { Date = new DateTime(2024, 08, 05), UFValue = 37572.88M },
            new UFData { Date = new DateTime(2024, 08, 06), UFValue = 37571.67M },
            new UFData { Date = new DateTime(2024, 08, 07), UFValue = 37570.46M },
            new UFData { Date = new DateTime(2024, 08, 08), UFValue = 37569.25M },
            new UFData { Date = new DateTime(2024, 08, 09), UFValue = 37568.03M },
            new UFData { Date = new DateTime(2024, 08, 10), UFValue = 37576.48M },
            new UFData { Date = new DateTime(2024, 08, 11), UFValue = 37584.94M },
            new UFData { Date = new DateTime(2024, 08, 12), UFValue = 37593.40M },
            new UFData { Date = new DateTime(2024, 08, 13), UFValue = 37601.86M },
            new UFData { Date = new DateTime(2024, 08, 14), UFValue = 37610.32M },
            new UFData { Date = new DateTime(2024, 08, 15), UFValue = 37618.79M },
            new UFData { Date = new DateTime(2024, 08, 16), UFValue = 37627.25M },
            new UFData { Date = new DateTime(2024, 08, 17), UFValue = 37635.72M },
            new UFData { Date = new DateTime(2024, 08, 18), UFValue = 37644.19M },
            new UFData { Date = new DateTime(2024, 08, 19), UFValue = 37652.66M },
            new UFData { Date = new DateTime(2024, 08, 20), UFValue = 37661.13M },
            new UFData { Date = new DateTime(2024, 08, 21), UFValue = 37669.61M },
            new UFData { Date = new DateTime(2024, 08, 22), UFValue = 37678.09M },
            new UFData { Date = new DateTime(2024, 08, 23), UFValue = 37686.57M },
            new UFData { Date = new DateTime(2024, 08, 24), UFValue = 37695.05M },
            new UFData { Date = new DateTime(2024, 08, 25), UFValue = 37703.53M },
            new UFData { Date = new DateTime(2024, 08, 26), UFValue = 37712.02M },
            new UFData { Date = new DateTime(2024, 08, 27), UFValue = 37720.50M },
            new UFData { Date = new DateTime(2024, 08, 28), UFValue = 37728.99M },
            new UFData { Date = new DateTime(2024, 08, 29), UFValue = 37737.48M },
            new UFData { Date = new DateTime(2024, 08, 30), UFValue = 37745.97M },
            new UFData { Date = new DateTime(2024, 08, 31), UFValue = 37754.47M },


        //  31 días de agosto...

        // Septiembre 2024
            new UFData { Date = new DateTime(2024, 09, 01), UFValue = 37762.97M },
            new UFData { Date = new DateTime(2024, 09, 02), UFValue = 37771.46M },
            new UFData { Date = new DateTime(2024, 09, 03), UFValue = 37779.96M },
            new UFData { Date = new DateTime(2024, 09, 04), UFValue = 37788.47M },
            new UFData { Date = new DateTime(2024, 09, 05), UFValue = 37796.97M },
            new UFData { Date = new DateTime(2024, 09, 06), UFValue = 37805.48M },
            new UFData { Date = new DateTime(2024, 09, 07), UFValue = 37813.98M },
            new UFData { Date = new DateTime(2024, 09, 08), UFValue = 37822.49M },
            new UFData { Date = new DateTime(2024, 09, 09), UFValue = 37831.01M },
            new UFData { Date = new DateTime(2024, 09, 10), UFValue = 37834.79M },
            new UFData { Date = new DateTime(2024, 09, 11), UFValue = 37838.57M },
            new UFData { Date = new DateTime(2024, 09, 12), UFValue = 37842.34M },
            new UFData { Date = new DateTime(2024, 09, 13), UFValue = 37846.12M },
            new UFData { Date = new DateTime(2024, 09, 14), UFValue = 37849.90M },
            new UFData { Date = new DateTime(2024, 09, 15), UFValue = 37853.68M },
            new UFData { Date = new DateTime(2024, 09, 16), UFValue = 37857.46M },
            new UFData { Date = new DateTime(2024, 09, 17), UFValue = 37861.24M },
            new UFData { Date = new DateTime(2024, 09, 18), UFValue = 37865.02M },
            new UFData { Date = new DateTime(2024, 09, 19), UFValue = 37868.80M },
            new UFData { Date = new DateTime(2024, 09, 20), UFValue = 37872.58M },
            new UFData { Date = new DateTime(2024, 09, 21), UFValue = 37876.37M },
            new UFData { Date = new DateTime(2024, 09, 22), UFValue = 37880.15M },
            new UFData { Date = new DateTime(2024, 09, 23), UFValue = 37883.93M },
            new UFData { Date = new DateTime(2024, 09, 24), UFValue = 37887.71M },
            new UFData { Date = new DateTime(2024, 09, 25), UFValue = 37891.50M },
            new UFData { Date = new DateTime(2024, 09, 26), UFValue = 37895.28M },
            new UFData { Date = new DateTime(2024, 09, 27), UFValue = 37899.07M },
            new UFData { Date = new DateTime(2024, 09, 28), UFValue = 37902.85M },
            new UFData { Date = new DateTime(2024, 09, 29), UFValue = 37906.63M },
            new UFData { Date = new DateTime(2024, 09, 30), UFValue = 37910.42M },


        // Octubre 2024
            new UFData { Date = new DateTime(2024, 10, 01), UFValue = 37914.20M },
            new UFData { Date = new DateTime(2024, 10, 02), UFValue = 37917.99M },
            new UFData { Date = new DateTime(2024, 10, 03), UFValue = 37921.78M },
            new UFData { Date = new DateTime(2024, 10, 04), UFValue = 37925.56M },
            new UFData { Date = new DateTime(2024, 10, 05), UFValue = 37929.35M },
            new UFData { Date = new DateTime(2024, 10, 06), UFValue = 37933.14M },
            new UFData { Date = new DateTime(2024, 10, 07), UFValue = 37936.93M },
            new UFData { Date = new DateTime(2024, 10, 08), UFValue = 37940.71M },
            new UFData { Date = new DateTime(2024, 10, 09), UFValue = 37944.50M },
            new UFData { Date = new DateTime(2024, 10, 10), UFValue = 37945.72M },
            new UFData { Date = new DateTime(2024, 10, 11), UFValue = 37946.95M },
            new UFData { Date = new DateTime(2024, 10, 12), UFValue = 37948.17M },
            new UFData { Date = new DateTime(2024, 10, 13), UFValue = 37949.39M },
            new UFData { Date = new DateTime(2024, 10, 14), UFValue = 37950.62M },
            new UFData { Date = new DateTime(2024, 10, 15), UFValue = 37951.84M },
            new UFData { Date = new DateTime(2024, 10, 16), UFValue = 37953.06M },
            new UFData { Date = new DateTime(2024, 10, 17), UFValue = 37954.29M },
            new UFData { Date = new DateTime(2024, 10, 18), UFValue = 37955.51M },
            new UFData { Date = new DateTime(2024, 10, 19), UFValue = 37956.74M },
            new UFData { Date = new DateTime(2024, 10, 20), UFValue = 37957.96M },
            new UFData { Date = new DateTime(2024, 10, 21), UFValue = 37959.18M },
            new UFData { Date = new DateTime(2024, 10, 22), UFValue = 37960.41M },
            new UFData { Date = new DateTime(2024, 10, 23), UFValue = 37961.63M },
            new UFData { Date = new DateTime(2024, 10, 24), UFValue = 37962.86M },
            new UFData { Date = new DateTime(2024, 10, 25), UFValue = 37964.08M },
            new UFData { Date = new DateTime(2024, 10, 26), UFValue = 37965.30M },
            new UFData { Date = new DateTime(2024, 10, 27), UFValue = 37966.53M },
            new UFData { Date = new DateTime(2024, 10, 28), UFValue = 37967.75M },
            new UFData { Date = new DateTime(2024, 10, 29), UFValue = 37968.98M },
            new UFData { Date = new DateTime(2024, 10, 30), UFValue = 37970.20M },
            new UFData { Date = new DateTime(2024, 10, 31), UFValue = 37971.42M },
        //  31 días de octubre...

        // Noviembre 2024
            new UFData { Date = new DateTime(2024, 11, 01), UFValue = 37972.65M },
            new UFData { Date = new DateTime(2024, 11, 02), UFValue = 37973.87M },
            new UFData { Date = new DateTime(2024, 11, 03), UFValue = 37975.10M },
            new UFData { Date = new DateTime(2024, 11, 04), UFValue = 37976.32M },
            new UFData { Date = new DateTime(2024, 11, 05), UFValue = 37977.55M },
            new UFData { Date = new DateTime(2024, 11, 06), UFValue = 37978.77M },
            new UFData { Date = new DateTime(2024, 11, 07), UFValue = 37980.00M },
            new UFData { Date = new DateTime(2024, 11, 08), UFValue = 37981.22M },
            new UFData { Date = new DateTime(2024, 11, 09), UFValue = 37982.44M },

     

        // Diciembre 2024
        
       
    };
        }

        private bool FiltrarPorMesYAnio(UFData uf, string mesSeleccionado, int? anioSeleccionado)
        {
            if (anioSeleccionado.HasValue && uf.Date.Year != anioSeleccionado.Value)
                return false;

            if (!string.IsNullOrEmpty(mesSeleccionado) && mesSeleccionado != "Todos los meses")
            {
                var mes = DateTime.ParseExact(mesSeleccionado, "MMMM", new System.Globalization.CultureInfo("es-ES")).Month;
                return uf.Date.Month == mes;
            }

            return true;
        }
    }
}
