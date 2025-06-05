using apo_ia.net.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apo_ia.net.Tests
{
    public class AbrigadoTests
    {
        [Fact]
        public void DeveCriarAbrigado_ComDadosBasicos()
        {
            var abrigado = new AbrigadoEntity
            {
                nome = "João",
                idade = 30,
                altura = 1.75,
                peso = 80,
                cpf = "12345678901",
                voluntario = true,
                ferimento = "Corte leve",
                localId = 1
            };

            Assert.Equal("João", abrigado.nome);
            Assert.True(abrigado.voluntario.Value);
        }

        [Fact]
        public void DeveAdicionarDoenca()
        {
            var gripe = new DoencaEntity { nome = "Gripe" };
            var abrigado = new AbrigadoEntity();

            abrigado.doencas.Add(gripe);

            Assert.Single(abrigado.doencas);
            Assert.Equal("Gripe", abrigado.doencas[0].nome);
        }
    }
}
