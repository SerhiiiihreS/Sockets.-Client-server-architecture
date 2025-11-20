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
    internal interface IRandomService
    {
    }
}