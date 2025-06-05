using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class GrupoHabilidadeTests
    {
        [Fact]
        public void DeveCriarGrupoComNome()
        {
            var grupo = new GrupoHabilidadeEntity
            {
                nome = "Serviços Gerais"
            };

            Assert.Equal("Serviços Gerais", grupo.nome);
        }
    }
}
