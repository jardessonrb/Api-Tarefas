using apitarefas.Models;
using apitarefas.Repositories.Usuario;

namespace apitarefas.services;

public class UsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;
    
    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        this._usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioModel> SalvarUsuario(UsuarioModel usuarioModel)
    {
        return await this._usuarioRepository.AdicionarUsuario(usuarioModel);
    }

    public async Task<List<UsuarioModel>> ListarUsuarios()
    {
        return await this._usuarioRepository.BuscarTodosUsuarios();
    }
}