using MineNET;
using MineNET.Blocks;
using MineNET.Entities.Players;
using MineNET.Events.BlockEvents;
using MineNET.Events.PlayerEvents;
using MineNET.Items;
using MineNET.Values;
using WorldEdit.Data;

namespace WorldEdit
{
    public class EventListener
    {
        public EventListener()
        {
            Server.Instance.Event.Player.PlayerInteract += this.OnPlayerInteract;
            Server.Instance.Event.Block.BlockBreak += this.OnBlockBraek;
        }

        private void OnPlayerInteract(object sender, PlayerInteractEventArgs args)
        {
            Player player = args.Player;
            if (player.Inventory.MainHandItem.Item.ID != ItemIDs.WOODEN_AXE)
            {
                return;
            }

            args.IsCancel = true;

            Block block = args.Target;
            Vector3 pos = block.ToVector3();
            PositionData data = WorldEdit.Instance.PositionManager.getPositionData(player.Name);
            data.FirstPosition = pos;

            player.SendMessage($"§b1つ目の位置 | x {pos.FloorX} | y {pos.FloorY} | z {pos.FloorZ} | 範囲 {data.GetRange()}");
            player.SendMessage($"§bブロック名 {block.Name} | ブロックID {block.ID}:{block.Damage}");
        }

        private void OnBlockBraek(object sender, BlockBreakEventArgs args)
        {
            Player player = args.Player;
            if (player.Inventory.MainHandItem.Item.ID != ItemIDs.WOODEN_AXE)
            {
                return;
            }

            args.IsCancel = true;

            Block block = args.Block;
            Vector3 pos = block.ToVector3();
            PositionData data = WorldEdit.Instance.PositionManager.getPositionData(player.Name);
            data.SecoundPosition = pos;

            player.SendMessage($"§b2つ目の位置 | x {pos.FloorX} | y {pos.FloorY} | z {pos.FloorZ} | 範囲 {data.GetRange()}");
            player.SendMessage($"§bブロック名 {block.Name} | ブロックID {block.ID}:{block.Damage}");
        }
    }
}
