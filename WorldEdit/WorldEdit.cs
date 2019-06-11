using MineNET;
using MineNET.IO;
using MineNET.Plugins;
using System;
using WorldEdit.Commands;
using WorldEdit.Data;

namespace WorldEdit
{
    public class WorldEdit : PluginBase
    {
        public static WorldEdit Instance { get; private set; }

        public PositionManager PositionManager { get; private set; }

        public override string Name
        {
            get
            {
                return "WorldEdit";
            }
        }

        public override void OnEnable()
        {
            WorldEdit.Instance = this;

            this.PositionManager = new PositionManager();

            Server.Instance.Command.RegisterCommand(new WorldEditCommand());

            new EventListener();
        }
    }
}
