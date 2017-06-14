using System;

namespace FreeSource.Common.Models.Authorization
{
    public class UserToken
    {
        public virtual int Id { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime Login { get; set; }
        public virtual DateTime LastAccess { get; set; }
        public virtual DateTime Expiration { get; set; }
        public virtual User User { get; set; }
    }
}
