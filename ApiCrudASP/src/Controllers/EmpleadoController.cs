using Microsoft.AspNetCore.Mvc;
using AppCrud.Models;
using AppCrud.Data;
using Microsoft.EntityFrameworkCore;


namespace AppCrud.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _dbContext;


        /* Inyeccion de dependencias */
        public EmpleadoController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        
        }

        /* Listar Empleados */

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            Empleado empleado = new Empleado();
            List<Empleado> lista=await _dbContext.Empleados.ToListAsync();
            
            ViewBag["Modelo"] = empleado;
        
            return View(lista);
        
        
        }

        /* Guardar Empleado */

        public IActionResult Nuevo()
        {

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
          
            await _dbContext.Empleados.AddAsync(empleado);
            await _dbContext.SaveChangesAsync();

            


            return RedirectToAction(nameof(Lista));


        }



        [HttpPost]

        public async Task<IActionResult> Editar(Empleado _empleado)
        {
           
            
            var empleado = await _dbContext.Empleados.FirstAsync(x => x.IdEmpleado == _empleado.IdEmpleado);

            if (empleado != null)
            {
                empleado.IdEmpleado = _empleado.IdEmpleado;
                empleado.NombreCompleto = _empleado.NombreCompleto;
                empleado.Correo=_empleado.Correo;
                empleado.Activo=_empleado.Activo;
                empleado.FechaContrato=_empleado.FechaContrato;

                _dbContext.Empleados.Update(empleado);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Lista));

        }



        /* Editar Empelado */
        public async Task<IActionResult> Editar(int id)
        {
            /*--Enviar el usuario a editar a la vista ----*/

            var empleado= await _dbContext.Empleados.FirstAsync(x=>x.IdEmpleado==id);

            return View(empleado);

        }


        /* Eliminar Empleado */

        public async Task<IActionResult>Eliminar(int id)
        {
            var empleado = await _dbContext.Empleados.FirstAsync(x => x.IdEmpleado == id);
            _dbContext.Empleados.Remove(empleado);
            await _dbContext.SaveChangesAsync();
        
            return RedirectToAction(nameof(Lista));

        }

    }
}
