using RahulApp.Data;

namespace RahulApp.Models
{
    public class SqlCountry : ICountry
    {
        private ApplicationDbContext _context;
        public SqlCountry(ApplicationDbContext context)
        {
            _context = context;
        }

        public Country Add(Country addCountry)
        {
            throw new NotImplementedException();
        }

        public Country Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAllCountry()
        {
            return _context.Countries;
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Find(id);
        }

        public Country Update(Country updateCountry)
        {
            throw new NotImplementedException();
        }
    }
}
