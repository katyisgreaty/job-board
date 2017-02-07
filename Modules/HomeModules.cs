using Nancy;
using Cars.Objects;
using System.Collections.Generic;

namespace JobBoards
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get['/'] = _ => View["add_new_job.cshtml"];
      Get['/view_all_jobs'] = _ => {
        List<Job> allJobs = Job.GetAll();
        return View["view_all_jobs.cshtml", allJobs];
      };
      Post["/jobs_added"] = _ => {
        Job newJob = new Car(Request.Form["new-title"], Request.Form["new-description"], Request.Form["new-contact-info"]);
        newJob.Save();
        return View["jobs_added.cshtml", newJob];
      };
      Post["/jobs_cleared"] = _ => {
        Job.ClearAll();
        return View["jobs_cleared.cshtml"];
      };
    }
  }
}
