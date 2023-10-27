using CommanLayer.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.Enum
{
    public enum UserStatus
    {
        ACTIVE= StatusConstant.ACTIVE,
        INACTIVE=StatusConstant.INACTIVE,
    }
    public enum UserRole
    {
        ADMIN = RoleConstant.ADMIN,
        USER = RoleConstant.USER,
    }
}
