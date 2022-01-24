using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Common
{
    public enum ResultCodeEnum
    {
        Code200Success,
        Code500InternalServerError,
        Code204NoContent,
        Code400BadRequest,
        Code404NotFound,
        Code409ResourceAlreadyExists,
        Code500DatabasePersistError,
        UserOrPasswordIsIncorrect,
        UserNotFound,
        ClientNotFound,
        ClientWithThisPersonalIdAlreadyExists,
        PasswordDoesNotMatch,
        UserAlreadyExists,
    }
}
