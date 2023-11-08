using CallCenter.Types;

namespace CallCenter.Models{
    public class Id
    {
        public Guid id { get ; set ; }
    
        public Id()
        {
        }

        public Id(Guid Id)
        {
            this.id = Id;
        }
    }
}