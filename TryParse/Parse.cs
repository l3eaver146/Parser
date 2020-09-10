using System;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace TryParse
{
    class Parse
    {
        private string URL { get; set; }//@"https://www.cofix.ru/menu/" example
        private string Xpath { get; set; }//"//body/div/div/div/div/p[@class='middle']" example

        public Parse(string URL,string Xpath)
        {
            this.URL = URL;
            this.Xpath = Xpath;
        }
        public async void get_data()
        {
            var html = this.URL;

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes(this.Xpath);
            string result = "";
            switch (this.URL)
            {
                case @"https://www.cofix.ru/menu/"://russia
                       result = "Средняя стоисость кофе в России : " + htmlNodes[0].InnerText;
                    break;
                case @"https://finance.tut.by/news563653.html"://belarus
                        result = "Средняя стоисость кофе в Беларуси : " + htmlNodes[8].InnerText.Substring(6);
                    break;
                case @"https://ubr.ua/market/agricultural-market/kak-izmenilas-stoimost-chashki-kofe-v-ukraine-413137":  //ukraine 
                        result = "Средняя стоисость кофе в Украине : " + htmlNodes[6].InnerText.Substring(152);
                        result = result.Substring(0, result.Length - 204);     
                    break;
                case @"https://3pulse.com/ru/geo/poland/prices"://poland
                        result = "Средняя стоисость кофе в Польше : " + htmlNodes[1].InnerText.Substring(23);                
                    break;
                case @"https://triplinks.ru/skolko-stoit/vilnyus/"://lithvania
                    result = "Средняя стоисость кофе в Литве : " + htmlNodes[0].InnerText.Substring(15);
                    result = result.Substring(0, result.Length - 40);
                    break;
            }
            Console.OutputEncoding = Encoding.Unicode;
            await Task.Run(()=>Console.WriteLine(result));
        }

        public decimal convert(double data)
        {
            decimal result = 0;



            return result;
        }
    }
}
