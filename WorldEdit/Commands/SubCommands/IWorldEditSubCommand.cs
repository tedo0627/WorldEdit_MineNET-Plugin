using MineNET.Commands;
using MineNET.Commands.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEdit.Commands.SubCommands
{
    public interface IWorldEditSubCommand
    {
        string Name { get; }

        void AddCommandParameters(List<CommandOverload> list);

        bool OnExecute(CommandSender sender, string command, params string[] args);
    }
}
