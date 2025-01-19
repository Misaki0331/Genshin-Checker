using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Genshin_Checker.Model.Misaki_chan.HoYoContent;

namespace Genshin_Checker.GUI.Window
{
    public partial class HoYoContentViewer : System.Windows.Window
    {
        public HoYoContentViewer()
        {
            InitializeComponent();
            InitializeWebView2();
            LoadArticles();
        }

        private async void InitializeWebView2()
        {
            await HtmlViewer.EnsureCoreWebView2Async(null);
        }

        private async void LoadArticles()
        {
            ArticleList.ItemsSource = new List<Article> { new Article { Title = "読み込み中...", Summary = "" } };

            var articles = await FetchArticlesAsync();

            ArticleList.ItemsSource = articles;
        }

        private async Task<List<Article>> FetchArticlesAsync()
        {
            var articles = new List<Article>();

            using (var client = new HttpClient())
            {
                var responseBytes = await client.GetByteArrayAsync("https://dynamic-api.misaki-chan.world/genshin/bbs/ja");
                var responseString = System.Text.Encoding.UTF8.GetString(responseBytes);
                var root = JsonSerializer.Deserialize<Root>(responseString);

                if (root != null)
                {
                    foreach (var result in root.Results)
                    {
                        articles.Add(new Article
                        {
                            Title = result.Subject,
                            Summary = result.Description,
                            Content = $"<meta charset=\"UTF-8\"><style>img {{ max-width: 100%; height: auto; }}</style>{result.Content.HTMLText}"
                        });
                    }
                }
            }

            return articles;
        }

        private void ArticleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArticleList.SelectedItem is Article selectedArticle)
            {
                HtmlViewer.NavigateToString(selectedArticle.Content);
            }
        }
    }

    public class Article
    {
        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Content { get; set; } = "";
    }
}