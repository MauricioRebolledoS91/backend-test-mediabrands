using AutoMapper;
using mbww.test.Application.Contracts.Persistence;
using mbww.test.Domain.Entities;
using MediatR;

namespace mbww.test.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.User> _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new CreateUserCommandResponse();
            var existUserName = await _userRepository.GetByUserNameAsync(request.UserName);
            if (existUserName != null)
            {
                createUserCommandResponse.Success = false;
                createUserCommandResponse.Message = "Este nombre de usuario ya está registrado";
                return createUserCommandResponse;
            }        

            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserCommandResponse.Success = false;
                createUserCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createUserCommandResponse.Success)
            {
                var user = new Domain.Entities.User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.UserName
                };
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.User = _mapper.Map<CreateUserDto>(user);
            }

            return createUserCommandResponse;
        }
    }
}
