using AccountExternalModel;
using System.Collections.Generic;

namespace AccountExternalFunction
{
    public interface IFCredentialRole
    {
        void Create(int createdBy, int userId, List<CredentialRole> userRoles);
    }
}
