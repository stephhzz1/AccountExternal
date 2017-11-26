using AccountExternalModel;
using System.Collections.Generic;

namespace AccountExternalFunction
{
    public interface IFRole
    {
        #region Create

        #endregion

        #region Read
        bool HasRole(int credentialId, string[] roles);
        List<Role> Read(string sortBy);
        List<Role> Read(int credentialId, string sortBy);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Other Function

        #endregion
    }
}
