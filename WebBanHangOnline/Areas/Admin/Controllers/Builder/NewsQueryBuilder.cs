using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class NewsQueryBuilder
    {
        private IQueryable<News> _query;

        public NewsQueryBuilder(IQueryable<News> query)
        {
            _query = query;
        }

        public NewsQueryBuilder WithSearchText(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                _query = _query.Where(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText));
            }
            return this;
        }

        public IQueryable<News> Build()
        {
            return _query;
        }
    }

}