using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Domain.Entities
{
    public class PlayerData
    {
        public int Rank { get; private set; }
        public int Points { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }
        public int Age { get; private set; }
        public List<int> Last { get;  private set; }

        public PlayerData(int rank, int points, int weight, int height, int age, List<int> last)
        {
            if (rank <= 0)
                throw new ArgumentException("Rank must be greater than 0.");

            if (points < 0)
                throw new ArgumentException("Points must be a positive value.");

            if (weight <= 0)
                throw new ArgumentException("Weight must be greater than 0.");

            if (height <= 0)
                throw new ArgumentException("Height must be greater than 0.");

            if (age <= 0)
                throw new ArgumentException("Age must be greater than 0.");

            Rank = rank;
            Points = points;
            Weight = weight;
            Height = height;
            Age = age;
            Last = last ?? throw new ArgumentNullException(nameof(last));
        }
    }
}
