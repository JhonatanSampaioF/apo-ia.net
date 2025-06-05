using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class LocalTests
    {
        [Fact]
        public void DeveCriarLocalComDadosBasicos()
        {
            var local = new LocalEntity
            {
                nome = "Abrigo Leste",
                endereco = "Rua B, 456",
                capacidade = 30,
                qtdAbrigados = 5
            };

            Assert.Equal("Abrigo Leste", local.nome);
            Assert.Equal(30, local.capacidade);
        }
    }
}
