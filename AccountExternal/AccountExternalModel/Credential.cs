using BaseModel;
using System.Collections.Generic;

namespace AccountExternalModel
{
    public class Credential : Base
    {
        public bool IsActive { get; set; }

        public int CredentialId { get; set; }
        public string Credentialname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }

        public ICollection<CredentialRole> CredentialRoles { get; set; }
    }
}
