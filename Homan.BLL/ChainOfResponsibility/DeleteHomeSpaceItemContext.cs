using System;

namespace Homan.BLL.ChainOfResponsibility
{
    public class DeleteHomeSpaceItemContext
    {
        public Guid HomeSpaceUserId { get; set; }
        public Guid HomeSpaceItemId { get; set; }
    }
}