using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeJob.Pages.Services
{
    public class EmployeeService
    {

        private Context Context { get; set; }
        public EmployeeService(Context context)
        {
            this.Context = context;
        }

        public async Task<Employees> getEmployee_ById(int? JobId)
        {
            return await Context.Employee.FirstOrDefaultAsync(e => e.Eid == JobId );
        }
        public async Task<List<Employees>> getAllEmployees()
        {
            return await Context.Employee.Where(e=>e.IsDeleted==false).ToListAsync();
        }

        public  Employees AddPhoto(IFormFile photo, Employees employees)
        {
            var file = photo;
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = "wwwroot/Uploads/" + uniqueFileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (photo != null)
            {
                employees.PersonalPhoto = $"~/Uploads/{uniqueFileName}";
            }
            return employees;
        }

        public async Task AddEmployee(Employees employees) 
        { 
            await this.Context.AddAsync(employees);
            await this.Context.SaveChangesAsync();
        }


        public async Task UpdateEmployee(Employees employees)
        {
            this.Context.Update(employees);
            await this.Context.SaveChangesAsync();
        }

        public async Task<List<Employees>> getallDeletedJob()
        {
            return await Context.Employee.Where(e => e.IsDeleted == true).ToListAsync();
        }

        public async Task<List<Employees>> filter_By_NameDELTED(string name)
        {
            return await Context.Employee.Where(job => job.Name.Contains(name) && job.IsDeleted == true).ToListAsync();
        }


        public async Task<List<Employees>> filter(string name)
        {

            var employeesByName = from e in Context.Employee
                                  where e.Name.Contains(name)
                                  where !e.IsDeleted
                                  select e;

            var employeesByJob = from e in Context.Employee
                                 join ej in Context.EmployeeJobs on e.Eid equals ej.Eid
                                 join j in Context.Jobs on ej.Jid equals j.JId
                                 where j.Name.Contains(name)
                                 where !e.IsDeleted
                                 select e;

            var result = await employeesByName.Union(employeesByJob).ToListAsync();

            return result;
        }

        public async Task DeleteEmployee(int? Eid)
        {
            try
            {
                Employees employees = this.Context.Employee.FirstOrDefault(j => j.Eid == Eid);
                var employeeJobsToDelete = await this.Context.EmployeeJobs.Where(j => j.Eid == Eid).ToListAsync();
                Context.Employee.Remove(employees);
                Context.EmployeeJobs.RemoveRange(employeeJobsToDelete);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }


        public async Task FindAndUpdate(int? id)
        {
            try
            {
                Employees employees = this.Context.Employee.FirstOrDefault(j => j.Eid == id);
                employees.IsDeleted = false;
                Context.Employee.Update(employees);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
