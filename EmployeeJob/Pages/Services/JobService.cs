using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;

namespace EmployeeJob.Pages.Services
{
    public class JobService
    {
        private Context Context { get; set; }
        public JobService(Context context) 
        {
          this.Context = context;
        }

        public async Task AddToDb(Jobs job)
        {
            await Context.AddAsync(job);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateDb(Jobs jobs)
        {
            Context.Jobs.Update(jobs);
            await Context.SaveChangesAsync();
        }

        public async Task<Jobs> GetJobById(int id)
        {
           return await Context.Jobs.FirstOrDefaultAsync(j => j.JId == id);
        }

        public async Task<List<Jobs>> getallJobs()
        {
           return await Context.Jobs.Where(e => e.isDelete != true).ToListAsync();
        }

        public async Task<List<Jobs>> filter_By_Name(string name)
        {
            return await Context.Jobs.Where(job => job.Name.Contains(name)).ToListAsync();
        }
        public async Task<List<Jobs>> filter_By_NameDELTED(string name)
        {
            return await Context.Jobs.Where(job => job.Name.Contains(name) && job.isDelete==true).ToListAsync();
        }
        public async Task<List<Jobs>> getallDeletedJob()
        {
            return await Context.Jobs.Where(e => e.isDelete == true).ToListAsync();
        }
        public async Task DeleteJob(int? id)
        {
            try
            {
                Jobs job = this.Context.Jobs.FirstOrDefault(j => j.JId == id);
                Context.Jobs.Remove(job);
                await Context.SaveChangesAsync();
            }catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            
        }

        public async Task FindAndUpdate(int? id)
        {
            try
            {
                Jobs job = this.Context.Jobs.FirstOrDefault(j => j.JId == id);
                job.isDelete = false;
                Context.Jobs.Update(job);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
