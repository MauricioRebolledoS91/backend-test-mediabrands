using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<List<UserListVm>>
    {
    }
}
