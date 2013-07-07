using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.CommandProcessor.Commands;
    using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Menu;
    using TroyLeeMVCEF.Domain.Commands;
    using TroyLeeMVCEF.Model.Entities;

    public class DeleteMenuHandler : ICommandHandler<DeleteMenuCommand>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteMenuHandler(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteMenuCommand command)
        {
            Guid ID;
            var menu = new Menu
            {
                MenuID = command.MenuID,
                IsDeleted = command.IsDeleted
            };
            if (menuRepository.GetById(command.MenuID) == null)
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
