// * Д.З. Реалізувати інтерфейс для запуску/зупинки сервера
//  * > Server OFF
//  * > 1 - Start
//  * > 0 - Exit
//  * >  1
//  * > Server ON
//  * > 2 - Stop
//  * > 0 - Exit
//  * >  0
//  * >  Server Stopped
//  * 
//  * Реалізувати команду генерації випадкового значення
//  * Command: 'RND-FILE'   | випадковий рядок довжиною 10 символів
//  * Payload: 10           | який може бути іменем файлу (не містить * / \ ? .. )
//  * 
//  * Command: 'RND-UINT'   | випадкове беззнакове число у діапазоні
//  * Payload: 10000        | 0 -- 10000
//  */

namespace ServerApp
{
    internal class RandomService
    {
        private static readonly Random Random = new Random();
        public string GenerateRandomFileName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[Random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
        public uint GenerateRandomUInt(uint maxValue)
        {
            return (uint)Random.Next(0, (int)maxValue);
        }
        public ulong GenerateRandomULong(ulong maxValue)
        {
            byte[] buffer = new byte[8];
            Random.NextBytes(buffer);
            ulong randomULong = BitConverter.ToUInt64(buffer, 0);
            return randomULong % maxValue;
        }

    }
}