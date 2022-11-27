using XNode;

namespace DialoguePackage
{
    public abstract class DialogueBaseNode : Node
    {
        public virtual string GetString()
        {
            return "DialogueBaseNode";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    } 
}
