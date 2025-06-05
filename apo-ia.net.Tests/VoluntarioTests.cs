using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class VoluntarioTests
    {
        [Fact]
        public void DeveCriarVoluntarioComAbrigado()
        {
            var abrigado = new AbrigadoEntity { nome = "Maria" };
            var voluntario = new VoluntarioEntity
            {
                abrigado = abrigado,
                abrigadoId = 1,
                capacidadeMotora = "Boa"
            };

            Assert.Equal("Maria", voluntario.abrigado.nome);
            Assert.Equal("Boa", voluntario.capacidadeMotora);
        }

        [Fact]
        public void DeveAdicionarHabilidade()
        {
            var habilidade = new HabilidadeEntity { nome = "Cozinha" };
            var voluntario = new VoluntarioEntity();

            voluntario.habilidades.Add(habilidade);

            Assert.Single(voluntario.habilidades);
            Assert.Equal("Cozinha", voluntario.habilidades[0].nome);
        }
    }
}
