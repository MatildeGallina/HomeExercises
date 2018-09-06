using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.DataAccess
{
    public class SqlRepository 
        : DbContext, IRepository<SuperHero>, IRepository<Villain>
    {
        public SqlRepository(DbContextOptions options)
            : base(options)
        { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Villain> Villains { get; set; }

        List<SuperHero> IRepository<SuperHero>.GetAll()
        {
            return SuperHeroes.ToList();
        }

        SuperHero IRepository<SuperHero>.Get(int id)
        {
            return SuperHeroes.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<SuperHero>.Insert(SuperHero model)
        {
            SuperHeroes.Add(model);
            return SaveChanges();
        }

        void IRepository<SuperHero>.Update(SuperHero model)
        {
            SuperHeroes.Update(model);
            SaveChanges();
        }

        void IRepository<SuperHero>.Delete(int id)
        {
            var model = SuperHeroes.FirstOrDefault(x => x.Id == id);
            SuperHeroes.Remove(model);
            SaveChanges();
        }

        List<Villain> IRepository<Villain>.GetAll()
        {
            return Villains.ToList();
        }

        Villain IRepository<Villain>.Get(int id)
        {
            return Villains.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<Villain>.Insert(Villain model)
        {
            Villains.Add(model);
            return SaveChanges();
        }

        void IRepository<Villain>.Update(Villain model)
        {
            Villains.Update(model);
            SaveChanges();
        }

        void IRepository<Villain>.Delete(int id)
        {
            var model = Villains.FirstOrDefault(x => x.Id == id);
            Villains.Remove(model);
            SaveChanges();
        }
    }
}
