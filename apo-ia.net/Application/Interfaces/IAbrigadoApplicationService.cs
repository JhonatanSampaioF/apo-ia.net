using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface IAbrigadoApplicationService
    {
        IEnumerable<AbrigadoEntity>? ObterTodosAbrigados();
        AbrigadoEntity? ObterAbrigadoporId(int id);
        AbrigadoEntity? SalvarDadosAbrigado(AbrigadoDto entity);
        AbrigadoEntity? EditarDadosAbrigado(int id, AbrigadoDto entity);
        AbrigadoEntity? DeletarDadosAbrigado(int id);
    }
}
