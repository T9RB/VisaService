using System.Text;

namespace Api_Passport_and_Visa_Service.Cryptografy;
using System.Security.Cryptography;

public class CrypMethods
{
    public async Task<string> hashPassword(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] bytes = Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(bytes);


        StringBuilder stringBuilder = new StringBuilder();
        foreach (var hashByte in hash)
        {
            stringBuilder.Append(hashByte.ToString("X2"));
        }

        return Convert.ToString(stringBuilder);
    }
}