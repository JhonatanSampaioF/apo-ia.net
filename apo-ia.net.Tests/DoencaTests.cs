using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class DoencaTests
    {
        [Fact]
        public void DeveCriarDoencaValida()
        {
            var doenca = new DoencaEntity
            {
                nome = "Infecção",
                gravidade = "Grave"
            };

            Assert.Equal("Infecção", doenca.nome);
            Assert.Equal("Grave", doenca.gravidade);
        }
    }
}
