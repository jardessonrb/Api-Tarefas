using System.ComponentModel;

namespace apitarefas.Models.Enums;

public enum StatusTarefa
{
    [Description("A Fazer")]
    A_FAZER = 1,
    
    [Description("Em Andamento")]
    EM_ANDAMENTO = 2,
    
    [Description("Concluída")]
    CONCLUIDO = 3
}