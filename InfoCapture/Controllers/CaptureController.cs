using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using InfoCaptureForWeixin2.Models;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System;

namespace InfoCaptureForWeixin2.Controllers
{
    public class CaptureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCapturedBaiduInfos(int startRec, int daysBefore)
        {
            List<Article> list = FromBaiduWeb(startRec, daysBefore);
            JsonSerializerSettings setting = new JsonSerializerSettings();
            return Json(new { rst = list }, setting);
        }

        public IActionResult GetCapturedZhongSouInfos(int startRec, int daysBefore)
        {
            List<Article> list = FromZhongsSou(startRec, daysBefore);
            JsonSerializerSettings setting = new JsonSerializerSettings();
            return Json(new { rst = list }, setting);
        }

        public IActionResult GetCapturedWeiboInfos(int startRec, int daysBefore)
        {
            List<Article> list = FromWeibo(startRec, daysBefore);
            JsonSerializerSettings setting = new JsonSerializerSettings();
            return Json(new { rst = list }, setting);
        }

        public List<Article> FromBaiduWeb(int startRec, int daysBefore)
        {
            var html = "https://www.baidu.com/s?tn=news&rtt=4&bsst=1&cl=2&wd=%E5%AD%9F%E6%B4%A5&medium=0&x_bfe_rqs=03E80&x_bfe_tjscore=0.486208&tngroupname=organic_news&rsv_dl=news_b_pn&pn=" + startRec;
            var articles = new List<Article>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var postitemsNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class='result']");//*[@class="c-author"]/div/p
            if (postitemsNodes != null)
            {
                foreach (var item in postitemsNodes)
                {
                    var timeNode = item.SelectSingleNode("div/p");
                    if (timeNode.InnerText.Contains("小时"))
                    {
                        //var timeStrs = timeNode.InnerText.Split("  ");
                        //var timeStr = timeStrs[timeStrs.Length - 1].Replace("\t", "").Replace("\n", "");
                        ////timeStr = "2019年12月1日 07:30:00";
                        //DateTime theTime;
                        //DateTime.TryParse(timeStr, out theTime);
                        //var span = theTime.CompareTo(DateTime.Now.AddDays(daysBefore));//往前推2天
                        //if (span > 0)
                        //{
                            var tha = item.SelectSingleNode("h3/a");
                            var href = tha.Attributes["href"].Value;
                            var title = tha.InnerText;
                            var article = new Article();
                            article.Title = title;
                            article.Url = href;
                            articles.Add(article);
                        //}
                    }
                    
                }
            }

            return articles;
        }

        public List<Article> FromZhongsSou(int startRec, int daysBefore)
        {
            var html = "http://news.chinaso.com/newssearch.htm?q=%E5%AD%9F%E6%B4%A5&order=time&page=" + startRec;
            var articles = new List<Article>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var postitemsNodes = htmlDoc.DocumentNode.SelectNodes("/html/body/div[2]/div[2]/ol/li");
            if (postitemsNodes != null)
            {
                foreach (var item in postitemsNodes)
                {
                    var timeNode = item.SelectSingleNode("div/div/p/span");
                    var timeStrs = timeNode.InnerText.Split("&nbsp;-&nbsp;&nbsp;");
                    var timeStr = timeStrs[0];
                    DateTime theTime;
                    DateTime.TryParse(timeStr,out theTime);
                    var span = theTime.CompareTo(DateTime.Now.AddDays(daysBefore));//往前推2天
                    if (span > 0)
                    {
                        var tha = item.SelectSingleNode("h2/a");
                        var href = tha.Attributes["href"].Value;
                        var title = tha.InnerText;
                        var article = new Article();
                        article.Title = title;
                        article.Url = href;
                        articles.Add(article);
                    }
                }
            }

            return articles;
        }

        public List<Article> FromWeibo(int startRec, int daysBefore)
        {
            var html = "https://s.weibo.com/weibo/%25E5%25AD%259F%25E6%25B4%25A5?topnav=1&wvr=6&page=" + startRec;
            var articles = new List<Article>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var postitemsNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='pl_feedlist_index']/div[1]/div/div/div[1]/div[2]");
            if (postitemsNodes != null)
            {
                foreach (var item in postitemsNodes)
                {
                    var timeNode = item.SelectSingleNode("p[@class='from']");//带时间内容的节点
                    var timeStrs = timeNode.InnerText.Split("&nbsp;");
                    var timeStr = timeStrs[0].Replace("\n", "").Trim();
                    DateTime theTime;
                    DateTime.TryParse(timeStr, out theTime);//尽力抽出时间的内容
                    var span = theTime.CompareTo(DateTime.Now.AddDays(daysBefore));//往前推2天
                    if (span > 0)
                    {
                        var thas = item.SelectNodes("p[@class='txt']");
                        var tha = HtmlNode.CreateNode("");
                        tha = thas[0];//有文字的那个p元素

                        var hrefNode = timeNode.SelectSingleNode("a");//从微博时间节点上抽出微博内容的href
                        var href = hrefNode.Attributes["href"].Value;
                        var title = tha.InnerHtml;
                        var article = new Article();
                        article.Title = "<a href='" + href + "' target='_blank'>[点击到内容链接]</a>" + title;
                        article.Url = href;
                        articles.Add(article);
                    }

                }
            }

            return articles;
        }
    }
}
