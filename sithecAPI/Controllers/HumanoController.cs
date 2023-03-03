using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sithecAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HumanoController : ControllerBase
    {

        private readonly IHumano _humano;

        private readonly ILogger<HumanoController> _logger;

        public HumanoController(ILogger<HumanoController> logger, IHumano hum)
        {
            _logger = logger;
            _humano = hum;
        }

        /// <summary>
        /// PUNTO 1: Metodo fake para devolver una lista de humanos
        /// </summary>
        /// <returns>lista de humanos</returns>
        [HttpGet]
        public IActionResult getHumanosMock()
        {
            return Ok(_humano.getHumanosMock().ToList());
        }

        /// <summary>
        /// PUNTO 2: Metodo para realizar una operacion de multiplicacion con 3 valores de un objeto recibido
        /// </summary>
        /// <param name="nums">objeto con propiedades de tipo entero</param>
        /// <returns>resultado de una multiplicacion</returns>
        [HttpPost]
        public IActionResult multiplicacionNumeros([FromBody] Numero nums)
        {
            try
            {
                var resultado = _humano.multiplicacion(nums);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                //Enviar e a Log en BD
                return StatusCode(500);
            }
        }

        /// <summary>
        /// PUNTO 3: Metodo para realizar una operacion de suma con 3 valores recibidos en los headers
        /// </summary>
        /// <param name="valor1">primer numero entero</param>
        /// <param name="valor2">segundo numero entero</param>
        /// <param name="valor3">tercer numero entero</param>
        /// <returns>resultado de una suma con los 3 valores</returns>
        [HttpGet("{valor1}/{valor2}/{valor3}")]
        public IActionResult sumaNumeros(int valor1, int valor2, int valor3)
        {
            try
            {
                var resultado = _humano.sumaNumeros(valor1, valor2, valor3);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                //Enviar e a Log en BD
                return StatusCode(500);
            }
        }

        /// <summary>
        /// PUNTO 5: Metodo para consultar toda la tabla de Humanos desde bd
        /// </summary>
        /// <returns>Lista de objetos de tipo humanos </returns>
        [HttpGet]
        public IActionResult getHumanos()
        {
            return Ok(_humano.getHumanos());
        }

        /// <summary>
        /// PUNTO 6: Metodo para obtener un humano segun su id      
        /// </summary>
        /// <param name="id">identificador del humano</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getHumanoById(int id)
        {
            return Ok(_humano.getHumanosById(id));
        }

        /// <summary>
        /// PUNTO 7: Metodo para insertar un humano
        /// </summary>
        /// <param name="humano">objeto con los valores a insertar</param>
        /// <returns>id del registro insertado</returns>
        [HttpPost]
        public IActionResult postHumano([FromBody] Humano humano)
        {
            try
            {
                var resultado = _humano.setHumano(humano);
                return StatusCode(201, resultado);
            }
            catch (Exception e)
            {
                //Enviar e a Log en BD
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Metodo para actualizar un humano buscado por id
        /// </summary>
        /// <param name="humano">objeto con los valores a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult putHumano([FromBody] Humano humano)
        {
            try
            {
                _humano.updateHumano(humano);
                return Ok();
            }
            catch (Exception e)
            {
                //Enviar e a Log en BD
                return StatusCode(500);
            }
        }
    }
}
