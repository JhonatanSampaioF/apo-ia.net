using apo_ia.net.Domain.Entities;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Infraestructure.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(ApplicationContext context)
        {
            // Locais
            if (!context.Local.Any())
            {
                var locais = new List<LocalEntity>
                {
                    new LocalEntity { nome = "Abrigo Central", endereco = "Rua A, 123", capacidade = 50, qtdAbrigados = 0 },
                    new LocalEntity { nome = "Abrigo Leste", endereco = "Rua B, 456", capacidade = 30, qtdAbrigados = 0 },
                };
                context.Local.AddRange(locais);
                context.SaveChanges();
            }

            // Grupos de habilidade
            if (!context.GrupoHabilidade.Any())
            {
                var grupos = new List<GrupoHabilidadeEntity>
                {
                    new GrupoHabilidadeEntity { nome = "Serviços Gerais" },
                    new GrupoHabilidadeEntity { nome = "Cuidados Médicos" },
                };
                context.GrupoHabilidade.AddRange(grupos);
                context.SaveChanges();
            }

            // Habilidades
            if (!context.Habilidade.Any())
            {
                var grupoServ = context.GrupoHabilidade.First(g => g.nome == "Serviços Gerais");
                var grupoMed = context.GrupoHabilidade.First(g => g.nome == "Cuidados Médicos");

                var habilidades = new List<HabilidadeEntity>
                {
                    new HabilidadeEntity { nome = "Cozinha", prioridade = 1, grupoHabilidadeId = grupoServ.id },
                    new HabilidadeEntity { nome = "Limpeza", prioridade = 2, grupoHabilidadeId = grupoServ.id },
                    new HabilidadeEntity { nome = "Primeiros Socorros", prioridade = 1, grupoHabilidadeId = grupoMed.id },
                    new HabilidadeEntity { nome = "Enfermagem", prioridade = 2, grupoHabilidadeId = grupoMed.id },
                };
                context.Habilidade.AddRange(habilidades);
                context.SaveChanges();
            }

            // Doenças
            if (!context.Doenca.Any())
            {
                var doencas = new List<DoencaEntity>
                {
                    new DoencaEntity { nome = "Gripe", gravidade = "Leve" },
                    new DoencaEntity { nome = "Fratura", gravidade = "Moderada" },
                    new DoencaEntity { nome = "Infecção", gravidade = "Grave" },
                };
                context.Doenca.AddRange(doencas);
                context.SaveChanges();
            }

            // Abrigados
            if (!context.Abrigado.Any())
            {
                var local1 = context.Local.First(l => l.nome == "Abrigo Central");
                var local2 = context.Local.First(l => l.nome == "Abrigo Leste");
                var gripe = context.Doenca.First(d => d.nome == "Gripe");
                var fratura = context.Doenca.First(d => d.nome == "Fratura");
                var infeccao = context.Doenca.First(d => d.nome == "Infecção");

                var abrigados = new List<AbrigadoEntity>
                {
                    new() { nome = "Maria", idade = 30, altura = 1.65, peso = 60, cpf = "12345678901", voluntario = true, ferimento = "Corte leve", localId = local1.id, doencas = new List<DoencaEntity>{ gripe } },
                    new() { nome = "João", idade = 45, altura = 1.75, peso = 80, cpf = "23456789012", voluntario = false, ferimento = "Fratura no braço", localId = local1.id, doencas = new List<DoencaEntity>{ fratura } },
                    new() { nome = "Ana", idade = 22, altura = 1.60, peso = 55, cpf = "34567890123", voluntario = true, ferimento = "Escoriações", localId = local2.id, doencas = new List<DoencaEntity>{ gripe } },
                    new() { nome = "Carlos", idade = 50, altura = 1.80, peso = 90, cpf = "45678901234", voluntario = false, ferimento = "Infecção grave", localId = local2.id, doencas = new List<DoencaEntity>{ infeccao } },
                    new() { nome = "Beatriz", idade = 40, altura = 1.68, peso = 65, cpf = "56789012345", voluntario = true, ferimento = "Corte profundo", localId = local1.id, doencas = new List<DoencaEntity>{ fratura } },
                    new() { nome = "Lucas", idade = 28, altura = 1.72, peso = 72, cpf = "67890123456", voluntario = false, ferimento = "Infecção moderada", localId = local1.id, doencas = new List<DoencaEntity>{ infeccao } },
                };
                context.Abrigado.AddRange(abrigados);
                context.SaveChanges();
            }

            // Voluntários
            if (!context.Voluntario.Any())
            {
                var cozinha = context.Habilidade.First(h => h.nome == "Cozinha");
                var primeirosSocorros = context.Habilidade.First(h => h.nome == "Primeiros Socorros");
                var enfermagem = context.Habilidade.First(h => h.nome == "Enfermagem");

                var maria = context.Abrigado.First(a => a.nome == "Maria");
                var ana = context.Abrigado.First(a => a.nome == "Ana");
                var beatriz = context.Abrigado.First(a => a.nome == "Beatriz");

                var voluntarios = new List<VoluntarioEntity>
                {
                    new() { abrigadoId = maria.id, capacidadeMotora = "Boa", habilidades = new List<HabilidadeEntity> { cozinha, primeirosSocorros } },
                    new() { abrigadoId = ana.id, capacidadeMotora = "Excelente", habilidades = new List<HabilidadeEntity> { primeirosSocorros } },
                    new() { abrigadoId = beatriz.id, capacidadeMotora = "Moderada", habilidades = new List<HabilidadeEntity> { cozinha, enfermagem } },
                };
                context.Voluntario.AddRange(voluntarios);
                context.SaveChanges();
            }
        }
    }
}
