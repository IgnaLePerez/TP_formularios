using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp_Formularios.Models;

namespace Tp_Formularios.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult VerificarDatos(string nombreCompleto, int edad, int dni, bool situacionLaboral, int tipoDeEmpleo, int ingresoMensual, bool deudas, bool tarjetaDeCredito, bool prestamoBancario, bool prestamoInformal, int montoSolicitado, int plazo, bool terminosYCondiciones)
    {
        const int INGRESO_MENSUAL_MINIMO = 250000;
        string apto = "El usuario no es apto para el prestamo";
        if (edad > 18){
            if (situacionLaboral){
                if (ingresoMensual > INGRESO_MENSUAL_MINIMO){
                    if (montoSolicitado > ingresoMensual * 5){
                        if (!deudas){
                            if (terminosYCondiciones){
                                apto = "El usuario es apto para el prestamo";
                            }
                        }
                    }
                }
            }
        }
        ViewBag.Apto = apto;
        return View();
    }
}
