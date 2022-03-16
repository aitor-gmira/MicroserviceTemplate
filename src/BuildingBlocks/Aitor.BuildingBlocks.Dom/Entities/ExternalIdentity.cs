using System;

namespace Aitor.BuildingBlocks.Dom
{
    public class ExternalIdentity : IEquatable<ExternalIdentity>
    {
        public Guid Uuid { get; private set; }

        public ExternalIdentity()
        {
            this.Uuid = Guid.NewGuid();
        }

        public ExternalIdentity(Guid uuid)
        {
            this.Uuid = uuid;
        }

        public bool Equals(ExternalIdentity identity)
        {
            if (object.ReferenceEquals(this, identity)) return true;
            if (object.ReferenceEquals(null, identity)) return false;
            return this.Uuid.Equals(identity.Uuid);
        }

        public override bool Equals(object otroObjeto)
        {
            return Equals(otroObjeto as ExternalIdentity);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Uuid.GetHashCode();
        }

        public static bool operator ==(ExternalIdentity left, ExternalIdentity right)
        {
            if (Object.Equals(left, null))
            {
                return (Object.Equals(right, null)) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(ExternalIdentity left, ExternalIdentity right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Uuid=" + Uuid + "]";
        }
    }
}
