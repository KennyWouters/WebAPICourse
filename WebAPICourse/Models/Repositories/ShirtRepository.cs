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

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }


    }
}
