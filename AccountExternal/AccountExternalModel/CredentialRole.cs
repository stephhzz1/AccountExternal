using BaseModel;

namespace AccountExternalModel
{
    public class CredentialRole : Base
    {
        public int CredentialId { get; set; }
        public int CredentialRoleId { get; set; }
        public int RoleId { get; set; }

        public Credential Credential { get; set; }
        public Role Role { get; set; }
    }
}
