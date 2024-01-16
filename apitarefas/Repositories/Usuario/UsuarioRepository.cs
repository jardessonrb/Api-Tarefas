using apitarefas.Models;

namespace apitarefas.Repositories.Usuario;

public interface UsuarioRepository
{
    Task<List<UsuarioModel>> BuscarTodosUsuarios();
    
    Task<UsuarioModel> BuscarUsuarioPorId(int id);
    
    Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
    
    Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
    
    Task<bool> RemoverUsuario(int id);
    
}