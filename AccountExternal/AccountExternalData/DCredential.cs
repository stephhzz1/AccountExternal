using AccountExternalContext;
using AccountExternalEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountExternalData
{
    public class DCredential : DBase, IDCredential
    {
        public DCredential() : base(new Context())
        {
        }

        #region Create
        #endregion

        #region Read
        public List<ECredential> Read()
        {
            using (var context = new Context())
            {
                return context.Credentials
                    .Include(a => a.CredentialRoles)
                    .Include(a => a.CredentialRoles.Select(b => b.Role))
                    .OrderBy(a => a.Username)
                    .ToList();
            }
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        #endregion

    }
}
