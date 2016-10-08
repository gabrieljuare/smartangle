using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;

namespace SmartAngle.Web.Services
{
    public interface IRegisterService
    {
        List<Register> GetRegisters(Guid deviceId, string variableName);
        Register GetRegister(Guid deviceId, Guid registerId);
        Guid AddRegister(Guid deviceId, Register register);
    }
}
