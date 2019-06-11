using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEdit.Data
{
    public class PositionManager
    {
        private Dictionary<string, PositionData> datas = new Dictionary<string, PositionData>();

        public PositionData getPositionData(string name)
        {
            if (!this.datas.ContainsKey(name))
            {
                this.datas[name] = new PositionData();
            }

            return this.datas[name];
        }
    }
}
