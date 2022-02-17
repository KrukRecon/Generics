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
            EmployeeRepositoryMethod(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            OrganizationRepositoryMethod(organizationRepository);
            WriteAllToConsole(organizationRepository);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager() {FirstName = "Piter"});
            managerRepository.Add(new Manager() {FirstName = "Maca"});
            managerRepository.Add(new Manager() {FirstName = "Trawon"});
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
            employeeRepository.Add(new Employee() {FirstName = "Adam"});
            employeeRepository.Add(new Employee() {FirstName = "Majki"});
            employeeRepository.Add(new Employee() {FirstName = "Karol"});
            employeeRepository.Save();
        }

        private static void OrganizationRepositoryMethod(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization() {Name = "Pluralsight"});
            organizationRepository.Add(new Organization() {Name = "SDWorx"});
            organizationRepository.Save();
        }
    }
}
