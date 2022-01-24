using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Abstract
{
    public interface IPostService : IService<Post>
    {
        IEnumerable<Post> LatestNews(int count);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
        Post GetPostsBySeoTitle(string seoTitle);
        IEnumerable<Post> TrendingNow(int count);
        IEnumerable<Post> BestOfTheWeek(int count);
        IEnumerable<Post> MostPopular();
        IEnumerable<Post> Carousel(int count);
        IEnumerable<Post> Search(string src);
        int PostsInTrushCount();
        void PostViewIncrement(int postId);
        void OutOfTrash(int postId);
        void AddToTrash(int postId);
    }
}
