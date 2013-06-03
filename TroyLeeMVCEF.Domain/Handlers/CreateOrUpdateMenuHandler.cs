using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.Domain.Commands;
using TroyLeeMVCEF.Model.Entities;
using System;
using TroyLeeMVCEF.CommandProcessor.Commands;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Menu;

    public class CreateOrUpdateMenuHandler : ICommandHandler<CreateOrUpdateMenuCommand>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateMenuHandler(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateMenuCommand command)
        {
            Guid ID;
            var menu = new Menu
            {
                MenuID = command.MenuID,
                MenuName = command.MenuName,
                IsDeleted = command.IsDeleted,
                Url = command.Url,
                OrderID = command.OrderID,
                ParentID = command.ParentID
            };
            if (menu.MenuID == Guid.Empty)
            {
                menu.MenuID = Guid.NewGuid();
                menuRepository.Add(menu);
                ID = menu.MenuID;
            }
            else
            {
                menuRepository.Update(menu);
                ID = menu.MenuID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
