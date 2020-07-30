using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobTrackingApp;
using JobTrackingApp.Data;

namespace JobTrackingApp.Controllers_
{
    public class JobViewController : Controller
    {
        private readonly JobsContext _context;

        public JobViewController(JobsContext context)
        {
            _context = context;
        }

        // GET: JobView
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobsModel.ToListAsync());
        }

        // GET: JobView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.JobsModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobsModel == null)
            {
                return NotFound();
            }

            return View(jobsModel);
        }

        // GET: JobView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobView/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,company,title,job_number,last_checked,last_updated,date_applied,status,notes,interview,rejected,city,state,country")] JobsModel jobsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobsModel);
        }

        // GET: JobView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.JobsModel.FindAsync(id);
            if (jobsModel == null)
            {
                return NotFound();
            }
            return View(jobsModel);
        }

        // POST: JobView/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,company,title,job_number,last_checked,last_updated,date_applied,status,notes,interview,rejected,city,state,country")] JobsModel jobsModel)
        {
            if (id != jobsModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsModelExists(jobsModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobsModel);
        }

        // GET: JobView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.JobsModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobsModel == null)
            {
                return NotFound();
            }

            return View(jobsModel);
        }

        // POST: JobView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobsModel = await _context.JobsModel.FindAsync(id);
            _context.JobsModel.Remove(jobsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsModelExists(int id)
        {
            return _context.JobsModel.Any(e => e.ID == id);
        }
    }
}
