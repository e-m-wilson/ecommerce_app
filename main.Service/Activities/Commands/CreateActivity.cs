using System;
using main.Domain;
using main.Repository;
using MediatR;

namespace main.Service.Activities.Commands;

public class CreateActivity
{

    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set ;}
    }


    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken ct)
        {
            context.Activities.Add(request.Activity);
            await context.SaveChangesAsync(ct);
            return request.Activity.Id;

        }
    }
}
