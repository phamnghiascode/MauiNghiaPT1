using ClothFashion.Models;
using System.Reflection.Emit;
namespace ClothFashion.Controls
{
    public class GalleryDatatemplateSelector : DataTemplateSelector
    {
        public DataTemplate OddGalleryItemTemplate { get; set;}
        public DataTemplate EvenGalleryItemTemplate { get; set;}
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var id = ((Item)item).Id;
            if (id % 2 == 0) {
                return EvenGalleryItemTemplate;
            }
            else
            {
                return OddGalleryItemTemplate;
            }
        }
    }
}
