namespace RahulApp.Models
{
    public interface IState
    {
        State Add(State addState);
        State Update(State updateState);
        State Delete(int id);
        State GetState(int id);
        IEnumerable<State> GetAllState();
    }
}
