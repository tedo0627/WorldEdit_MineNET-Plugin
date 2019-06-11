using MineNET.Commands;
using MineNET.Commands.Data;
using MineNET.Data;
using MineNET.Entities.Players;
using MineNET.IO;
using System.Collections.Generic;
using WorldEdit.Commands.SubCommands;

namespace WorldEdit.Commands
{
    public class WorldEditCommand : Command
    {
        public Dictionary<string, IWorldEditSubCommand> sub = new Dictionary<string, IWorldEditSubCommand>();

        public WorldEditCommand()
        {
            this.initSubCommand();
        }

        private void initSubCommand()
        {
            this.registerSubCommand(new SetCommand());
        }

        public void registerSubCommand(IWorldEditSubCommand sub)
        {
            this.sub[sub.Name] = sub;
        }

        public override string Name
        {
            get
            {
                return "edit";
            }
        }

        public override string Description
        {
            get
            {
                return "WorldEdit用のコマンド";
            }
        }

        public override PlayerPermissions PermissionLevel
        {
            get
            {
                return PlayerPermissions.OPERATOR;
            }
        }

        public override CommandOverload[] CommandOverloads
        {
            get
            {
                List<CommandOverload> list = new List<CommandOverload>();
                foreach (string key in this.sub.Keys)
                {
                    IWorldEditSubCommand sub = this.sub[key];
                    sub.AddCommandParameters(list);
                }
                return list.ToArray();
            }
        }

        public override bool OnExecute(CommandSender sender, string command, params string[] args)
        {
            if (!sender.IsPlayer)
            {
                sender.SendMessage("§cプレイヤー以外が実行することはできません");
                return false;
            }

            // TODO : permission check

            if (args.Length < 0)
            {
                sender.SendMessage("/edit set [id]..");
                return false;
            }

            string sub = args[0];
            if (this.sub.ContainsKey(sub))
            {
                return this.sub[sub].OnExecute(sender, command, args);
            }

            sender.SendMessage("/edit set [id]...");
            return false;
        }
    }
}
