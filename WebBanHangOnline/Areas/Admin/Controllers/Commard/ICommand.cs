using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin
{
    public interface ICommand
    {
        void Execute(int id);
    }

    public class IsActiveCommand : ICommand
    {
        private readonly ApplicationDbContext db;

        public IsActiveCommand(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Execute(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }

    public class IsHomeCommand : ICommand
    {
        private readonly ApplicationDbContext db;

        public IsHomeCommand(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Execute(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }

    public class IsSaleCommand : ICommand
    {
        private readonly ApplicationDbContext db;

        public IsSaleCommand(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Execute(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
    public class CommandExecutor
    {
        private readonly ICommand _command;

        public CommandExecutor(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand(int id)
        {
            _command.Execute(id);
        }
    }


}