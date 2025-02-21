using GraphicEditor.Models.Interfaces;
namespace GraphicEditor.Models
{
    public class GraphicEditor
    {
        public string DrawShape(IShape shape)
            => $"I'm {shape.GetType().Name}";
    }
}
