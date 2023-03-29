namespace RahulApp.Models
{
    public interface IEmployee
    {
        Employee Add(Employee addEmployee);
        Employee Update(Employee updateEmployee);
        Employee Delete(int id);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployee();
    }
}
