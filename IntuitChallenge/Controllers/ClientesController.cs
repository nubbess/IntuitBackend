using AutoMapper;
using IntuitChallenge.Models;
using IntuitChallenge.Models.DTO;
using IntuitChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using ToolsLibrary;

namespace IntuitChallenge.Controllers
{
    [ApiController]
    [Route("Intuit/Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _cs;  
        private readonly IMapper _mapper;
        private readonly ILogger<ClientesController> _logger;
        
        public ClientesController(IClienteService clienteService, IMapper mapper, ILogger<ClientesController> logger)
        {
            _cs = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _cs.GetAll();
            _logger.LogInformation("HttpGet at: Intuit/Clientes");
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "clienteId")]
        public async Task<IActionResult> GetCliente(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Invalid ID at Intuit/Clientes: {id}");
                return BadRequest($"ID erróneo: {id}");
            }
            var cliente = await _cs.Get(a => a.ClienteId == id);

            if (cliente == null)
            {
                _logger.LogInformation("Cliente not found at Intuit/Clientes");
                return NotFound();
            }
            _logger.LogInformation($"Requested information of {cliente} at Intuit/Clientes");
            return Ok(cliente);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByChars([FromQuery] string chars)
        {
            var clientes = await _cs.GetAll(a => a.Nombre.ToLower().Contains(chars));

            if (clientes == null)
                return NotFound($"{chars} not found in any name");
            
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ClienteCreateDto clienteDto)
        {

            // Validar CUIT
            bool CuitIsValid = CuitValidator.CuitIsValid(clienteDto.Cuit);
            if (!CuitIsValid)
                return BadRequest(clienteDto.Cuit);

            // Validar modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear cliente
            var cliente = _mapper.Map<Cliente>(clienteDto);

            // Verificar existencia
            var existingCliente = await _cs.Get(a => a.Cuit == clienteDto.Cuit); ;
            if (existingCliente != null)
            {
                return Conflict($"El CUIT {cliente.Cuit} ya está registrado en el sistema");
            }

            await _cs.Create(cliente);

            return CreatedAtRoute("clienteId", new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteCreateDto clienteDto)
        {
            if (id <= 0)
                return BadRequest($"Invalid id {id} at Intuit/Clientes");

            var existingCliente = await _cs.Get(a => a.ClienteId == id);

            if (existingCliente == null)
            {
                return NotFound();
            }

            // Validar modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Actualizar cliente
            _mapper.Map(clienteDto, existingCliente);

            await _cs.Update(existingCliente);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var query = await _cs.Get(a => a.ClienteId == id);
            
            if (query == null)
                return NotFound($"No se encontro nadie con el ID: {id}");

            await _cs.Delete(query);

            return NoContent();
        }
    }

}
