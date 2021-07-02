using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        // since we are issuing a command, we do not need to pass a type
        // to IRequest because it is not returning anything.
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // we use Add() and not AddAsync() because
                // we are only storing the new Activity in memory
                // we will await the SaveChanges though and use
                // SaveChangesAsync()
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                return Unit.Value; // equivalent to nothing. lets the API controller know we finished.
            }
        }
    }
}