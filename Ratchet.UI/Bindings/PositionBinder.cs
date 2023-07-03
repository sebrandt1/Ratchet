using RatchetMemoryApi.Memory;
using RatchetMemoryApi.Memory.Addresses;
using System.Windows;

namespace Ratchet.UI.Bindings
{
    internal class PositionBinder
    {
        private readonly Position position;
        public PositionBinder()
        {
            position = new Position();
        }

        public float X 
        {
            get => position.X; 
        }
        public float Y 
        { 
            get => position.Y; 
        }
        public float Z 
        { 
            get => position.Z;
        }

        public Positions SelectedIncrementPosition { get; set; } = Positions.X;
        public float PositionIncrement { get; set; } = 0;

        public void IncrementPosition()
        {
            position.AddToPosition(SelectedIncrementPosition, PositionIncrement);
        }

        public void SetPosition(string x, string y, string z)
        {
            if(float.TryParse(x, out float xPos) && float.TryParse(y, out float yPos) && float.TryParse(z, out float zPos))
            {
                position.SetPosition(xPos, yPos, zPos);
                return;
            }
            MessageBox.Show("Could not parse positions");
        }

    }
}
