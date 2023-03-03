using AutoMapper;
using mbww.test.Application.Contracts.Persistence;
using mbww.test.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListVm>>
    {
        private readonly IAsyncRepository<mbww.test.Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMapper mapper, IAsyncRepository<mbww.test.Domain.Entities.User> categoryRepository)
        {
            _mapper = mapper;
            _userRepository = categoryRepository;
        }
        public async Task<List<UserListVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(x => x.UserName);
            return _mapper.Map<List<UserListVm>>(allUsers);
        }
    }
}
