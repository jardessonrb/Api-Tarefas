using AutoMapper;

namespace apitarefas.ApiUtils;

public class Copiador<TipoObjeto>
{
    public void Copiar(TipoObjeto origem, TipoObjeto destino)
    {
        var config = new MapperConfiguration(config => config.CreateMap<TipoObjeto, TipoObjeto>());
        var mapper = new Mapper(config);

        mapper.Map(origem, destino);
    }
}