using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.DeleteEvent
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
