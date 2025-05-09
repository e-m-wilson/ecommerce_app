using System;
using main.Domain;
using Microsoft.AspNetCore.Mvc;
using main.Service.Activities.Queries;
using main.Service.Activities.Commands;

namespace main.API.Controllers;

// this uses a primary constructor to inject the AppDbContext into the controller
// this only works if we only need one item, otherwise we need to use a constructor
public class ActivitiesController : ApiController
{

    // private readonly AppDbContext _context;
    // public ActivitiesController(AppDbContext context)
    // {
    //     this._context = context;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    {
        return await Mediator.Send(new GetActivityList.Query(), ct);
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityById(string id, CancellationToken ct)
    {
        return await Mediator.Send(new GetActivityDetails.Query{Id = id}, ct);
    }


    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity, CancellationToken ct)
    {
        return await Mediator.Send(new CreateActivity.Command{Activity = activity}, ct);
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity, CancellationToken ct)
    {
        await Mediator.Send(new EditActivity.Command{Activity = activity}, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id, CancellationToken ct)
    {
        await Mediator.Send(new DeleteActivity.Command{Id = id}, ct);
        return Ok();
    }
}
