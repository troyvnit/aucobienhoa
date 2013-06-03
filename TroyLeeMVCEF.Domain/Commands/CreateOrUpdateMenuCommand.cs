using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using System;

namespace TroyLeeMVCEF.Domain.Commands
{
    public class CreateOrUpdateMenuCommand : ICommand
    {
        public CreateOrUpdateMenuCommand(Guid MenuID, string MenuName, string Url, bool IsDeleted, Guid ParentID, int OrderID)
        {
            this.MenuID = MenuID;
            this.MenuName = MenuName;
            this.Url = Url;
            this.OrderID = OrderID;
            this.IsDeleted = IsDeleted;
            this.ParentID = ParentID;
        }
        public Guid MenuID { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ParentID { get; set; }
    }
}
