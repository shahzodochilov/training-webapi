namespace Treaning.WebAPI.Helpers
{
    public static class ImageHelper
    {
        public static string MakeImageName(string fileName)
        {
            string guid = Guid.NewGuid().ToString();
            return "IMG_" + guid + fileName;
        }
    }
}
