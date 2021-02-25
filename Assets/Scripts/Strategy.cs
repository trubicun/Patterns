namespace Strategy
{
    public interface IInteractible
    {
        void Interact();
    }

    public interface ISelectable
    {
        void Select();
        void DeSelect();
    }
}