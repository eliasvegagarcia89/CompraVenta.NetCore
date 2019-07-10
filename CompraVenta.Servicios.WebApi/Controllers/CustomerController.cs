using Microsoft.AspNetCore.Mvc;
using CompraVenta.Dominio.Entidades;
using CompraVenta.Datos.IModelo;

namespace CompraVenta.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    //[Authorize]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

        [Route("{id:int}")] // api/customer/{id}
        public IActionResult GetById(int id)
        {
            var customer = _unit.Customers.GetById(id);

            if (customer == null)
                return NotFound("Customer no encontrado");
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Customers.Insert(customer));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
            {
                return Ok(new { Message = "Se actualizó el customer" });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var customer = _unit.Customers.GetById(id);
            if (customer == null) return NotFound();
            return Ok(_unit.Customers.Delete(customer));
        }
    }
}