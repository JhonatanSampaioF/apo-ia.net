using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Repositories
{
    public class AbrigadoRepository : IAbrigadoRepository
    {
        private readonly ApplicationContext _context;

        public AbrigadoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public AbrigadoEntity? DeletarDados(int id)
        {
            try
            {
                var abrigado = _context.Abrigado.Find(id);

                if (abrigado is not null)
                {
                    _context.Remove(abrigado);
                    _context.SaveChanges();

                    return abrigado;

                }
                throw new Exception("Não foi possível localizar o abrigado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public AbrigadoEntity? EditarDados(AbrigadoEntity entity)
        {
            try
            {
                var abrigado = _context.Abrigado.Find(entity.id);

                if (abrigado is not null)
                {
                    abrigado.nome = entity.nome;
                    abrigado.idade = entity.idade;
                    abrigado.altura = entity.altura;
                    abrigado.peso = entity.peso;
                    abrigado.cpf = entity.cpf;
                    abrigado.voluntario = entity.voluntario;
                    abrigado.ferimento = entity.ferimento;

                    _context.Update(abrigado);
                    _context.SaveChanges();

                    return abrigado;
                }

                throw new Exception("Não foi possível localizar o abrigado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public AbrigadoEntity? ObterporId(int id)
        {
            var abrigado = _context.Abrigado.Find(id);

            if (abrigado is not null)
            {
                return abrigado;
            }
            return null;
        }

        public IEnumerable<AbrigadoEntity>? ObterTodos()
        {
            var abrigados = _context.Abrigado.ToList();

            if (abrigados.Any())
                return abrigados;

            return null;
        }

        public AbrigadoEntity? SalvarDados(AbrigadoEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o abrigado");
            }
        }
    }
}
