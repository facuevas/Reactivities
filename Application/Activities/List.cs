using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        // Nested Query classes inherits from MediatR IRequest that
        // takes in type List<Activity>
        // This will be our query to the database to return a list
        // of Activities.
        public class Query : IRequest<List<Activity>> { }

        // Nested Handler class that will handle all of our requests from MediatR.
        // Handler inherits from IRequestHandler<> that takes the Query and the return Object type (in this case List<Activity>).
        // Note it is an interface.
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}