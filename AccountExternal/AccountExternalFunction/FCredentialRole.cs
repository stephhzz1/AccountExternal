using AccountExternalData;
using AccountExternalEntity;
using AccountExternalModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountExternalFunction
{
    public class FCredentialRole : IFCredentialRole
    {
        private IDCredentialRole _iDCredentialRole;

        public FCredentialRole(IDCredentialRole iDCredentialRoles)
        {
            _iDCredentialRole = iDCredentialRoles;
        }

        public FCredentialRole()
        {
            _iDCredentialRole = new DCredentialRole();

        }

        #region Create
        public void Create(int createdBy, int credentialId, List<CredentialRole> credentialRoles)
        {
            Delete(credentialId);

            if (!credentialRoles?.Any() ?? true)
                return;

            var eCredentialRoles = ECredentialRole(createdBy, credentialId, credentialRoles);
            _iDCredentialRole.Create(eCredentialRoles);
        }
        #endregion

        #region Read

        #endregion

        #region Update
        #endregion

        #region Delete
        private void Delete(int credentialId)
        {
            _iDCredentialRole.Delete<ECredentialRole>(a => a.CredentialId == credentialId);
        }
        #endregion

        #region Other Function
        private List<ECredentialRole> ECredentialRole(int createdBy, int credentialId, List<CredentialRole> credentialRoles)
        {
            return credentialRoles.Select(a =>
            new ECredentialRole
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = createdBy,
                RoleId = a.RoleId,
                UpdatedBy = a.UpdatedBy,
                CredentialRoleId = a.CredentialRoleId,
                CredentialId = credentialId
            }).ToList();
        }
        #endregion
    }
}
