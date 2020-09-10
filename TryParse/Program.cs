using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ScrapySharp.Network;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Parsing;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;

namespace TryParse
{

    class Program
    {
        static void Main(string[] args)
        {
            //Parse rus = new Parse(@"https://www.cofix.ru/menu/", "//body/div/div/div/div/p[@class='middle']");
            //rus.get_data();

            //Parse bel = new Parse(@"https://finance.tut.by/news563653.html", "//body/div/div/div/div/div/div/div/div/table/tbody/tr/td");
            //bel.get_data();

            //Parse ua = new Parse(@"https://ubr.ua/market/agricultural-market/kak-izmenilas-stoimost-chashki-kofe-v-ukraine-413137", "//body/div/div/div/div/div/div/div/div/div/div/p");
            //ua.get_data();

            //Parse pl = new Parse(@"https://3pulse.com/ru/geo/poland/prices", "//body/div/div/div/main/div/div/table/tbody/tr[@class=' highlighted']");
            //pl.get_data();

            //Parse lv = new Parse(@"https://triplinks.ru/skolko-stoit/vilnyus/", "//body/div/div/div/main/article/div/div/ul/li/ul/li");
            //lv.get_data();

            //Parse val = new Parse(@"https://www.google.com/search?q=%D0%BA%D1%83%D1%80%D1%81+%D0%B4%D0%BE%D0%BB%D0%BB%D0%B0%D1%80%D0%B0+%D1%81%D1%88%D0%B0&oq=%D0%BA%D1%83%D1%80%D1%81+%D0%B4%D0%BE%D0%BB%D0%BB%D0%B0%D1%80%D0%B0+%D1%81%D1%88%D0%B0&aqs=chrome.0.69i59j0l7.4495j1j7&sourceid=chrome&ie=UTF-8", "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/span");
            //val.get_data();

            //Console.ReadKey();
            // Текущая дата
            string data = string.Empty;
            // Адрес сайта с курсом валюты
            string url = "http://www.cbr.ru/currency_base/D_print.aspx?date_req=";
            // HTML сайта с курсом валюты
            string html = string.Empty;
            // Регулярное выражение
            string pattern = "Доллар СШАrn(.*)";


            // Определяем текущую дату
            DateTime today = DateTime.Now;
            data = today.Date.ToShortDateString();


            // Формируем адрес сайта
            // http://www.cbr.ru/currency_base/D_print.aspx?date_req=07.03.2010
            url += data;


            // Отправляем GET запрос и получаем в ответ HTML-код сайта с курсом валюты
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());
            html = myStreamReader.ReadToEnd();


            // Вытаскиваем из HTML-кода нужные данные
            Match match = Regex.Match(html, pattern);


            Console.WriteLine("Курс Доллара США на {0} равен {1} руб.", data, match.Groups[1].ToString());
            Console.ReadLine();
        }
    }
}