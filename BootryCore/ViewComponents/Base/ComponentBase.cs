using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BootryCore.ViewComponents.Base
{
    public class ComponentBase
    {
        private  PostManager postManager;
        private  CategoryManager categoryManager;
        private  TagManager tagManager;
        private  CommentManager commentManager;
        private  UserManager userManager;
        private  WriterManager writerManager;
        private  SettingManager settingManager;
        public ComponentBase()
        {
        }
        public  PostManager GetPostManager()
        {
            if (postManager == null)
            {
                postManager = new PostManager(new EfPostRepository());
                return postManager;
            }
            return postManager;
        }

        public CategoryManager GetCategoryManager()
        {
            if (categoryManager == null)
            {
                categoryManager = new CategoryManager(new EfCategoryRepository());
                return categoryManager;
            }
            return categoryManager;
        }

        public TagManager GetTagManager()
        {
            if (tagManager == null)
            {
                tagManager = new TagManager(new EfTagRepository());
                return tagManager;
            }
            return tagManager;
        }
        public CommentManager GetCommentManager()
        {
            if (commentManager == null)
            {
                commentManager  = new CommentManager(new EfCommentRepository());
                return commentManager;
            }
            return commentManager;
        }
        public UserManager GetUserManager()
        {
            if (userManager == null)
            {
                userManager = new UserManager(new EfUserRepository());
                return userManager;
            }
            return userManager;
        }
        public WriterManager GetWriterManager()
        {
            if (writerManager == null)
            {
                writerManager = new WriterManager(new EfWriterRepository());
                return writerManager;
            }
            return writerManager;
        }
        public SettingManager GetSettingManager()
        {
            if (settingManager == null)
            {
                settingManager = new SettingManager(new EfSettingRepository());
                return settingManager;
            }
            return settingManager;
        }

    }
}
