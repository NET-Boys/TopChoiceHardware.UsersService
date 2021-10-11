using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TopChoiceHardware.UsersService.Application.Services;
using TopChoiceHardware.UsersService.Domain.DTOs;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UserController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDtoForDisplay), StatusCodes.Status201Created)]
        public IActionResult Post(UsuarioDtoForCreation usuario)
        {
            try
            {
                var usuarioEntity = _service.CreateUsuario(usuario);
                
                if (usuarioEntity != null)
                {
                    var usuarioCreado = _mapper.Map<UsuarioDtoForDisplay>(usuarioEntity);
                    return Created("~api/usuario/", usuarioCreado);
                }

                return Conflict("Error, ya existe un usuario registrado con el email y / o dni ingresados.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioDtoForDisplay>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllUsers()
        {
            try
            {
                var usuarios = _service.GetUsuarios();
                var usuariosMapeados = _mapper.Map<List<UsuarioDtoForDisplay>>(usuarios);

                return Ok(usuariosMapeados);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioDtoForDisplay), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var usuario = _service.GetUsuarioById(id);
                var usuarioMapeado = _mapper.Map<UsuarioDtoForDisplay>(usuario);
                
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuarioMapeado);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePelicula(int id, [FromBody] UsuarioDtoForCreation usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
                }

                var usuarioEntity = _service.GetUsuarioById(id);

                if (usuarioEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(usuario, usuarioEntity);
                _service.UpdateUsuario(usuarioEntity);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
