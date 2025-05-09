using System;
using main.Domain;
using main.Repository;
using MediatR;

namespace main.Service.Activities.Queries;

public class GetActivityDetails
{

    public class Query : IRequest<Activity>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity> 
    {
        public async Task<Activity> Handle(Query request, CancellationToken ct) 
        {
            var activity = await context.Activities.FindAsync([request.Id], ct);
            if(activity is null) throw new Exception("Activity not found!");
            return activity;
        }
    }
}
