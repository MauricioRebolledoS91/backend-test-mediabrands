using AutoMapper;
using mbww.test.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.DeleteEvent
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IAsyncRepository<Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _userRepository.GetByIdAsync(request.UserId);

            await _userRepository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
