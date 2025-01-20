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
            ArticleList.ItemsSource = new List<Article> { new Article { Title = "Loading...", Summary = "" } };

            var articles = await FetchArticlesAsync();
            ArticleList.ItemsSource = articles;
            if(ArticleList.Items.Count>0) ArticleList.SelectedIndex = 0;
        }

        private async Task<List<Article>> FetchArticlesAsync()
        {
            var articles = new List<Article>();
            try
            {
                using (var client = new HttpClient())
                {
                    var responseBytes = await client.GetByteArrayAsync("https://dynamic-api.misaki-chan.world/genshin/bbs/ja");
                    var responseString = System.Text.Encoding.UTF8.GetString(responseBytes);
                    var root = JsonSerializer.Deserialize<Root>(responseString);

                    if (root != null)
                    {
                        foreach (var result in root.Results)
                        {
                            string AddContent = "";
                            if (result.Content.IsSimple)
                            {
                                foreach (var img in result.Content.Images)
                                {
                                    AddContent += $"<br/><img src=\"{img}\"/>";
                                }
                            }
                            articles.Add(new Article
                            {
                                Title = result.Subject,
                                Summary = result.Description,
                                Content = result.Content.HTMLText + AddContent
                            });
                        }
                    }
                }
            }catch(Exception ex)
            {
                Log.Error(ex);
                Dialog.Error("取得エラー", $"{ex}");
                Close();
            }
            return articles;
        }

        private void ArticleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArticleList.SelectedItem is Article selectedArticle)
            {
                HtmlViewer.NavigateToString("<meta charset=\"UTF-8\"><style>img { width: 100%; height: auto; }\niframe { width: 100%; aspect-ratio: 16 / 9;}</style>" + selectedArticle.Content);
                Title = selectedArticle.Title;
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