using apitarefas.ApiUtils;
using apitarefas.Data;
using apitarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace apitarefas.Repositories.Usuario.Impl;

public class UsuarioRepositoryImpl : UsuarioRepository
{

    private readonly ApiTarefaContexto _dbContexto;
    
    public UsuarioRepositoryImpl(ApiTarefaContexto contexto)
    {
        _dbContexto = contexto;
    }

    public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await this._dbContexto.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
    {
        return await this._dbContexto.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
    }

    public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
    {
        await this._dbContexto.Usuarios.AddAsync(usuario);
        await this._dbContexto.SaveChangesAsync();

        return usuario;
    }

    public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioBuscado = await this.BuscarUsuarioPorId(id);

        if (usuarioBuscado == null)
        {
            throw new Exception($"Usuário para id {id} não encontrado.");
        }

        Copiador<UsuarioModel> copiador = new Copiador<UsuarioModel>();
        
        copiador.Copiar(usuario, usuarioBuscado);

        this._dbContexto.Usuarios.Update(usuarioBuscado);
        await this._dbContexto.SaveChangesAsync();
        return usuarioBuscado;
    }

    public async Task<bool> RemoverUsuario(int id)
    {
        UsuarioModel usuarioBuscado = await this.BuscarUsuarioPorId(id);

        if (usuarioBuscado == null)
        {
            throw new Exception($"Usuário para id {id} não encontrado.");
        }

        this._dbContexto.Remove(usuarioBuscado);
        await this._dbContexto.SaveChangesAsync();
        
        return true;
    }
}