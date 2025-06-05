using Xunit;
using apo_ia.net.Application.Services;
using apo_ia.net.Domain.Entities;
using System.Collections.Generic;

namespace apo_ia.net.Tests
{
    public class RecommendationServiceTests
    {
        [Fact]
        public void Deve_Retornar_Voluntarios_Para_Cozinha()
        {
            // Arrange
            var service = new RecommendationService();

            var voluntarios = new List<VoluntarioEntity>
            {
                new VoluntarioEntity
                {
                    id = 1,
                    abrigado = new AbrigadoEntity { nome = "Maria" },
                    habilidades = new List<HabilidadeEntity>
                    {
                        new HabilidadeEntity { nome = "Cozinha" }
                    }
                }
            };

            // Act
            var resultado = service.ResponderPergunta("Quem pode ajudar na cozinha?", voluntarios);

            // Assert
            Assert.Contains("Maria", resultado);
        }
    }
}
