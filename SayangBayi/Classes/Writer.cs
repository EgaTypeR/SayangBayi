using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Writer : User
    {
        // Additional Properties for Writer
        public string Profile { get; set; }
        public List<Article> Articles { get; private set; } = new List<Article>();

        // Constructor
        public Writer(int userId, string username, string password, string email, string profile)
            : base(userId, username, password, email)
        {
            Profile = profile;
        }

        // Methods

        public Article WriteArticle(int articleId, string title, string content)
        {
            // Create and return a new Article written by the Writer
            Article article = new Article(articleId, title, content, this);
            Articles.Add(article);
            return article;
        }

        public void EditArticle(Article article)
        {
            article.editContent();
        }

        public void VoteArticle(Article article)
        {
            article.vote += 1;
        }

    }
}
