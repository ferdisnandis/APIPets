using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Interfaces
{
    interface IRaca
    {
        List<Raca> ListarTodosRaça();
        Raca BuscarId(int IdRaca);
        Raca Cadastrar(Raca r);
        Raca Alterar(int id, Raca r);
        void Excluir(int id);
    }
}
