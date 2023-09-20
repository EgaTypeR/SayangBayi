using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Article
    {
        //fields
        private int articleId;
        private string title;
        private string content;
        private Writer author;

        //properties
        public int ArticleId
        {
            get { return articleId; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public Writer Author
        {
            get { return author; }
        }

        //constructor
        public Article(int articleId, string title, string content, Writer author)
        {
            this.articleId = articleId;
            this.title = title;
            this.content = content;
            this.author = author;
        }

        //method
        public void editContent()
        {
            //codes
        }
    }
}
