using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class GrupoHabilidadeRepository : IGrupoHabilidadeRepository
    {
        private readonly ApplicationContext _context;

        public GrupoHabilidadeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public GrupoHabilidadeEntity? DeletarDados(int id)
        {
            try
            {
                var grupoHabilidade = _context.GrupoHabilidade.Find(id);

                if (grupoHabilidade is not null)
                {
                    _context.Remove(grupoHabilidade);
                    _context.SaveChanges();

                    return grupoHabilidade;

                }
                throw new Exception("Não foi possível localizar o Grupo de Habilidade");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public GrupoHabilidadeEntity? EditarDados(GrupoHabilidadeEntity entity)
        {
            try
            {
                var grupoHabilidade = _context.GrupoHabilidade.Find(entity.id);

                if (grupoHabilidade is not null)
                {
                    grupoHabilidade.nome = entity.nome;

                    _context.Update(grupoHabilidade);
                    _context.SaveChanges();

                    return grupoHabilidade;
                }

                throw new Exception("Não foi possível localizar o Grupo de Habilidade");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public GrupoHabilidadeEntity? ObterporId(int id)
        {
            var grupoHabilidade = _context.GrupoHabilidade.Find(id);

            if (grupoHabilidade is not null)
            {
                return grupoHabilidade;
            }
            return null;
        }

        public IEnumerable<GrupoHabilidadeEntity>? ObterTodos()
        {
            var grupoHabilidades = _context.GrupoHabilidade.ToList();

            if (grupoHabilidades.Any())
                return grupoHabilidades;

            return null;
        }

        public GrupoHabilidadeEntity? SalvarDados(GrupoHabilidadeEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o Grupo de Habilidade");
            }
        }
    }
}
