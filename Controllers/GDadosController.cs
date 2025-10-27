using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;

namespace SisJur.Controllers
{
    public class GDadosController : Controller
    {
        private readonly Contexto contexto;

        public GDadosController(Contexto context)
        {
            this.contexto = context;
        }

        public IActionResult dropAll()
        {
            contexto.Database.ExecuteSqlRaw("delete from varas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('varas', RESEED, 0)");

            contexto.Database.ExecuteSqlRaw("delete from processos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('processos', RESEED, 0)");

            contexto.Database.ExecuteSqlRaw("delete from advogados");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('advogados', RESEED, 0)");

            contexto.Database.ExecuteSqlRaw("delete from tipoprocessos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('tipoprocessos', RESEED, 0)");

            contexto.Database.ExecuteSqlRaw("delete from areas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('areas', RESEED, 0)");

  
            return View();
        }


        public IActionResult Areas()
        {
           contexto.Database.ExecuteSqlRaw("delete from Areas");
           contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Areas', RESEED, 0)");

            Area a1 = new Area("Cível");
            Area a2 = new Area("Criminal"); 
            Area a3 = new Area("Trabalhista");
            Area a4 = new Area("Família");
            Area a5 = new Area("Empresarial");
            Area a6 = new Area("Previdenciário");
            Area a7 = new Area("Ambiental");
            Area a8 = new Area("Consumidor");
                
            contexto.Areas.Add(a1);
            contexto.Areas.Add(a2);
            contexto.Areas.Add(a3); 
            contexto.Areas.Add(a4);
            contexto.Areas.Add(a5);
            contexto.Areas.Add(a6);
            contexto.Areas.Add(a7);
            contexto.Areas.Add(a8);

            contexto.SaveChanges();

            return View(contexto.Areas.ToList());
        }

        public IActionResult TipoProcessos()
        {
            contexto.Database.ExecuteSqlRaw("delete from tipoprocessos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('tipoprocessos', RESEED, 0)");
          
            string[] tipos = {
                "Ação de Cobrança",
                "Ação Reparação de Danos",
                "Ação Penal",
                "Reclamação Trabalhista",
                "Divórcio",
                "Falência",
                "Aposentadoria",
                "Ação Civil Pública"
            };

            for (int i = 0; i < tipos.Length; i++)
            {
                TipoProcesso tp = new TipoProcesso();
                tp.descricao = tipos[i];

                contexto.TipoProcessos.Add(tp);
            }

            contexto.SaveChanges();

            return View(contexto.TipoProcessos.ToList());
        }

        public IActionResult Advogados ()
        {
            contexto.Database.ExecuteSqlRaw("delete from advogados");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('advogados', RESEED, 0)");

            int cid = 0;

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vSobrenomes = { "Silva", "Santos", "Oliveira", "Souza", "Rodrigues", "Ferreira", "Almeida", "Costa", "Gomes", "Martins", "Araújo", "Barbosa", "Ribeiro", "Carvalho", "Lima", "Gonçalves", "Melo", "Pereira", "Lopes", "Soares", "Fernandes", "Vieira", "Rocha", "Dias", "Nunes", "Cavalcante", "Monteiro", "Teixeira", "Cardoso", "Moura", "Campos", "Moreira", "Freitas", "Fonseca", "Barros", "Cruz", "Mendes", "Azevedo", "Castro", "Farias", "Batista", "Duarte", "Cunha", "Vasconcelos", "Guimarães", "Tavares", "Rezende", "Coelho", "Siqueira", "Magalhães" };
            string[] vCidade = { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Salvador", "Fortaleza", "Curitiba", "Recife", "Porto Alegre", "Goiânia", "Manaus" };
            string[] vEstado = { "SP", "RJ", "MG", "BA", "CE", "PR", "PE", "RS", "GO", "AM" };

            for (int i = 0; i < 100; i++)
            {
                Random rand = new Random();
              
                Advogado advogado = new Advogado();

                advogado.nome = ((i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2]) + " " + vSobrenomes[rand.Next(0, vSobrenomes.Length)];

                advogado.cidade = vCidade[rand.Next(0, vCidade.Length)];
                advogado.estado = vEstado[rand.Next(0, vEstado.Length)];
                advogado.idade = rand.Next(25, 80);
                advogado.areaid = rand.Next(1, 8);

                contexto.Advogados.Add(advogado);
            }

            contexto.SaveChanges();
            return View(contexto.Advogados.Include(a => a.area).ToList());
        }


        public IActionResult Processos()
        {
            contexto.Database.ExecuteSqlRaw("delete from processos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('processos', RESEED, 0)");
            
            Random rand = new Random();

            string[] vDescricaoProcessos = { "Ação de Indenização por Danos Morais", "Ação de Cobrança de Dívida", "Ação de Divórcio Consensual", "Ação Trabalhista por Horas Extras", "Ação de Usucapião", "Ação de Alimentos", "Ação de Despejo por Falta de Pagamento", "Ação de Reconhecimento de Paternidade", "Ação de Inventário e Partilha", "Ação Penal por Roubo", "Ação Penal por Tráfico de Drogas", "Ação Penal por Homicídio Culposo no Trânsito", "Ação Penal por Estelionato", "Ação Penal por Lesão Corporal", "Ação Penal por Violência Doméstica", "Ação Trabalhista por Rescisão Indireta", "Ação Trabalhista por Assédio Moral", "Ação Trabalhista por Acidente de Trabalho", "Ação Trabalhista por Equiparação Salarial", "Ação Trabalhista por Rec. de Vínculo Empregatício", "Ação Tributária para Revisão de Imposto de Renda", "Ação Tributária para Anulação de Multa Fiscal", "Ação Tributária para Restituição de Tributos Indevidos", "Ação Tributária para Discussão de Dívida Ativa", "Ação Tributária para Impug. de Auto de Infração" };

            for (int i = 0; i < 500; i++)
            {
                Processo p = new Processo();
                p.descricao = vDescricaoProcessos[rand.Next(0, vDescricaoProcessos.Length)];
                p.entrada = DateTime.Now.AddDays(-rand.Next(0, 1825)); // Até 5 anos atrás
                p.tipoprocessoid = rand.Next(1, 8);
                p.status = (Status)rand.Next(0, 3);
                
                contexto.Processos.Add(p);
            }
            contexto.SaveChanges();

            return View(contexto.Processos
                .Include(p => p.tipoprocesso)
                .ToList());
        }

        public IActionResult Varas()
        {
            contexto.Database.ExecuteSqlRaw("delete from varas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('varas', RESEED, 0)");

            Random rand = new Random();

            string[] vJuiz = { "Ana Beatriz Silva", "Bruno Henrique Souza", "Carla Mendes Oliveira", "Daniela Costa Rodrigues", "Eduardo Ferreira Almeida", "Fernanda Gomes Martins", "Gabriel Araújo Barbosa", "Helena Ribeiro Carvalho", "Igor Lima Gonçalves", "Juliana Melo Pereira", "Kleber Lopes Soares", "Larissa Fernandes Vieira", "Marcos Rocha Dias", "Natália Nunes Cavalcante", "Otávio Monteiro Teixeira", "Patrícia Cardoso Moura", "Quésia Campos Moreira", "Rafael Freitas Fonseca", "Sabrina Barros Cruz", "Thiago Mendes Azevedo" };

            for (int i = 0; i < 5000; i++)
            {
                Vara vara = new Vara();

                vara.advogadoid = rand.Next(1, 101);
                vara.processoid = rand.Next(1, 501);
                vara.juiz = vJuiz[rand.Next(0, vJuiz.Length)];
                vara.valorcausa = (float)(rand.Next(1, 300000) + rand.NextDouble());

                contexto.Varas.Add(vara);
            }

            contexto.SaveChanges();
           
            return View(contexto.Varas
                .Include(a => a.Advogado)
                .Include(p => p.Processo)
                .ToList());
        }

    }
}
