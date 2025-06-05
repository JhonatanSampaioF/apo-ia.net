using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class HabilidadeTests
    {
        [Fact]
        public void DeveCriarHabilidadeComPrioridadeEGrupo()
        {
            var grupo = new GrupoHabilidadeEntity { id = 1, nome = "Médicas" };
            var habilidade = new HabilidadeEntity
            {
                nome = "Enfermagem",
                prioridade = 2,
                grupoHabilidadeId = grupo.id
            };

            Assert.Equal("Enfermagem", habilidade.nome);
            Assert.Equal(2, habilidade.prioridade);
            Assert.Equal(1, habilidade.grupoHabilidadeId);
        }
    }
}
