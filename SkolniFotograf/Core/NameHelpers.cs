namespace SkolniFotograf.Core
{
    public class NameHelpers
    {
        public static string CreateKeyName(string photoName)
        {
            string photoKeyName = photoName.Trim();
            photoKeyName = photoKeyName.Replace('.', '_');
            photoKeyName = photoKeyName.Replace('-', '_');
            photoKeyName = photoKeyName.Replace(' ', '_');
            return photoKeyName;
        }
    }
}
