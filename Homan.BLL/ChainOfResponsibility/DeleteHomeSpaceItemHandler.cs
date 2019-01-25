namespace Homan.BLL.ChainOfResponsibility
{
    public abstract class DeleteHomeSpaceItemHandler
    {
        public DeleteHomeSpaceItemHandler Successor;

        protected abstract void Action(DeleteHomeSpaceItemContext context);

        public void Handle(DeleteHomeSpaceItemContext context)
        {
            Action(context);
            Successor?.Handle(context);
        }
    }
}