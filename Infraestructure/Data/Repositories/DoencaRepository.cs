using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class DoencaRepository : IDoencaRepository
    {
        private readonly ApplicationContext _context;

        public DoencaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public DoencaEntity? DeletarDados(int id)
        {
            try
            {
                var doenca = _context.Doenca.Find(id);

                if (doenca is not null)
                {
                    _context.Remove(doenca);
                    _context.SaveChanges();

                    return doenca;

                }
                throw new Exception("Não foi possível localizar a doenca");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DoencaEntity? EditarDados(DoencaEntity entity)
        {
            try
            {
                var doenca = _context.Doenca.Find(entity.id);

                if (doenca is not null)
                {
                    doenca.nome = entity.nome;
                    doenca.gravidade = entity.gravidade;

                    _context.Update(doenca);
                    _context.SaveChanges();

                    return doenca;
                }

                throw new Exception("Não foi possível localizar a doenca");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DoencaEntity? ObterporId(int id)
        {
            var doenca = _context.Doenca.Find(id);

            if (doenca is not null)
            {
                return doenca;
            }
            return null;
        }

        public IEnumerable<DoencaEntity>? ObterTodos()
        {
            var doencas = _context.Doenca.ToList();

            if (doencas.Any())
                return doencas;

            return null;
        }

        public DoencaEntity? SalvarDados(DoencaEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar a doenca");
            }
        }
    }
}
