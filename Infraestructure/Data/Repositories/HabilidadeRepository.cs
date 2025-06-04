using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly ApplicationContext _context;

        public HabilidadeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public HabilidadeEntity? DeletarDados(int id)
        {
            try
            {
                var habilidade = _context.Habilidade.Find(id);

                if (habilidade is not null)
                {
                    _context.Remove(habilidade);
                    _context.SaveChanges();

                    return habilidade;

                }
                throw new Exception("Não foi possível localizar a habilidade");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public HabilidadeEntity? EditarDados(HabilidadeEntity entity)
        {
            try
            {
                var habilidade = _context.Habilidade.Find(entity.id);

                if (habilidade is not null)
                {
                    habilidade.nome = entity.nome;
                    habilidade.prioridade = entity.prioridade;

                    _context.Update(habilidade);
                    _context.SaveChanges();

                    return habilidade;
                }

                throw new Exception("Não foi possível localizar a habilidade");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public HabilidadeEntity? ObterporId(int id)
        {
            var habilidade = _context.Habilidade.Find(id);

            if (habilidade is not null)
            {
                return habilidade;
            }
            return null;
        }

        public IEnumerable<HabilidadeEntity>? ObterTodos()
        {
            var habilidades = _context.Habilidade.ToList();

            if (habilidades.Any())
                return habilidades;

            return null;
        }

        public HabilidadeEntity? SalvarDados(HabilidadeEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar a habilidade");
            }
        }
    }
}
