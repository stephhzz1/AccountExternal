using AccountExternalData;
using AccountExternalEntity;
using AccountExternalModel;
using System.Collections.Generic;
using System.Linq;

namespace AccountExternalFunction
{
    public class FRole : IFRole
    {
        private IDRole _iDRole;

        public FRole(IDRole iDRoles)
        {
            _iDRole = iDRoles;
        }

        public FRole()
        {
            _iDRole = new DRole();

        }
        #region Create
        #endregion

        #region Read
        public bool HasRole(int credentialId, string[] roles)
        {
            var eRoles = _iDRole.Read<ERole>(a => a.CredentialRoles.Any(b => b.CredentialId == credentialId), "Name");
            return eRoles.Any(a => roles.Contains(a.Name));
        }

        public List<Role> Read(string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => true, sortBy);
            return Roles(eRoles);
        }

        public List<Role> Read(int credentialId, string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => a.CredentialRoles.Any(b => b.Credential.CredentialId == credentialId), sortBy);
            return Roles(eRoles);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Other Function
        private List<Role> Roles(List<ERole> eRoles)
        {
            return eRoles.Select(a => new Role
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                RoleId = a.RoleId,
                UpdatedBy = a.UpdatedBy,

                Name = a.Name
            }).ToList();
        }
        #endregion

    }
}
