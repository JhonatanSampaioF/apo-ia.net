using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;

namespace apo_ia.net.Application.Services
{
    public class LocalApplicationService : ILocalApplicationService
    {
        private readonly ILocalRepository _localRepository;

        public LocalApplicationService(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public LocalEntity? DeletarDadosLocal(int id)
        {
            return _localRepository.DeletarDados(id);
        }

        public LocalEntity? EditarDadosLocal(int id, LocalDto entity)
        {
            var local = new LocalEntity
            {
                id = id,
                nome = entity.nome,
                endereco = entity.endereco,
                capacidade = entity.capacidade,
                qtdAbrigados = entity.qtdAbrigados
            };

            return _localRepository.EditarDados(local);
        }

        public LocalEntity? ObterLocalporId(int id)
        {
            return _localRepository.ObterporId(id);
        }

        public IEnumerable<LocalEntity>? ObterTodosLocals()
        {
            return _localRepository.ObterTodos();
        }

        public LocalEntity? SalvarDadosLocal(LocalDto entity)
        {
            var local = new LocalEntity
            {
                nome = entity.nome,
                endereco = entity.endereco,
                capacidade = entity.capacidade,
                qtdAbrigados = entity.qtdAbrigados
            };

            return _localRepository.SalvarDados(local);
        }
    }
}
