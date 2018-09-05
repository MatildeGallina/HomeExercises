using SuperHeroes.Infrastructure;
using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.DataAccess
{
    public class MemoryRepository : IRepository<SuperHero>, IRepository<Villain>
    {
        private List<SuperHero> _superHeroes;
        private List<Villain> _villains;

        public MemoryRepository()
        {
            _superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Batman",
                    SecretName = "Bruce Wayne",
                    Birth = new DateTime(1980, 3, 4),
                    Strength = 10,
                    Wealth = 1000000000,
                    CanFly = false,
                },
            };

            _villains = new List<Villain>
            {
                new Villain
                {
                    Id = 1,
                    Name = "The Pinguin",
                    BadActs = "Bruciato 17 persone, venduto ombrelli in nero per 7 ml di euro",
                    HasMinions = true,
                    Gender = GenderType.Male,
                }
            };
        }

        List<SuperHero> IRepository<SuperHero>.GetAll()
        {
            return _superHeroes.ToList();
        }

        SuperHero IRepository<SuperHero>.Get(int id)
        {
            var model = _superHeroes.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("model not found");

            return model;
        }

        int IRepository<SuperHero>.Insert(SuperHero model)
        {
            model.Id = _superHeroes.Count > 0
                ? _superHeroes.Max(x => x.Id) + 1
                : 1;

            _superHeroes.Add(model);

            return model.Id;
        }

        void IRepository<SuperHero>.Update(SuperHero model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var oldIndex = _superHeroes.FindIndex(x => x.Id == model.Id);

            if (oldIndex == -1)
                throw new NotFoundException("model not found");

            _superHeroes[oldIndex] = model;
        }

        void IRepository<SuperHero>.Delete(int id)
        {
            var model = _superHeroes.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("model not found");

            _superHeroes.Remove(model);
        }

        List<Villain> IRepository<Villain>.GetAll()
        {
            return _villains.ToList();
        }

        Villain IRepository<Villain>.Get(int id)
        {
            var model = _villains.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("model not found");

            return model;
        }

        int IRepository<Villain>.Insert(Villain model)
        {
            model.Id = _villains.Count > 0
                ? _villains.Max(x => x.Id) + 1
                : 1;

            _villains.Add(model);

            return model.Id;
        }

        void IRepository<Villain>.Update(Villain model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var oldIndex = _villains.FindIndex(x => x.Id == model.Id);

            if (oldIndex == -1)
                throw new NotFoundException("model not found");

            _villains[oldIndex] = model;
        }

        void IRepository<Villain>.Delete(int id)
        {
            var model = _villains.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("model not found");

            _villains.Remove(model);
        }
    }
}
