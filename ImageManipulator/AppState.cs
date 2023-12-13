using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator
{
    public class AppState
    {

        public Mode Mode { get; set; }
        public Bitmap Image { get; set; }
        public Func<Bitmap, TransformationArgs, Bitmap> Transformation { get; set; }

        public AppState(int width, int height) 
        {
            Image = new Bitmap(width, height);
            Transformation = ImageManipulator.Transformation.None;
            Mode = Mode.WholeArea;
        }
    }

    class SelectItem
    {
        public string? Name { get; set; }
        public Mode? Value { get; set; }
    }

    public enum Mode
    {
        WholeArea,
        Brush
    }
}
