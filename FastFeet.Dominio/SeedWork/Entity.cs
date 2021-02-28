using System;

namespace FastFeet.Dominio.SeedWork
{
    public abstract class Entity
    {
        int? _requestedHashCode;
        public int Id { get; set; }

        #region Comparacoes

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        #endregion

    }
}
