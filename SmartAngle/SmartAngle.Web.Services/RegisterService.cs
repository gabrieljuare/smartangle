using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAngle.Data.Entities;

namespace SmartAngle.Web.Services
{
    public class RegisterService : IRegisterService
    {
        public RegisterService()
        {
        }

        public Guid AddRegister(Guid deviceId, Register register)
        {
            throw new NotImplementedException();
        }

        public Register GetRegister(Guid deviceId, Guid registerId)
        {
            throw new NotImplementedException();
        }

        public List<Register> GetRegisters(Guid deviceId, string variableName)
        {
            throw new NotImplementedException();
        }
    }
}
