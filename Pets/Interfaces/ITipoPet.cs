using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Interfaces
{
    interface ITipoPet
    {
        List<TipoPet> ListarTodosPet();
        TipoPet BuscarId(int IdTipoPet);
        TipoPet Cadastrar(TipoPet tp);
        TipoPet Alterar(int id,TipoPet tp);
        void Excluir(int id);
    }
}
