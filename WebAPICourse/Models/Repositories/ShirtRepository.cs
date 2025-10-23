namespace WebAPICourse.Models.Repositories
{
    public class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>
        {
            new Shirt { ShirtId = 1, Size = 8, Color = "Red", Brand = "MyBrand", Gender = "Men", Price = 30},
            new Shirt { ShirtId = 2, Size = 3, Color = "Red", Brand = "MyBrand", Gender = "Men", Price = 30},
            new Shirt { ShirtId = 3, Size = 5, Color = "Blue", Brand = "YourBrand", Price = 25, Gender = "Women" },
            new Shirt { ShirtId = 4, Size = 6, Color = "Blue", Brand = "YourBrand", Price = 25, Gender = "Women" },


        };



        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? color, string? gender, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value
            );
        }

        public static void CreateShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;

            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var existingShirt = shirts.First(x => x.ShirtId == shirt.ShirtId);

            existingShirt.Brand = shirt.Brand;
            existingShirt.Price = shirt.Price;
            existingShirt.Size = shirt.Size;
            existingShirt.Color = shirt.Color;
            existingShirt.Gender = shirt.Gender;



        }
    }
}
