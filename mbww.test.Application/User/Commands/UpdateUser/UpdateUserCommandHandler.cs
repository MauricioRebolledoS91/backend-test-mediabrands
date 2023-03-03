using AutoMapper;
using mbww.test.Application.Contracts.Persistence;
using mbww.test.Application.Exceptions;
using mbww.test.Application.User.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IAsyncRepository<Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUserCommandResponse = new UpdateUserCommandResponse();
            var existUserName = await _userRepository.GetByUserNameAsync(request.UserName);
            if (existUserName != null && existUserName.Email != request.Email)
            {
                updateUserCommandResponse.Success = false;
                updateUserCommandResponse.Message = "Este nombre de usuario ya está registrado";
                return updateUserCommandResponse;
            }
            var userToUpdate = await _userRepository.GetByIdAsync(request.Id);

            if (userToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }

            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(Domain.Entities.User));

            await _userRepository.UpdateAsync(userToUpdate);

            updateUserCommandResponse.Success = true;
            return updateUserCommandResponse;
        }
    }
}
