using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeJob.Pages.Services
{
    public class EmployeeJobServices
    {

        private Context Context { get; set; }
        public EmployeeJobServices(Context context)
        {
            this.Context = context;
        }

        public async Task<bool> Get_EJ_By_JId(Jobs job)
        {
            return  this.Context.EmployeeJobs.Any(ej => ej.Jid == job.JId);
        }

        public async Task<List<string>> getAllEmployees_withId(int? JobId)
        {
            List<int> idList = await Context.EmployeeJobs.Where(e => e.Jid == JobId).Select(e => e.Eid).ToListAsync();
            return await Context.Employee.Where(e => idList.Contains(e.Eid)).Select(e => e.Name).ToListAsync();
        }

        public async Task<List<Jobs>> get_Employee_Jobs(int Eid) 
        {
           List<int> jobs = this.Context.EmployeeJobs.Where(e=>e.Eid==Eid).Select(e=>e.Jid).ToList() ;
           return await this.Context.Jobs.Where(e=>jobs.Contains(e.JId)).ToListAsync() ;
        }

        public async Task AddEmployeeJob(string JobName,int Eid) 
        {
            Jobs job = this.Context.Jobs.FirstOrDefault(j=>j.Name==JobName);
            EJ e = Context.EmployeeJobs.FirstOrDefault(e => (e.Eid == Eid && e.Jid == job.JId));
            if (e == null)
            {
               var ej = new EJ
                {
                  Eid = Eid,
                  Jid = job.JId
                };
                await this.Context.EmployeeJobs.AddAsync(ej);
                await this.Context.SaveChangesAsync();
            }
    
        }


        public async Task DeleteEmployeeJob(int Jid, int Eid)
        {
             EJ ej = Context.EmployeeJobs.FirstOrDefault(e => (e.Eid == Eid && e.Jid == Jid));
             this.Context.EmployeeJobs.Remove(ej);
             await this.Context.SaveChangesAsync();
            }

        }
}

