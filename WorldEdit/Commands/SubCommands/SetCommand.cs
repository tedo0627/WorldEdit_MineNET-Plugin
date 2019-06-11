using MineNET.Commands;
using MineNET.Commands.Data;
using MineNET.Commands.Parameters;
using MineNET.Entities.Players;
using MineNET.IO;
using MineNET.Values;
using MineNET.Worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldEdit.Data;
using WorldEdit.Utils;

namespace WorldEdit.Commands.SubCommands
{
    public class SetCommand : IWorldEditSubCommand
    {
        public string Name
        {
            get
            {
                return "set";
            }

        }

        public void AddCommandParameters(List<CommandOverload> list)
        {
            list.Add(new CommandOverload(
                new CommandParameterValueEnum("set"),
                new CommandParameterString("id...", true)
                ));
        }

        public bool OnExecute(CommandSender sender, string command, string[] args)
        {
            if (args.Length < 2)
            {
                sender.SendMessage("/edit set [id...]");
                return false;
            }

            Player player = (Player)sender;
            World world = player.World;

            WorldEdit edit = WorldEdit.Instance;
            PositionData data = edit.PositionManager.getPositionData(player.Name);

            RandomBlockSelector selector = new RandomBlockSelector(args[1]);
            Tuple<Vector3, Vector3> tuple = data.GetSortPosition();
            Vector3 pos1 = tuple.Item1;
            Vector3 pos2 = tuple.Item2;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 0;

            for (int x = pos1.FloorX; x <= pos2.FloorX; ++x)
            {
                for (int y = pos1.FloorY; y <= pos2.FloorY; ++y)
                {
                    for (int z = pos1.FloorZ; z <= pos2.FloorZ; ++z)
                    {
                        world.SetBlock(new Vector3(x, y, z), selector.GetBlock());
                        count++;
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            player.SendMessage($"§b{count}ブロックの設置完了 {ts.Seconds}.{ts.Milliseconds}秒");
            return true;
        }
    }
}
