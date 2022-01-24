using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete
{
    public class PostManager : Manager<Post>, IPostService
    {
        IPostDal dal;
        public PostManager(IPostDal _dal) : base(_dal)
        {
            dal = _dal;
        }

        public IEnumerable<Post> LatestNews(int count)
        {
            return dal.LatestNews(count);
        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            return dal.GetPostsByCategory(categoryId);
        }

        public IEnumerable<Post> TrendingNow(int count)
        {
            return dal.TrendingNow(count);
        }

        public IEnumerable<Post> Carousel(int count)
        {
            return dal.Carousel(count);
        }

        public IEnumerable<Post> BestOfTheWeek(int count)
        {
            return dal.BestOfTheWeek(count);
        }

        public IEnumerable<Post> MostPopular()
        {
            return dal.MostPopular();
        }

        public int PostsInTrushCount()
        {
            return dal.PostsInTrushCount();
        }

        public Post GetPostsBySeoTitle(string seoTitle)
        {
            return dal.GetPostsBySeoTitle(seoTitle);
        }

        public IEnumerable<Post> Search(string src)
        {
            return dal.Search(src);
        }

        public void PostViewIncrement(int postId)
        {
            dal.PostViewIncrement(postId);
        }

        public void OutOfTrash(int postId)
        {
            dal.OutOfTrash(postId);
        }

        public void AddToTrash(int postId)
        {
            dal.AddToTrash(postId);
        }
    }
}
