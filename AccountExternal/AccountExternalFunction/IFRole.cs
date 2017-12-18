using AccountExternalModel;
using System.Collections.Generic;

namespace AccountExternalFunction
{
    public interface IFRole
    {
        #region Create
        Role Create(int createBy, Role role);
        #endregion

        #region Read
        bool HasRole(int credentialId, string[] roles);
        List<Role> Read(string sortBy);
        List<Role> Read(int credentialId, string sortBy);
        Role Read(int id);
        #endregion

        #region Update
        Role Update(int updateBy, Role role);
        #endregion

        #region Delete
        void Delete(int roleId);
        #endregion

        #region Other Function

        #endregion
    }
}
