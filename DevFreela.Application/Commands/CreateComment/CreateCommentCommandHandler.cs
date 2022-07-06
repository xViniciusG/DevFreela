using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext; 
        private readonly IMediator _mediator; 
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;   
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return comment.Id;
        }
    }
}
