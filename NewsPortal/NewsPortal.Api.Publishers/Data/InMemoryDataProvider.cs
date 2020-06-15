using System.Collections.Generic;

namespace NewsPortal.Api.Publishers.Data
{
    public static class InMemoryDataProvider
    {
        public static IEnumerable<Publisher> GetInMemoryDataPublishers() => new List<Publisher>()
        {
            new Publisher()
            {
                Id = "abc-news-au",
                Name = "ABC News (AU)",
                Description= "Australia's most trusted source of local, national and world news. Comprehensive, independent, in-depth analysis, the latest business, sport, weather and more.",
                Url = "http://www.abc.net.au/news",
                Category = "general",
                Language = "en",
                Country = "au"
            },
            new Publisher()
            {
                Id = "aftenposten",
                Name = "Aftenposten",
                Description = "Norges ledende nettavis med alltid oppdaterte nyheter innenfor innenriks, utenriks, sport og kultur.",
                Url = "https://www.aftenposten.no",
                Category = "general",
                Language = "no",
                Country = "no"
            },
            new Publisher()
            {
                Id = "ansa",
                Name = "ANSA.it",
                Description =  "Agenzia ANSA: ultime notizie, foto, video e approfondimenti su: cronaca, politica, economia, regioni, mondo, sport, calcio, cultura e tecnologia.",
                Url = "http://www.ansa.it",
                Category = "general",
                Language = "it",
                Country = "it"
            },
            new Publisher()
            {
                Id = "bbc-news",
                Name = "BBC News",
                Description =  "Use BBC News for up-to-the-minute news, breaking news, video, audio and feature stories. BBC News provides trusted World and UK news as well as local and regional perspectives. Also entertainment, business, science, technology and health news.",
                Url = "http://www.bbc.co.uk/news",
                Category = "general",
                Language = "en",
                Country = "gb"
            },
            new Publisher()
            {
                Id = "cnn",
                Name = "CNN",
                Description = "View the latest news and breaking news today for U.S., world, weather, entertainment, politics and health at CNN",
                Url = "http://us.cnn.com",
                Category = "general",
                Language = "en",
                Country = "us"
            },
            new Publisher()
            {
                Id = "fox-news",
                Name = "Fox News",
                Description = "Breaking News, Latest News and Current News from FOXNews.com. Breaking news and video. Latest Current News: U.S., World, Entertainment, Health, Business, Technology, Politics, Sports.",
                Url = "http://www.foxnews.com",
                Category = "general",
                Language = "en",
                Country = "us"
            },
            new Publisher()
            {
                Id = "fox-sports",
                Name = "Fox Sports",
                Description = "Find live scores, player and team news, videos, rumors, stats, standings, schedules and fantasy games on FOX Sports.",
                Url = "http://www.foxsports.com",
                Category = "sports",
                Language = "en",
                Country = "us"
            },
            new Publisher()
            {
                Id = "globo",
                Name = "Globo",
                Description = "Só na globo.com você encontra tudo sobre o conteúdo e marcas do Grupo Globo. O melhor acervo de vídeos online sobre entretenimento, esportes e jornalismo do Brasil.",
                Url = "http://www.globo.com/",
                Category = "general",
                Language = "pt",
                Country = "br"
            },
            new Publisher()
            {
                Id = "rbc",
                Name = "RBC",
                Description = "Главные новости политики, экономики и бизнеса, комментарии аналитиков, финансовые данные с российских и мировых биржевых систем на сайте rbc.ru.",
                Url = "https://www.rbc.ru",
                Category = "general",
                Language = "ru",
                Country = "ru"
            },
            new Publisher()
            {
                Id = "rt",
                Name = "RT",
                Description = "Актуальная картина дня на RT: круглосуточное ежедневное обновление новостей политики, бизнеса, финансов, спорта, науки, культуры. Онлайн-репортажи с места событий. Комментарии экспертов, актуальные интервью, фото и видео репортажи.",
                Url = "https://russian.rt.com",
                Category = "general",
                Language = "ru",
                Country = "ru"
            }
        };
    }
}