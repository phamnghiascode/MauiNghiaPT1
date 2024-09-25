using ClothFashion.Models;

namespace ClothFashion.Views.Templates
{
    public class GalleryDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenItemTemplate { get; set; }
        public DataTemplate OddItemTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            int itemId = ((Item)item).Id;

            if (itemId % 2 == 0)
                return EvenItemTemplate;

            else return OddItemTemplate;
        }
    }
}
