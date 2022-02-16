using System;
using WiredBrainCoffe.StorageApp.Entities;
using WiredBrainCoffe.StorageApp.Repositories;

namespace WiredBrainCoffe.StorageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            EmployeeRepositoryMethod(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new GenericRepository<Organization>();
            OrganizationRepositoryMethod(organizationRepository);
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id = 2: {employee.FirstName}");
        }

        private static void EmployeeRepositoryMethod(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee() {FirstName = "Adam"});
            employeeRepository.Add(new Employee() {FirstName = "Majki"});
            employeeRepository.Add(new Employee() {FirstName = "Karol"});
            employeeRepository.Save();
        }

        private static void OrganizationRepositoryMethod(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization() {Name = "Pluralsight"});
            organizationRepository.Add(new Organization() {Name = "SDWorx"});
            organizationRepository.Save();
        }
    }
}
