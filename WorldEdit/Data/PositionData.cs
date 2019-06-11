using MineNET.IO;
using MineNET.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEdit.Data
{
    public class PositionData
    {
        public Vector3 FirstPosition { get; set; }
        public Vector3 SecoundPosition { get; set; }

        public Tuple<Vector3, Vector3> GetSortPosition()
        {
            Vector3 first = this.FirstPosition;
            Vector3 secound = this.SecoundPosition;

            if (first.X > secound.X)
            {
                first.X = first.X + secound.X;
                secound.X = first.X - secound.X;
                first.X = first.X - secound.X;
            }

            if (first.Y > secound.Y)
            {
                first.Y = first.Y + secound.Y;
                secound.Y = first.Y - secound.Y;
                first.Y = first.Y - secound.Y;
            }

            if (first.Z > secound.Z)
            {
                first.Z = first.Z + secound.Z;
                secound.Z = first.Z - secound.Z;
                first.Z = first.Z - secound.Z;
            }

            return new Tuple<Vector3, Vector3>(first, secound);
        }

        public int GetRange()
        {
            int x = Math.Abs(this.FirstPosition.FloorX - this.SecoundPosition.FloorX) + 1;
            int y = Math.Abs(this.FirstPosition.FloorY - this.SecoundPosition.FloorY) + 1;
            int z = Math.Abs(this.FirstPosition.FloorZ - this.SecoundPosition.FloorZ) + 1;

            return x * y * z;
        }
    }
}
