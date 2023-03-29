using RahulApp.Data;

namespace RahulApp.Models
{
    public class SqlState : IState
    {
        private ApplicationDbContext _context;
        public SqlState(ApplicationDbContext context)
        {
            _context = context;
        }

        public State Add(State addState)
        {
            throw new NotImplementedException();
        }

        public State Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetAllState()
        {
            return _context.States;
        }

        public State GetState(int id)
        {
            return _context.States.Find(id);
        }

        public State Update(State updateState)
        {
            throw new NotImplementedException();
        }
    }
}
