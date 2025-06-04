using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;

namespace apo_ia.net.Application.Services
{
    public class DoencaApplicationService : IDoencaApplicationService
    {
        private readonly IDoencaRepository _doencaRepository;

        public DoencaApplicationService(IDoencaRepository doencaRepository)
        {
            _doencaRepository = doencaRepository;
        }

        public DoencaEntity? DeletarDadosDoenca(int id)
        {
            return _doencaRepository.DeletarDados(id);
        }

        public DoencaEntity? EditarDadosDoenca(int id, DoencaDto entity)
        {
            var doenca = new DoencaEntity
            {
                id = id,
                nome = entity.nome,
                gravidade = entity.gravidade
            };

            return _doencaRepository.EditarDados(doenca);
        }

        public DoencaEntity? ObterDoencaporId(int id)
        {
            return _doencaRepository.ObterporId(id);
        }

        public IEnumerable<DoencaEntity>? ObterTodosDoencas()
        {
            return _doencaRepository.ObterTodos();
        }

        public DoencaEntity? SalvarDadosDoenca(DoencaDto entity)
        {
            var doenca = new DoencaEntity
            {
                nome = entity.nome,
                gravidade = entity.gravidade
            };

            return _doencaRepository.SalvarDados(doenca);
        }
    }
}
