using System;
using WiredBrainCoffe.StorageApp.Data;
using WiredBrainCoffe.StorageApp.Entities;
using WiredBrainCoffe.StorageApp.Repositories;

namespace WiredBrainCoffe.StorageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            EmployeeRepositoryMethod(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            OrganizationRepositoryMethod(organizationRepository);
            WriteAllToConsole(organizationRepository);
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var manager = new Manager() { FirstName = "Piter" };
            var managerCopy = manager.Copy();

            if (managerCopy is not null)
            {
                managerCopy.FirstName += "_Copy";
                managerRepository.Add(managerCopy);
            }
            managerRepository.Add(manager);
            managerRepository.Add(new Manager() { FirstName = "Maca" });
            managerRepository.Add(new Manager() { FirstName = "Trawon" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (IEntity item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id = 2: {employee.FirstName}");
        }

        private static void EmployeeRepositoryMethod(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee() {FirstName = "Adam"},
                new Employee() {FirstName = "Majki"},
                new Employee() {FirstName = "Karol"},
            };
            employeeRepository.AddBatch(employees);
        }

        private static void OrganizationRepositoryMethod(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization() {Name = "Pluralsight"},
                new Organization() { Name = "SDWorx" },
            };
            organizationRepository.AddBatch(organizations);
        }
    }
}
