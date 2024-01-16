using apitarefas.Models;
using apitarefas.Repositories.Usuario;
using apitarefas.services;
using Microsoft.AspNetCore.Mvc;

namespace apitarefas.Controllers;

[Route("api/usuario")]
[ApiController]
public class UsuarioController : ControllerBase
{
    
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> SalvarUsuario([FromBody] UsuarioModel usuario)
    {
        usuario = await this._usuarioService.SalvarUsuario(usuario);
        return Ok(usuario);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
    {
        List<UsuarioModel> usuarios = await this._usuarioService.ListarUsuarios();
        return Ok(usuarios);
    }
    
}