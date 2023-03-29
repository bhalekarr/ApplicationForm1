using RahulApp.Data;

namespace RahulApp.Models
{
    public class SqlEmployee : IEmployee
    {
        private ApplicationDbContext _context;
        public SqlEmployee(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee addEmployee)
        {
            _context.Add(addEmployee);
            _context.SaveChanges();
            return addEmployee;
        }

        public Employee Delete(int id)
        {
            Employee emp = _context.Employees.Find(id);
            if (emp != null) 
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = _context.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateEmployee;
        }
    }
}
