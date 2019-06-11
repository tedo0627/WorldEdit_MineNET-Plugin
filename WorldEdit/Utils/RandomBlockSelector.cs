using MineNET.Blocks;
using MineNET.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEdit.Utils
{
    public class RandomBlockSelector
    {
        private List<Block> blocks;

        public RandomBlockSelector(String str)
        {
            this.blocks = new List<Block>();

            string[] sp = str.Split(',');
            for (int i = 0; i < sp.Length; ++i)
            {
                string s = sp[i];
                string[] spp = s.Split('%');

                int ratio;
                string b;
                if (spp.Length == 1)
                {
                    ratio = 1;
                    b = spp[0];
                }
                else
                {
                    int.TryParse(spp[0], out ratio);
                    b = spp[1];
                }

                Block block = Block.Get(b);
                for (int j = 0; j < ratio; ++j)
                {
                    this.blocks.Add(block);
                }
            }

            if (this.blocks.Count == 0)
            {
                this.blocks.Add(Block.Get(0));
            }
        }

        public Block GetBlock()
        {
            this.blocks = this.blocks.OrderBy(a => Guid.NewGuid()).ToList();
            return this.blocks[0];
        }
    }
}
