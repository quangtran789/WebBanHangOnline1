using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Iterator
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone();
        T CurrentItem();
    }

    public class CategoryIterator : IIterator<Category>
    {
        private List<Category> _categories;
        private int _position = 0;

        public CategoryIterator(List<Category> categories)
        {
            _categories = categories;
        }

        public Category First()
        {
            _position = 0;
            return _categories[_position];
        }

        public Category Next()
        {
            _position++;
            if (!IsDone())
                return _categories[_position];
            else
                return null;
        }

        public bool IsDone()
        {
            return _position >= _categories.Count - 1;
        }

        public Category CurrentItem()
        {
            return _categories[_position];
        }
    }
}