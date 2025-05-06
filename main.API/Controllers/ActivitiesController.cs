using System;
using main.Domain;
using main.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace main.API.Controllers;

// this uses a primary constructor to inject the AppDbContext into the controller
// this only works if we only need one item, otherwise we need to use a constructor
public class ActivitiesController(AppDbContext context) : ApiController
{

    // private readonly AppDbContext _context;
    // public ActivitiesController(AppDbContext context)
    // {
    //     this._context = context;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    } 

    [HttpGet("{Id}")]
    public async Task<ActionResult<Activity>> GetActivityById(string Id)
    {
        var activity = await context.Activities.FindAsync(Id);

        if(activity == null) return NotFound();

        return activity;
    }

}
