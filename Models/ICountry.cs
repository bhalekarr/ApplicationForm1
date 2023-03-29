namespace RahulApp.Models
{
    public interface ICountry
    {
        Country Add(Country addCountry);
        Country Update(Country updateCountry);
        Country Delete(int id);
        Country GetCountry(int id);
        IEnumerable<Country> GetAllCountry();
    }
}
