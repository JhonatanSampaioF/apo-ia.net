using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly ApplicationContext _context;

        public LocalRepository(ApplicationContext context)
        {
            _context = context;
        }

        public LocalEntity? DeletarDados(int id)
        {
            try
            {
                var local = _context.Local.Find(id);

                if (local is not null)
                {
                    _context.Remove(local);
                    _context.SaveChanges();

                    return local;

                }
                throw new Exception("Não foi possível localizar o local");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public LocalEntity? EditarDados(LocalEntity entity)
        {
            try
            {
                var local = _context.Local.Find(entity.id);

                if (local is not null)
                {
                    local.nome = entity.nome;
                    local.endereco = entity.endereco;
                    local.capacidade = entity.capacidade;
                    local.qtdAbrigados = entity.qtdAbrigados;

                    _context.Update(local);
                    _context.SaveChanges();

                    return local;
                }

                throw new Exception("Não foi possível localizar o local");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public LocalEntity? ObterporId(int id)
        {
            var local = _context.Local.Find(id);

            if (local is not null)
            {
                return local;
            }
            return null;
        }

        public IEnumerable<LocalEntity>? ObterTodos()
        {
            var locals = _context.Local.ToList();

            if (locals.Any())
                return locals;

            return null;
        }

        public LocalEntity? SalvarDados(LocalEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o local");
            }
        }
    }
}
