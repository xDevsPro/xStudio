using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xStudio.Domain
{
    public class Entity
    {
        public int Id { get; protected set; }

        public bool Equals(Entity other)
        {
            return other != null && GetType() == other.GetType() && Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
