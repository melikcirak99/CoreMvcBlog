using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfPostRepository : GenericRepository<Post>, IPostDal
    {
        public override Post Get(int id)
        {
            return dbset.Include(x => x.Category).Include(x => x.Writer).Include(x => x.Comments).Where(x => x.PostId == id).FirstOrDefault();
        }
        public IEnumerable<Post> Carousel(int count)
        {
            return GetAll(x => x.IsActive == true).OrderByDescending(x => x.PostCreatedTime).Take(count).ToList();
        }


        public override IEnumerable<Post> GetAll()
        {
            return dbset.Include(x => x.Category).Include(x => x.Writer).Include(x => x.Comments);
        }

        public override IEnumerable<Post> GetAll(Expression<Func<Post, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Comments);
        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            return GetAll(x => x.CategoryId == categoryId && x.IsActive == true).ToList();
        }


        public IEnumerable<Post> LatestNews(int count)
        {
            return GetAll(x => x.IsActive == true).OrderByDescending(x => x.PostCreatedTime).Take(count).ToList();
        }

        public IEnumerable<Post> TrendingNow(int count)
        {
            return GetAll(x => x.IsActive == true).OrderByDescending(x => x.PostView).Take(count).ToList();
        }

        public IEnumerable<Post> BestOfTheWeek(int count)
        {
            return GetAll(x => x.IsActive == true).OrderByDescending(x => x.PostView).Take(count);
        }

        public IEnumerable<Post> MostPopular()
        {
            return GetAll(x => x.IsActive == true).OrderByDescending(x => x.PostView).Take(4);
        }

        public int PostsInTrushCount()
        {
            return dbset.Count(x => x.IsActive == false);
        }

        public Post GetPostsBySeoTitle(string seoTitle)
        {
            return dbset.Where(x => x.PostSeoTitle == seoTitle && x.IsActive == true).FirstOrDefault();
        }

        public IEnumerable<Post> Search(string src)
        {
            return GetAll(x => x.PostTitle.Contains(src) || x.Category.CategoryName.Contains(src) || x.PostSeoTitle.Contains(src) || x.Writer.WriterFirstName == src && x.IsActive == true);
        }

        public void PostViewIncrement(int postId)
        {
            Post post = Get(postId);
            post.PostView += 1;
            db.SaveChanges();
        }

        public void OutOfTrash(int postId)
        {
            Post post = Get(postId);
            post.IsActive = true;
            db.SaveChanges();
        }

        public void AddToTrash(int postId)
        {
            Post post = Get(postId);
            post.IsActive = false;
            db.SaveChanges();
        }
    }
}
