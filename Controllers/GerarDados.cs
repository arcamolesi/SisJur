using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;

namespace SisJur.Controllers
{
    public class GerarDados : Controller
    {
        private readonly Contexto contexto;

        public GerarDados(Contexto context)
        {
            contexto = context;
        }


        public IActionResult Areas()
        {
            contexto.Database.ExecuteSqlRaw("delete from Areas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Areas', RESEED, 0)");

            Area area1 = new Area("Cível");
            contexto.Areas.Add(area1);

            Area area2 = new Area("Penal");
            contexto.Areas.Add(area2);

            Area area3 = new Area("Trabalhista");
            contexto.Areas.Add(area3);

            Area area4 = new Area("Administrativo");
            contexto.Areas.Add(area4);

            Area area5 = new Area("Tributário");
            contexto.Areas.Add(area5);

            Area area6 = new Area("Eleitoral");
            contexto.Areas.Add(area6);

            contexto.SaveChanges();
            return View(contexto.Areas.ToList());
        }

        public IActionResult TiposProcessos()
        {
            contexto.Database.ExecuteSqlRaw("delete from tipoprocessos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('tipoprocessos', RESEED, 0)");

            TipoProcesso tipo1 = new TipoProcesso("Declaratória");
            contexto.TipoProcessos.Add(tipo1);

            TipoProcesso tipo2 = new TipoProcesso("Constitutiva");  
            contexto.TipoProcessos.Add(tipo2);

            TipoProcesso tipo3 = new TipoProcesso("Obrigacional");
            contexto.TipoProcessos.Add(tipo3);

            TipoProcesso tipo4 = new TipoProcesso("Executória");
            contexto.TipoProcessos.Add(tipo4);

            TipoProcesso tipo5 = new TipoProcesso("Cautelar");
            contexto.TipoProcessos.Add(tipo5);

            TipoProcesso tipo6 = new TipoProcesso("Fiscal");    
            contexto.TipoProcessos.Add(tipo6);
          
            contexto.SaveChanges();
            return View(contexto.TipoProcessos.ToList());
        }


        public IActionResult Advogados()
        {
            contexto.Database.ExecuteSqlRaw("delete from advogados");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('advogados', RESEED, 0)");
            Random rand = new Random();
            int cid = 0; 

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vSobrenome = { "Silva", "Santos", "Oliveira", "Souza", "Rodrigues", "Ferreira", "Almeida", "Costa", "Gomes", "Martins", "Araújo", "Barbosa", "Rocha", "Dias", "Nunes", "Carvalho", "Lima", "Ribeiro", "Melo", "Azevedo", "Teixeira", "Moreira", "Moura", "Cavalcante", "Gonçalves", "Pereira", "Farias", "Cardoso", "Campos", "Freitas", "Santana", "Monteiro", "Cruz", "Vieira", "Castro", "Barros", "Mendes", "Batista", "Lopes", "Figueiredo", "Duarte", "Rezende", "Peixoto", "Cunha", "Vasconcelos", "Siqueira", "Tavares", "Coelho", "Guimarães", "Borges", "Ramos" };
            string[] vCidade = { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Salvador", "Fortaleza", "Curitiba", "Recife", "Porto Alegre", "Goiânia", "Manaus" };
            string[] vEstado = { "SP", "RJ", "MG", "BA", "CE", "PR", "PE", "RS", "GO", "AM" };
          
            for (int i = 0; i < 100; i++)
            {
                Advogado advogado = new Advogado();

                advogado.nome = ((i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2]) + " " + vSobrenome[rand.Next(0, vSobrenome.Length)] ;

                cid = rand.Next(0, vCidade.Length);
                advogado.cidade = vCidade[cid];
                advogado.estado = vEstado[cid];
                advogado.idade = rand.Next(25, 71);
                advogado.areaid = rand.Next(1, 6);
                contexto.Advogados.Add(advogado);
            }

            contexto.SaveChanges();
            
            return View(contexto.Advogados.ToList());
        }


        public IActionResult Processos()
        {
            contexto.Database.ExecuteSqlRaw("delete from processos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('processos', RESEED, 0)");
            Random rand = new Random();
         
            string[] vDescricaoProcesso = { "Ação de Indenização por Danos Morais", "Ação de Cobrança de Dívida", "Ação de Divórcio Consensual", "Ação Trabalhista por Horas Extras", "Ação de Usucapião", "Ação de Alimentos", "Ação de Despejo por Falta de Pagamento", "Ação de Reconhecimento de Paternidade", "Ação de Inventário e Partilha", "Ação Penal por Roubo", "Ação Penal por Tráfico de Drogas", "Ação Penal por Homicídio Culposo no Trânsito", "Ação Penal por Estelionato", "Ação Penal por Lesão Corporal", "Ação Penal por Violência Doméstica", "Ação Trabalhista por Rescisão Indireta", "Ação Trabalhista por Assédio Moral", "Ação Trabalhista por Acidente de Trabalho", "Ação Trabalhista por Equiparação Salarial", "Ação Trabalhista por Rec. de Vínculo Empregatício", "Ação Tributária para Revisão de Imposto de Renda", "Ação Tributária para Anulação de Multa Fiscal", "Ação Tributária para Restituição de Tributos Indevidos", "Ação Tributária para Discussão de Dívida Ativa", "Ação Tributária para Impug. de Auto de Infração" };
        
            for (int i = 0; i < 500; i++)
            {
                Processo processo = new Processo();
                processo.descricao = vDescricaoProcesso[rand.Next(0, vDescricaoProcesso.Length)]; 
                processo.entrada = Convert.ToDateTime("02/01/2010").AddDays(rand.Next(0, 5750));
                processo.status = (Status)(rand.Next(0, 3));
                processo.tipoprocessoid = rand.Next(1, 6);
                
                contexto.Processos.Add(processo);
            }

            contexto.SaveChanges();

            return View(contexto.Processos.Include(tp=>tp.tipoprocesso).ToList());
        }

        public IActionResult Varas()
        {
            contexto.Database.ExecuteSqlRaw("delete from varas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('varas', RESEED, 0)");
            Random rand = new Random();
            string[] vJuiz = { "Ana Beatriz Silva", "Bruno Henrique Costa", "Carla Fernanda Souza", "Daniela Alves Pereira", "Eduardo Luiz Gomes", "Fernanda Cristina Rodrigues", "Gabriel Augusto Lima", "Helena Maria Fernandes", "Igor Rafael Santos", "Juliana Paola Oliveira", "Karla Simone Almeida", "Lucas Matheus Ribeiro", "Mariana Vitória Dias", "Natália Carolina Barbosa", "Otávio Gabriel Moreira", "Patrícia Helena Azevedo", "Rafael Augusto Teixeira", "Sabrina Letícia Monteiro", "Thiago Vinícius Moura", "Vanessa Cristina Cavalcante" };

            for (int i = 0; i < 5000; i++)
            {
                Vara vara = new Vara();

                vara.processoid = rand.Next(1, 500);
                vara.advogadoid = rand.Next(1, 100);
                vara.juiz = vJuiz[rand.Next(0, vJuiz.Length)];
                vara.valorcausa = (float)(rand.Next(1, 300000) + rand.NextDouble());

                contexto.Varas.Add(vara);
            }

            contexto.SaveChanges();

            return View(contexto.Varas.Include(p=>p.Processo).Include(a=>a.Advogado).ToList());
        }
    }
}
