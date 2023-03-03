using mbww.test.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.User.Commands.CreateUser
{
    public class CreateUserCommandResponse : BaseResponse
    {
        public CreateUserCommandResponse() : base()
        {

        }
        public CreateUserDto User { get; set; }
    }
}
