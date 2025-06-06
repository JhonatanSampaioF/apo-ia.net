using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class VoluntarioRepository : IVoluntarioRepository
    {
        private readonly ApplicationContext _context;

        public VoluntarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VoluntarioEntity? DeletarDados(int id)
        {
            try
            {
                var voluntario = _context.Voluntario.Find(id);

                if (voluntario is not null)
                {
                    _context.Remove(voluntario);
                    _context.SaveChanges();

                    return voluntario;

                }
                throw new Exception("Não foi possível localizar o voluntario");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VoluntarioEntity? EditarDados(VoluntarioEntity entity)
        {
            try
            {
                var voluntario = _context.Voluntario.Find(entity.id);

                if (voluntario is not null)
                {
                    voluntario.alocacao = entity.alocacao;
                    voluntario.capacidadeMotora = entity.capacidadeMotora;

                    _context.Update(voluntario);
                    _context.SaveChanges();

                    return voluntario;
                }

                throw new Exception("Não foi possível localizar o voluntario");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VoluntarioEntity? ObterporId(int id)
        {
            var voluntario = _context.Voluntario.Find(id);

            if (voluntario is not null)
            {
                return voluntario;
            }
            return null;
        }

        public IEnumerable<VoluntarioEntity>? ObterTodos()
        {
            var voluntarios = _context.Voluntario.ToList();

            if (voluntarios.Any())
                return voluntarios;

            return null;
        }

        public VoluntarioEntity? SalvarDados(VoluntarioEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o voluntario");
            }
        }
    }
}
